﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rebirth {
    public static class Enumerations {

#if EDITOR
        public enum ObjectTypes{
            Box,
            Ground,
            Logical,
            Trigger,
            TextureLoader
        }
#endif

    }
}
