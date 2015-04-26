using System;
using Microsoft.Xna.Framework;

namespace Rebirth{

	public static class GeometryUtils{

		public static Vector2 majorAxix (Vector2 vector){
			if ( Math.Abs(vector.X) > Math.Abs(vector.Y) ){
				return new Vector2(vector.X, 0);
			}
			else {
				return new Vector2(0, vector.Y);
			}
		}

	}
}

