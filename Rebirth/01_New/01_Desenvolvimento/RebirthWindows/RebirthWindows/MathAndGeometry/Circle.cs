namespace Rebirth{
    public class Circle: IShape{

        public bool intersects(Circle c){
            return true;
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
