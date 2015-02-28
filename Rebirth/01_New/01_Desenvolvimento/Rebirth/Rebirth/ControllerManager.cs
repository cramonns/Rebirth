using System;
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
			if (Keyboard.GetState().IsKeyDown(Keys.Right)) {
				direction = TriggerDirection.Right;
			} else if (Keyboard.GetState().IsKeyDown(Keys.Left)) {
				direction = TriggerDirection.Left;
			} else direction = TriggerDirection.none; //IMPROVE THIS CODE

			if (Keyboard.GetState().IsKeyDown(Keys.Space)) {
				if (!prev_SpacePressed)	TriggerJumping = true;
				prev_SpacePressed = true;
			}
			if (Keyboard.GetState().IsKeyUp(Keys.Space)) {
				TriggerJumping = false;
				prev_SpacePressed = false;
			}
		}
	}
}

