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
            Trigger,
            TextureLoader,
            Canon
        }
#endif

        public enum Seasons{
            Winter,
            Spring,
            Summer,
            Autumn
        }

        public enum Weather{
            Sunshine,
            Rain,
            Cloudy,
            Snow
        }

    }
}
