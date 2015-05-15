using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content; 

namespace Rebirth{

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

		const float MOVING_TOP_SPEED = 6f/60f;
        const float CROUCHING_TOP_SPEED = 3.6f/60f;
		const float MOVING_ACCELERATION = .8f/60f;
		const float JUMP_MOVING_ACCELERATION = .1f/60f;
		const float JUMP_IMPULSE = 15f/60f;
		const float JUMP_ACCLERATION = 1.3f/60f;
		const float JUMP_TOP_HIGH = 180f/60f;
		const float JUMP_TOP_SPEED = 6f/60f;
		const float CHAR_WIDTH = .6f;
		const float CHAR_HEIGHT = 1.4f;
        const float FLOATING_MAX_FALLING_SPEED = 3f/60f;

		playerStates state;

		//Player Attributes
		float movingSpeed;
		char direction;
		char jumping_direction;

		//support variables
		float jumpStartPos;

		public Player(){
			this.usePhysics = true;
			direction = 'r';
			state = playerStates.WAITING;

			boundingBox = new RectangleF (new Vector2 (0, 100 / 60f), CHAR_WIDTH, CHAR_HEIGHT);

			createDefaultBounds();

            textureId = TextureManager.TextureID.player;

		}

		private void startFall(){
			state = playerStates.FALLING;
			ControllerManager.TriggerJumping = false;
		}

		public override void Update(GameTime gameTime){
			//updateBounds();

            if (state == playerStates.FLOATING) state = playerStates.FALLING;

			//Movement
			if (ControllerManager.direction == TriggerDirection.Right) {
				direction = 'r';
				if (state == playerStates.JUMPING) {
					movingSpeed += JUMP_MOVING_ACCELERATION;
					if (jumping_direction == 'l' && movingSpeed > 0) {
						startFall();
					}
				}
				else if (state == playerStates.FALLING) {
					movingSpeed += JUMP_MOVING_ACCELERATION;
				}
				else {
                    movingSpeed += MOVING_ACCELERATION;
                    state = playerStates.MOVING;
                }
				if (movingSpeed > MOVING_TOP_SPEED)
					movingSpeed = MOVING_TOP_SPEED;
			} else if (ControllerManager.direction == TriggerDirection.Left) {
				direction = 'l';
				if (state == playerStates.JUMPING) {
					movingSpeed -= JUMP_MOVING_ACCELERATION;
					if (jumping_direction == 'r' && movingSpeed < 0) startFall(); 
				}
				else if (state == playerStates.FALLING) {
					movingSpeed -= JUMP_MOVING_ACCELERATION;
				}
				else {
                    movingSpeed -= MOVING_ACCELERATION;
                    state = playerStates.MOVING;
                }
				if (movingSpeed < -MOVING_TOP_SPEED)
					movingSpeed = -MOVING_TOP_SPEED;
			}
					
			//Jumping
			if (ControllerManager.TriggerJumping) {
				if (state != playerStates.JUMPING && state != playerStates.FALLING) {
					jumpStartPos = boundingBox.y;
					boundingBox.y += JUMP_IMPULSE;
					speed.Y += JUMP_ACCLERATION;
					state = playerStates.JUMPING;
					setGroundedState (false);
					if (movingSpeed != 0) jumping_direction = direction;
					else jumping_direction = 'n';
				} else if (state == playerStates.JUMPING) {
					if (boundingBox.y - jumpStartPos >= JUMP_TOP_HIGH) {
						startFall();
					} else if (speed.Y > JUMP_TOP_HIGH/2) {
						speed.Y -= JUMP_ACCLERATION/2;
					} else speed.Y += JUMP_ACCLERATION;
					if (speed.Y > JUMP_TOP_SPEED) {
						speed.Y = JUMP_TOP_SPEED;
					} else if (speed.Y > JUMP_TOP_SPEED/2){
						speed.Y -= JUMP_ACCLERATION / 2;
					}
				}
			} else if (!isGrounded()) {
				if (speed.Y > 0) speed.Y = 0;
				startFall();
			}
            //Crouching
            else if (ControllerManager.TriggerDown){
                if (state == playerStates.WAITING) state = playerStates.DUCKING;
                else {
                    state = playerStates.CROUCHING;              
                    
                    if (movingSpeed > CROUCHING_TOP_SPEED) movingSpeed = CROUCHING_TOP_SPEED;
                    else if (movingSpeed < -CROUCHING_TOP_SPEED) movingSpeed = -CROUCHING_TOP_SPEED;
                }
                boundingBox.height = CHAR_HEIGHT*0.6f;
                boundingBox.width = CHAR_WIDTH*1.2f;
            }
            else {
                boundingBox.height = CHAR_HEIGHT;
                boundingBox.width = CHAR_WIDTH;
            }

            //Floating
            if (ControllerManager.TriggerFloating){
                if (state == playerStates.FALLING){
                    state = playerStates.FLOATING;
                    if (speed.Y < -FLOATING_MAX_FALLING_SPEED) speed.Y = -FLOATING_MAX_FALLING_SPEED;
                }
            }

		}

        public override void applyAtrict(float atrict, float airResistance) {
            float resistance = (grounded) ? atrict : airResistance;
			if (movingSpeed < resistance && movingSpeed > -resistance) movingSpeed = 0;
			else if (movingSpeed > 0) movingSpeed -= resistance;
			else movingSpeed += resistance;
            speed.X = movingSpeed;
        }

        public override void Draw(SpriteBatch sb, GameTime gameTime){
			if (direction == 'r') {
				sb.Draw (texture, DisplayManager.scaleTexture(Position, boundingBox.width, boundingBox.height), Color.White);
			} else {
				sb.Draw(texture, DisplayManager.scaleTexture(Position, boundingBox.width, boundingBox.height), null, Color.White, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
			}
		}

		public override void setGroundedState(bool newState){
			base.setGroundedState (newState);
			if (newState) this.state = playerStates.WAITING;
			else if (this.state != playerStates.JUMPING) startFall();
		}

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

