using System;

namespace RubiksChallenge.Geometry
{
    public static class Math3D
    {
        #region Constants

        public const double PI = Math.PI;
        public const double PI2 = Math.PI * 2;
        public const float EpsilonF = 1.0e-03F;

        #endregion

        #region Static Methods

        public static double Rad(double deg)
        {
            return deg * Math.PI / 180d;
        }

        public static double Deg(double rad)
        {
            return rad * 180d / Math.PI;
        }

        public static bool FloatComparison(float float1, float float2, float precision)
        {
            return (((float1 >= (float2 - precision)) &&
                     (float1 <= (float2 + precision))) ||
                    ((float2 >= (float1 - precision)) &&
                     (float2 <= (float1 + precision))));
        }

        #endregion
    }
}
