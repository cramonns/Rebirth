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
    }
}
