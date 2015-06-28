using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rebirth {
    public class Trigger:LogicalObject {
        
        protected collisionHandler onEnter;
        protected collisionHandler onLeave;

        public Trigger(Treatment collidingTreatment, Treatment enterTreatment, Treatment leaveTreatment):base(collidingTreatment){
            switch (enterTreatment){
                
            }
            switch (leaveTreatment){
                
            }
        }

    }
}
