using UnityEngine;

namespace GlobalVars
{
    public class GlobalVariables
    {
        public const string HorizontalAxis = "Horizontal";
        public const string VerticalAxis = "Vertical";
        public const string JumpButton = "Jump"; 

        public const string LeftMouseButton = "Fire1";
        public const string MiddleMouseButton = "Fire3";
        public const string RightMouseButton = "Fire2";

        public const string MouseX = "Mouse X";
        public const string MouseY = "Mouse Y";

        public const string MouseScrollWheel = "Mouse ScrollWheel";

        public static Vector3 MinScaleSph = new Vector3(1.0f, 1.0f, 1.0f);
        public static Vector3 MidScaleSph = new Vector3(3.0f, 3.0f, 3.0f);
        public static Vector3 MaxScaleSph = new Vector3(9.0f, 9.0f, 9.0f);

        public static float MinWeightSph = 10f;
        public static float MaxWeightSph = 350.0f;

        public static float KoefSpeedFromScale = 4.0f;
        
        public static float KoefWeightFromScale()
        {
            float stepScrollWheel = 0.5f;
            
            return MaxWeightSph - MinWeightSph / ((MaxScaleSph.y - MidScaleSph.y) / stepScrollWheel);
        }
    }
}