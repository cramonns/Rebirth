using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content; 

namespace Rebirth{

	public class Player:Character{

		private enum playerStates:byte{
			WAITING,
			MOVING,
			JUMPING,
			FALLING
		};

		const float MOVING_TOP_SPEED = 6f/60f;
		const float MOVING_ACCELERATION = .8f/60f;
		const float JUMP_MOVING_ACCELERATION = .1f/60f;
		const float ATRITO = .5f/60f;
		const float JUMP_IMPULSE = 15f/60f;
		const float JUMP_ACCLERATION = 1.3f/60f;
		const float JUMP_TOP_HIGH = 180f/60f;
		const float JUMP_TOP_SPEED = 6f/60f;
		const float AIR_RESISTANCE = 0.05f/60f;
		const float CHAR_WIDTH = .6f;
		const float CHAR_HEIGHT = 1.4f;

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

			/*this.position = new Vector2(0, 50f/60f);
			width = CHAR_WIDTH;
			height = CHAR_HEIGHT;*/
			shape = new RectangleF (new Vector2 (0, 50f / 60f), CHAR_WIDTH, CHAR_HEIGHT);



			createDefaultBounds();

		}

		private void startFall(){
			state = playerStates.FALLING;
			ControllerManager.TriggerJumping = false;
		}

		public override void Update(){
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
				else movingSpeed += MOVING_ACCELERATION;
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
				else movingSpeed -= MOVING_ACCELERATION;
				if (movingSpeed < -MOVING_TOP_SPEED)
					movingSpeed = -MOVING_TOP_SPEED;
			}
					
			//Jumping
			if (ControllerManager.TriggerJumping) {
				if (state != playerStates.JUMPING && state != playerStates.FALLING) {
					jumpStartPos = shape.y;
					shape.y += JUMP_IMPULSE;
					speed.Y += JUMP_ACCLERATION;
					state = playerStates.JUMPING;
					if (movingSpeed != 0) jumping_direction = direction;
					else jumping_direction = 'n';
				} else if (state == playerStates.JUMPING) {
					if (shape.y - jumpStartPos >= JUMP_TOP_HIGH) {
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

			//Atrito
			float resistance = (state == playerStates.JUMPING || state == playerStates.FALLING) ? AIR_RESISTANCE : ATRITO;
			if (movingSpeed < resistance && movingSpeed > -resistance) movingSpeed = 0;
			else if (movingSpeed > 0) movingSpeed -= resistance;
			else movingSpeed += resistance;

			speed.X = movingSpeed;

			//Update position after all movement is computed
			shape.x += speed.X;
			shape.y += speed.Y;
		}

		Vector2 position(){
			return new Vector2 (shape.x, shape.y);
		}

		public override void Draw(SpriteBatch sb, ScreenManager sm){
			if (direction == 'r') {
				sb.Draw (texture, sm.scaleTexture(this.position(), CHAR_WIDTH, CHAR_HEIGHT), Color.Red);
			} else {
				sb.Draw(texture, sm.scaleTexture(this.position(), CHAR_WIDTH, CHAR_HEIGHT), null, Color.Red, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
			}
		}

		public override void Load(ContentManager Content){
			texture = Content.Load<Texture2D>("Textures/red");
			loaded = true;
		}

		public override bool isGrounded (){
			if (shape.y <= 50f/60f) {
				shape.y = 50f/60f;
				state = playerStates.WAITING;
				return true;
			} else return false;
		}

		public override void collide(GameObject b){

			VertexR c1 = this.shape.getCenter();
			VertexR c2 = b.shape.getCenter();

			c1.x -= shape.x;
			c2.x -= shape.x;
			c1.y -= shape.y;
			c2.y -= shape.y;

			if (colliders[(int)Bounds.EASTER].shape.intersects(c1, c2)) {

				shape.x = 0;

				//foreach (GameObject g in colliders[(int)Bounds.EASTER].currentCollisions){
				//if (shape.x + shape.width > b.shape.x) shape.x = b.shape.x - shape.width;
				//}
			}

			/*
			if (colliders[(int)Bounds.LOWER].currentCollisions.Count != 0) {
				foreach (GameObject g in colliders[(int)Bounds.LOWER].currentCollisions){
					if (position.Y < g.position.Y + g.height) {
						position.Y = g.position.Y + g.height;
					}
				}
			}
			if (colliders[(int)Bounds.WESTERN].currentCollisions.Count != 0) {
				foreach (GameObject g in colliders[(int)Bounds.WESTERN].currentCollisions){
					if (position.X < g.position.X + g.width) position.X = g.position.X + g.width;
				}
			}*/
		}
	}
}

