using System;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework; 

namespace Rebirth {
    public static class MathUtils {

        private const float epsilon = 1E-5f;

        public static bool FLOAT_LESSEQ(float a, float b){
            return (a < b + epsilon);
        }

        public static bool FLOAT_GREATEQ(float a, float b){
            return (a > b - epsilon);
        }

        public static bool FLOAT_EQUALS(float a, float b){
            return (a > b - epsilon && a < b + epsilon);
        }

    }
}
