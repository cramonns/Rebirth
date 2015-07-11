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

		public static void Update(GameTime gameTime){

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

			if (Keyboard.GetState().IsKeyDown(Keys.Up) || GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed) {
				if (!prev_SpacePressed)	TriggerJumping = true;
				prev_SpacePressed = true;
			} else
			    if (Keyboard.GetState().IsKeyUp(Keys.Up) && GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Released) {
				    TriggerJumping = false;
				    prev_SpacePressed = false;
			    }

            TriggerStart = false;
            if (Keyboard.GetState().IsKeyDown(Keys.Enter) || GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Pressed) {
				if (!prev_StartPressed)	TriggerStart = true;
				prev_SpacePressed = true;
			}
			if (Keyboard.GetState().IsKeyUp(Keys.Enter) && GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Released) {
				prev_StartPressed = false;
			}
		}
	}
}

