using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rebirth {
    public interface IShape {

        bool intersects(IShape shape);

    }
}
