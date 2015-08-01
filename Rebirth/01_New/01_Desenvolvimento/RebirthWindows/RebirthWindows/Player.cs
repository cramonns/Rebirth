using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content; 

namespace Rebirth{

    public class Umbrella{

        const float LOWERING_ACCELERATION = 0.002f;
        const float LOWERING_TOP_SPEED = 0.06f;

        float lowering_speed = 0;

        public bool open;
        Texture2D texture;
        Player owner;
        public float rotation;

        public Umbrella(Player p){
            Color[] colors = new Color[] { Color.White };
            texture = new Texture2D(GameManager.game.GraphicsDevice, 1, 1);
            texture.SetData<Color>(colors);
            //texture = TextureManager.load(TextureManager.TextureID.white);
            open = false;
            owner = p;
        }


        public void Update(){
            if (ControllerManager.TriggerFloating){
                if (!open){
                    if (ControllerManager.rightAnalogWaiting){
                        rotation = 0;
                    }
                }
                open = true;
            } else open = false;
            if (ControllerManager.rightAnalogWaiting){
                if ((ControllerManager.direction == TriggerDirection.Right && rotation < 0) ||
                    (ControllerManager.direction == TriggerDirection.Left && rotation > 0) )
                {
                    rotation *= -1;
                }
                if (owner.isGrounded() && !open){
                    lowering_speed += LOWERING_ACCELERATION;
                    if (lowering_speed > LOWERING_TOP_SPEED) lowering_speed = LOWERING_TOP_SPEED;
                    rotation += (rotation < 0)?-lowering_speed:lowering_speed;
                } else lowering_speed = 0;
            }
            else {
                rotation = ControllerManager.rightAnalogRotation;
                lowering_speed = 0;
            }
            if (owner.isGrounded()){
                if (rotation > 2.7f) rotation = 2.7f;
                else if (rotation < -2.7f) rotation = -2.7f;
            }
        }

        public void draw(SpriteBatch sb, GameTime gameTime){
            Rectangle rectangle = DisplayManager.scaleTexture(new Vector2(owner.X + owner.Width/2, owner.Y+owner.Height/2-1.3f),0.2f, 1.3f);
            sb.Draw(texture, 
                rectangle, 
                null, 
                Color.Black, 
                rotation, 
                new Vector2(0.5f, 1f),
                SpriteEffects.None, 
                0f);
            if (open){
                rectangle = DisplayManager.scaleTexture(new Vector2(owner.X + owner.Width/2, owner.Y+owner.Height/2-0.5f),1.4f, 0.5f);
                sb.Draw(texture,
                    rectangle,
                    null,
                    Color.Black*0.4f,
                    rotation,
                    new Vector2(0.5f, 2.6f),
                    SpriteEffects.None,
                    0f);
            }
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

        //Addons
        public Umbrella umbrella;

        public Attachment standingChecker;

		public Player(){
			this.usePhysics = true;
			direction = Directions.RIGHT;
			state = playerStates.WAITING;

			boundingBox = new RectangleF (new Vector2 (0, 100 / 60f), CHAR_WIDTH, CHAR_HEIGHT);

            textureId = TextureManager.TextureID.player;

            standingChecker = new Attachment(LogicalObject.Treatment.standingCheck, this, 0, CHAR_HEIGHT*0.1f, CHAR_WIDTH, CHAR_HEIGHT*0.9f);

            umbrella = new Umbrella(this);
		}

        private void startJump(){
            jumpStartPos = boundingBox.y;
			boundingBox.y += JUMP_IMPULSE;
	        speed.Y += JUMP_TOP_SPEED;
			state = playerStates.JUMPING;
			setGroundedState (false);
			if (movingSpeed != 0) jumping_direction = direction;
			else jumping_direction = Directions.NONE;
        }

		private void startFall(){
			state = playerStates.FALLING;
			ControllerManager.TriggerJumping = false;
            if (speed.Y > 0) speed.Y = 0;
		}

		public override void Update(GameTime gameTime){
            umbrella.Update();

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
                    if (umbrella.open && umbrella.rotation > -0.4 && umbrella.rotation < 0.4){
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

		}

        public override void applyAtrict(float atrict, float airResistance) {
            float resistance = (grounded) ? atrict : airResistance;
			if (movingSpeed < resistance && movingSpeed > -resistance) movingSpeed = 0;
			else if (movingSpeed > 0) movingSpeed -= resistance;
			else movingSpeed += resistance;
            speed.X = movingSpeed;
        }

        public override void Draw(SpriteBatch sb, GameTime gameTime){
			if (direction == Directions.RIGHT) {
				sb.Draw (texture, DisplayManager.scaleTexture(Position, boundingBox.width, boundingBox.height), Color.White);
			} else {
				sb.Draw(texture, DisplayManager.scaleTexture(Position, boundingBox.width, boundingBox.height), null, Color.White, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
			}
            umbrella.draw(sb,gameTime);
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

