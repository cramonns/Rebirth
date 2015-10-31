using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic; 

namespace Rebirth{

    public class Umbrella:GameObject{

        const float LOWERING_ACCELERATION = 0.002f;
        const float LOWERING_TOP_SPEED = 0.06f;
        const float MAX_GROUND_ROTATION = (float)Math.PI/2;

        const float CANOPY_THICKNESS = 0.5f;
        const float CANOPY_LENGTH = 1.4f;
        const int COLLIDERS_COUNT = 4; // (MUST BE 2 OR GREATER) Optimal estimated value: ((int)(CANOPY_LENGTH - CANOPY_THICKNESS)*2/CANOPY_THICKNESS) + 1

        float lowering_speed = 0;

        public bool open;
        Player owner;
        public float rotation;
        public const float Thickness = 0.2f;
        public const float Length = 1.3f;

        public Umbrella(Player p){
            colliders = new List<RectangleF>(COLLIDERS_COUNT);
            for (int i = 0; i < COLLIDERS_COUNT; i++){
                colliders.Add(null);
            }
            Color[] colors = new Color[] { Color.White };
            texture = new Texture2D(GameManager.game.GraphicsDevice, 1, 1);
            texture.SetData<Color>(colors);
            open = false;
            owner = p;
            float collidersStartY = owner.Y + owner.Height/2 + Length - CANOPY_THICKNESS;
            float collidersStartX = owner.X + owner.Width/2 - CANOPY_LENGTH/2;
            boundingBox = new RectangleF(collidersStartX, collidersStartY, CANOPY_LENGTH, CANOPY_THICKNESS);
            colliders[0] = (new RectangleF(collidersStartX, collidersStartY, CANOPY_THICKNESS, CANOPY_THICKNESS));
            colliders[COLLIDERS_COUNT-1] = new RectangleF(collidersStartX + CANOPY_LENGTH - CANOPY_THICKNESS, collidersStartY, CANOPY_THICKNESS, CANOPY_THICKNESS);
            float centerX1 = colliders[0].x + CANOPY_THICKNESS/2;
            float centerX2 = colliders[COLLIDERS_COUNT-1].x + CANOPY_THICKNESS/2;
            int parts = COLLIDERS_COUNT-1;
            if (parts > 0){
                float lengthX = (centerX2 - centerX1)/(float)parts;
                for (int i = 1; i < COLLIDERS_COUNT-1; i++){
                    colliders[i] = new RectangleF(collidersStartX + lengthX*i - CANOPY_THICKNESS/2, collidersStartY, CANOPY_THICKNESS, CANOPY_THICKNESS);
                }
            }
        }

        public override void updateBoundingBox() {
            float minx = colliders[0].x, miny = colliders[0].y;
            for (int i = 1; i < COLLIDERS_COUNT; i++){
                minx = (minx < colliders[i].x)?minx:colliders[i].x;
                miny = (miny < colliders[i].y)?miny:colliders[i].y;
            }
            boundingBox.x += minx;
            boundingBox.y += miny;
            foreach (RectangleF r in colliders){
                r.x -= minx;
                r.y -= miny;
            }
            base.updateBoundingBox();   
        }

        public override void collide(GameObject b, CollisionDistance cd) {
            //throw new NotImplementedException();
            if (b is MoveableObject){
                MoveableObject bmov = b as MoveableObject;
                float auxRotation = (float)Math.Atan2(bmov.speed.X, bmov.speed.Y);
                auxRotation = rotation - auxRotation;
                bmov.speed =  (Vector2.Transform(bmov.speed, Matrix.CreateRotationZ(auxRotation)));
            }
        }

        public void updateColliders(){
            boundingBox.x = owner.X + owner.Width/2;
            boundingBox.y = owner.Y + owner.Height/2;
            colliders[0].Center = Vector2.Transform(new Vector2(CANOPY_THICKNESS/2  - CANOPY_LENGTH/2, Length - CANOPY_THICKNESS/2), Matrix.CreateRotationZ(-rotation));
            colliders[COLLIDERS_COUNT-1].Center = Vector2.Transform(new Vector2(CANOPY_LENGTH/2 - CANOPY_THICKNESS/2, Length - CANOPY_THICKNESS/2), Matrix.CreateRotationZ(-rotation));
            Vector2 center1 = colliders[0].Center;
            Vector2 center2 = colliders[COLLIDERS_COUNT-1].Center;
            int parts = COLLIDERS_COUNT-1;
            if (parts > 0){
                float lengthX = (center2.X - center1.X)/(float)parts;
                float lengthY = (center2.Y - center1.Y)/(float)parts;
                for (int i = 1; i < COLLIDERS_COUNT-1; i++){
                    colliders[i].Center = new Vector2(center1.X + lengthX*i, center1.Y + lengthY*i);
                }
            }
            updateBoundingBox();
        }

        public override void Update(GameTime gametime){
            if (ControllerManager.TriggerFloating || MouseManager.leftButtonPressed){
                /*if (!open){
                    if (ControllerManager.rightAnalogWaiting){
                        rotation = 0;
                    }
                }*/
                open = true;
            } else open = false;
            if (ControllerManager.rightAnalogWaiting){
                if (!MouseManager.mouseWaiting){
                    rotation = (float)Math.Atan2(MouseManager.mousePosition.X - MouseManager.mouseSource.X, MouseManager.mousePosition.Y - MouseManager.mouseSource.Y);
                }else {
                    if (ControllerManager.increaseRotation){
                        rotation += 0.02f;    
                    }
                    else if (ControllerManager.decreaseRotation){
                        rotation -= 0.02f;
                    }
                    if ( !open && ((ControllerManager.direction == TriggerDirection.Right && rotation < 0) ||
                        (ControllerManager.direction == TriggerDirection.Left && rotation > 0)) )
                    {
                        rotation *= -1;
                    }
                    MouseManager.updateSource(rotation);
                }
                /*if (owner.isGrounded() && !open){
                    lowering_speed += LOWERING_ACCELERATION;
                    if (lowering_speed > LOWERING_TOP_SPEED) lowering_speed = LOWERING_TOP_SPEED;
                    rotation += (rotation < 0)?-lowering_speed:lowering_speed;
                } else lowering_speed = 0;*/
            }
            else { 
                rotation = ControllerManager.rightAnalogRotation;
                lowering_speed = 0;
                MouseManager.updateSource(rotation);
            }
            if (owner.isGrounded()){
                if (rotation > MAX_GROUND_ROTATION) rotation = MAX_GROUND_ROTATION;
                else if (rotation < -MAX_GROUND_ROTATION) rotation = -MAX_GROUND_ROTATION;
            }
        }

        public override void Draw(SpriteBatch sb, GameTime gameTime){
            Rectangle rectangle = DisplayManager.scaleTexture(new Vector2(owner.X + owner.Width/2, owner.Y+owner.Height/2-Length),Thickness, Length);
            sb.Draw(texture, 
                rectangle, 
                null, 
                Color.Black, 
                rotation, 
                new Vector2(0.5f, 1f),
                SpriteEffects.None, 
                0f);
            if (open){
                rectangle = DisplayManager.scaleTexture(new Vector2(owner.X + owner.Width/2, owner.Y+owner.Height/2-CANOPY_THICKNESS),CANOPY_LENGTH, CANOPY_THICKNESS);
                sb.Draw(texture,
                    rectangle,
                    null,
                    Color.Black*0.5f,
                    rotation,
                    new Vector2(0.5f, 2.6f),
                    SpriteEffects.None,
                    0f);
#if DEV
                DrawBoundingBox(sb);
                DrawColliders(sb);
#endif
            }
        }
    }

    public class DroppedUmbrella:Trigger{
 
        public DroppedUmbrella(Player p):base(new Vector2(p.Center.X - Umbrella.Length/2, p.Y), Treatment.Default, Treatment.droppedUmprellaEnter, Treatment.droppedUmbrellaLeave){
            Color[] colors = new Color[] { Color.White };
            texture = new Texture2D(GameManager.game.GraphicsDevice, 1, 1);
            texture.SetData<Color>(colors);
            Width = Umbrella.Length;
            Height = Umbrella.Thickness;
        }

        public override void Draw(SpriteBatch sb, GameTime gameTime) {
            Color color = Color.Black;
            sb.Draw(texture, DisplayManager.scaleTexture(boundingBox), color);
        }

    }

    [Serializable]
	public class Player:Character{

		private enum playerStates:byte{
			WAITING,
			MOVING,
			JUMPING,
			FALLING,
            DUCKING,
            CROUCHING,
            FLOATING
		};

        private enum Directions:byte{
            NONE,
            RIGHT,
            LEFT
        };

		const float MOVING_TOP_SPEED = 6f/60f;
        const float CROUCHING_TOP_SPEED = 3.6f/60f;
		const float MOVING_ACCELERATION = .8f/60f;
		const float JUMP_MOVING_ACCELERATION = 0.1f/60f;
        const float FLOATING_MOVING_TOP_SPEED = 3.5f/60f;
		const float JUMP_IMPULSE = 15f/60f;
		const float JUMP_TOP_SPEED = 12f/60f;
		const float CHAR_WIDTH = .6f;
		const float CHAR_HEIGHT = 1.4f;
        const float FLOATING_MAX_FALLING_SPEED = 1.4f/60f;

		playerStates state;

		//Player Attributes
		float movingSpeed;
		Directions direction;
		Directions jumping_direction;

		//support variables
		float jumpStartPos;
        public bool allowStanding;
        bool dropped = false;


        //Addons
        public Umbrella umbrella = null;

        //Properties
        public Vector2 Center{
            get {return new Vector2(Position.X + Width/2, Position.Y + Height/2);}
        }

		public Player(){
			this.usePhysics = true;
			direction = Directions.RIGHT;
			state = playerStates.WAITING;

            RectangleF collider;
			collider = new RectangleF (new Vector2 (0, 0), CHAR_WIDTH, CHAR_HEIGHT);
            boundingBox = new RectangleF(new Vector2 (0, 100 / 60f), 0, 0);
            colliders.Add(collider);
            updateBoundingBox();
            

            textureId = TextureManager.TextureID.player;

            Attachment standingChecker = new Attachment(LogicalObject.Treatment.standingCheck, this, 0, CHAR_HEIGHT*0.1f, CHAR_WIDTH, CHAR_HEIGHT*0.9f);

            attachments.AddFirst(standingChecker);

            umbrella = new Umbrella(this);
		}

        private void startJump(){
            jumpStartPos = boundingBox.y;
			boundingBox.y += JUMP_IMPULSE;
	        speed.Y += JUMP_TOP_SPEED;
			state = playerStates.JUMPING;
			setGroundedState(false);
			if (movingSpeed != 0) jumping_direction = direction;
			else jumping_direction = Directions.NONE;
        }

		private void startFall(){
			state = playerStates.FALLING;
			ControllerManager.TriggerJumping = false;
            if (speed.Y > 0) speed.Y = 0;
		}

		public override void Update(GameTime gameTime){
            if (ControllerManager.TriggerDrop){
                if (grounded && !dropped){
                    if (umbrella != null) {
                        umbrella = null;
                        DroppedUmbrella du = new DroppedUmbrella(this);
                        GameManager.addObjectToScene(du);
                        GameManager.globalVariables.droppedUmbrella = du;
                    }
                    else if (GameManager.globalVariables.overUmbrella){
                        umbrella = new Umbrella(this);
                        GameManager.removeObjectFromScene(GameManager.globalVariables.droppedUmbrella);
                        GameManager.globalVariables.droppedUmbrella = null;

                    }
                }
                dropped = true;
            }
            else dropped = false;
            
            if (umbrella != null) umbrella.Update(gameTime);

            

			//updateBounds();
            float acceleration = MOVING_ACCELERATION;
            float topSpeed = MOVING_TOP_SPEED;
            float topVariations = 0;

            //Update Player State
            switch (state){
                case playerStates.MOVING:
                    goto case playerStates.WAITING;
                case playerStates.WAITING:
                    if (!grounded){
                        startFall();
                        acceleration = JUMP_MOVING_ACCELERATION;
                    }
                    else {
                        if (ControllerManager.TriggerDown){
                            state = playerStates.DUCKING;
                        } else if (ControllerManager.TriggerJumping){
                            startJump();
                            acceleration = JUMP_MOVING_ACCELERATION;
                        }
                    }
                    break;
                case playerStates.JUMPING:
                    acceleration = JUMP_MOVING_ACCELERATION;
                    if (!ControllerManager.TriggerJumping || speed.Y < 0) {
						startFall();
					} else break;
                    goto case playerStates.FALLING;
                case playerStates.FALLING:
                    goto case playerStates.FLOATING;
                case playerStates.FLOATING:
                    if (umbrella != null && umbrella.open && umbrella.rotation > -0.4 && umbrella.rotation < 0.4){
                        state = playerStates.FLOATING;
                        topVariations = umbrella.rotation/12;
                        if (topVariations < 0) topVariations*=-1;
                        if (speed.Y < -FLOATING_MAX_FALLING_SPEED - topVariations) speed.Y = -FLOATING_MAX_FALLING_SPEED - topVariations;
                        topSpeed = FLOATING_MOVING_TOP_SPEED;
                        topVariations = 20f/60f*umbrella.rotation;
                    }
                    else {
                        state = playerStates.FALLING;                        
                    }
                    if (grounded) state = playerStates.WAITING;
                    else acceleration = JUMP_MOVING_ACCELERATION;
                    break;
                case playerStates.CROUCHING:
                    goto case playerStates.DUCKING;
                case playerStates.DUCKING:
                    if (!ControllerManager.TriggerDown && allowStanding){
                        state = playerStates.WAITING;
                        goto case playerStates.WAITING;
                    }
                    else if (!grounded){
                        startFall();
                        acceleration = JUMP_MOVING_ACCELERATION;
                    }
                    break;
            }

			//Movement
			if (ControllerManager.direction == TriggerDirection.Right) {
                movingSpeed += acceleration;
				direction = Directions.RIGHT;
				if (state == playerStates.WAITING){
                    state = playerStates.MOVING;
                } 
                else if (state == playerStates.DUCKING){
                    state = playerStates.CROUCHING;
                    topSpeed = CROUCHING_TOP_SPEED;
                }
                topVariations = (topVariations>0)?topVariations:topVariations/8;
				if (movingSpeed > topSpeed + topVariations)
					movingSpeed = topSpeed + topVariations;
			} else if (ControllerManager.direction == TriggerDirection.Left) {
				movingSpeed -= acceleration;
                direction = Directions.LEFT;
				if (state == playerStates.WAITING) {
					state = playerStates.MOVING;
				}
				else if (state == playerStates.DUCKING){
                    state = playerStates.CROUCHING;
                    topSpeed = CROUCHING_TOP_SPEED;
                }
                topVariations = (topVariations<0)?topVariations:topVariations/8;
				if (movingSpeed < -topSpeed + topVariations) movingSpeed = -topSpeed + topVariations;
			}

            if (state == playerStates.DUCKING || state == playerStates.CROUCHING){
                boundingBox.height = CHAR_HEIGHT*0.6f;
                boundingBox.width = CHAR_WIDTH*1.2f;
            } else {
                boundingBox.height = CHAR_HEIGHT;
                boundingBox.width = CHAR_WIDTH;
            }

            allowStanding = true;
            if (umbrella != null && MouseManager.mouseWaiting)MouseManager.updateSource(umbrella.rotation);

            updateBoundingBox();

		}

        public override void applyAtrict(float atrict, float airResistance) {
            float resistance = (grounded) ? atrict : airResistance;
			if (movingSpeed < resistance && movingSpeed > -resistance) movingSpeed = 0;
			else if (movingSpeed > 0) movingSpeed -= resistance;
			else movingSpeed += resistance;
            speed.X = movingSpeed;
            if (umbrella != null) umbrella.updateColliders();
        }

        public override void Draw(SpriteBatch sb, GameTime gameTime){
			if (direction == Directions.RIGHT) {
				sb.Draw (texture, DisplayManager.scaleTexture(Position, boundingBox.width, boundingBox.height), Color.White);
			} else {
				sb.Draw(texture, DisplayManager.scaleTexture(Position, boundingBox.width, boundingBox.height), null, Color.White, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
			}
            if (umbrella != null)umbrella.Draw(sb,gameTime);
		}

		/*public override void setGroundedState(bool newState){
			base.setGroundedState (newState);
			if (newState) {
                if (this.state != playerStates.DUCKING && this.state != playerStates.CROUCHING)
                    this.state = playerStates.WAITING;
            }
			else if (this.state != playerStates.JUMPING) startFall();
		}*/

		public override void collide(GameObject b, CollisionDistance cd){
            switch (cd.direction){
                case CollisionDistance.CD_Direction.UP:
                    if (state == playerStates.JUMPING){
                        speed.Y = 0;
                        startFall();
                    }
                    break;
                case CollisionDistance.CD_Direction.DOWN:
                    break;
                case CollisionDistance.CD_Direction.EAST:
                    if (movingSpeed > 0 && ControllerManager.direction != TriggerDirection.Right) movingSpeed = 0;
                    break;
                case CollisionDistance.CD_Direction.WEST:
                    if (movingSpeed < 0  && ControllerManager.direction != TriggerDirection.Left) movingSpeed = 0;
                    break;
            }
		}

	}
}

