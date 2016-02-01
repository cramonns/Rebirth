using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Rebirth{

	public enum TriggerDirection{
		none,
		Right,
		Left
	};

	public static class ControllerManager{

		public static bool TriggerJumping = false;

		private static bool prev_SpacePressed;

		public static TriggerDirection direction = TriggerDirection.none; 

		public static void Update(){

			if (Keyboard.GetState().IsKeyDown(Keys.Right) || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X > 0.5) {
				direction = TriggerDirection.Right;
			} else if (Keyboard.GetState().IsKeyDown(Keys.Left) || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X < -0.5) {
				direction = TriggerDirection.Left;
			} else direction = TriggerDirection.none; //IMPROVE THIS CODE

			if (Keyboard.GetState().IsKeyDown(Keys.Space) || GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed) {
				if (!prev_SpacePressed)	TriggerJumping = true;
				prev_SpacePressed = true;
			}
			if (Keyboard.GetState().IsKeyUp(Keys.Space) && GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Released) {
				TriggerJumping = false;
				prev_SpacePressed = false;
			}
		}
	}
}

