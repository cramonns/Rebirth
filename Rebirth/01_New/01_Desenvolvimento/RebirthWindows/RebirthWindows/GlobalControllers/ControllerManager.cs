using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Rebirth{

	public enum TriggerDirection:byte{
		None,
		Right,
		Left
	};

	public static class ControllerManager{

        private static float analogDeadzone = 0.5f; 

		public static bool TriggerJumping = false;
		private static bool prev_SpacePressed;

        public static bool TriggerFloating = false;

		public static TriggerDirection direction = TriggerDirection.None;

        public static bool TriggerDown = false;

        public static bool TriggerStart = false;
        private static bool prev_StartPressed;

        public static bool rightAnalogWaiting = true;
        public static float rightAnalogRotation;

        private static double rightAnalogRestingTimeElapsed;

        public static bool increaseRotation;
        public static bool decreaseRotation;

        public static bool TriggerDrop = false;
        private static bool prev_dropPressed;


#if DEV
        private static bool prev_TPressed = false;
#endif

		public static void Update(GameTime gameTime){

#if DEV
            float multiplier;
            if (Keyboard.GetState().IsKeyDown(Keys.LeftShift) || Keyboard.GetState().IsKeyDown(Keys.RightShift)){
                multiplier = .005f;
            }
            else multiplier = 0.05f;
            if (Keyboard.GetState().IsKeyDown(Keys.OemMinus)){
                DisplayManager.WorldWidth *= (1f + multiplier);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.OemPlus)){
                DisplayManager.WorldWidth *= (1f - multiplier);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.T)){
                if (!prev_TPressed){
                    DeveloperSettings.drawTriggers = !DeveloperSettings.drawTriggers;
                }
                prev_TPressed = true;
            }
            else prev_TPressed = false;
#endif

            

			if (Keyboard.GetState().IsKeyDown(Keys.Right) || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X > analogDeadzone) {
				direction = TriggerDirection.Right;
			} else if (Keyboard.GetState().IsKeyDown(Keys.Left) || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X < -analogDeadzone) {
				direction = TriggerDirection.Left;
			} else direction = TriggerDirection.None; //IMPROVE THIS CODE

            TriggerDown = false;
            if (Keyboard.GetState().IsKeyDown(Keys.Down) || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y < -analogDeadzone){
                TriggerDown = true;
            }

            TriggerFloating = false;
            if (Keyboard.GetState().IsKeyDown(Keys.Space) || GamePad.GetState(PlayerIndex.One).Triggers.Right > 0.5){
                TriggerFloating = true;
            }

			if (Keyboard.GetState().IsKeyDown(Keys.Up) || GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed || GamePad.GetState(PlayerIndex.One).Buttons.RightShoulder == ButtonState.Pressed) {
				if (!prev_SpacePressed)	TriggerJumping = true;
				prev_SpacePressed = true;
			} else
			    if (Keyboard.GetState().IsKeyUp(Keys.Up) && GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Released) {
				    TriggerJumping = false;
				    prev_SpacePressed = false;
			    }

            if (Keyboard.GetState().IsKeyDown(Keys.RightShift) || GamePad.GetState(PlayerIndex.One).Buttons.LeftShoulder == ButtonState.Pressed){
                if (!prev_dropPressed) TriggerDrop = true;
                prev_dropPressed = true;
            } else
                if (Keyboard.GetState().IsKeyUp(Keys.RightShift) && GamePad.GetState(PlayerIndex.One).Buttons.LeftShoulder == ButtonState.Released){
                    TriggerDrop = false;
                    prev_dropPressed = false;
                }

            TriggerStart = false;
            if (Keyboard.GetState().IsKeyDown(Keys.Enter) || GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Pressed) {
				if (!prev_StartPressed)	TriggerStart = true;
				prev_SpacePressed = true;
			}
			if (Keyboard.GetState().IsKeyUp(Keys.Enter) && GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Released) {
				prev_StartPressed = false;
			}

            increaseRotation = false;
            decreaseRotation = false;
            float rightAnalogX = GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.X; 
            float rightAnalogY = GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.Y;
            if (rightAnalogX > analogDeadzone || rightAnalogX < -analogDeadzone || rightAnalogY > analogDeadzone || rightAnalogY < -analogDeadzone){
                rightAnalogRestingTimeElapsed = 0;
                rightAnalogWaiting = false;
                rightAnalogRotation = (float)Math.Atan2(rightAnalogX, rightAnalogY);
            }
            else {
                if (rightAnalogRestingTimeElapsed < 500) 
                    rightAnalogRestingTimeElapsed += gameTime.ElapsedGameTime.Milliseconds;
                else {
                    if (Keyboard.GetState().IsKeyDown(Keys.E)){
                        increaseRotation = true;
                    }
                    else if (Keyboard.GetState().IsKeyDown(Keys.Q)){
                        decreaseRotation = true;
                    }
                    rightAnalogWaiting = true;
                }
            }
#if EDITOR
            if (!GameManager.globalVariables.editorMode)
#endif
            MouseManager.Update();
            
		}
	}
}

