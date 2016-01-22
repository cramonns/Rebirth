using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rebirth {
    [Serializable]
    public class GlobalVariables {

#if EDITOR
        [NonSerialized]
        public bool editorMode = false;
#endif
        public bool overUmbrella = false;
        public DroppedUmbrella droppedUmbrella = null;
        public Enumerations.Seasons currentSeason = Enumerations.Seasons.Spring;
        public bool sunglassesOn = false;
    }
}
