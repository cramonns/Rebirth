using Microsoft.Xna.Framework;
using System;

namespace Rebirth{
    public class Circle: IShape{

        public Vector2 Center;
        public float Radius;

        public bool intersects(Circle c){
            float distance = (float)Math.Sqrt(
                Math.Pow((double)(this.Center.X-c.Center.X), 2.0)
                +Math.Pow((double)(this.Center.Y-c.Center.Y),2.0));
            return MathUtils.FLOAT_GREATEQ(this.Radius+c.Radius, distance);
        }

        public bool intersects(IShape shape){
            if (shape is RectangleF){
                return (shape as RectangleF).intersects(this);
            }
            else if (shape is Circle){
                return intersects(shape as Circle);
            }
            return false;
        }

    }
}
