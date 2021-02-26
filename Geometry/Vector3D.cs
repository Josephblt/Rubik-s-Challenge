using System;

namespace RubiksChallenge.Geometry
{
    public struct Vector3D
    {
        #region Constructor

        public Vector3D(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        #endregion

        #region Attributes and Properties

        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        #endregion

        #region Public Methods

        public float Magnitude()
        {
            return (float)Math.Sqrt(X * X + Y * Y + Z * Z);
        }

        public void Normalize()
        {
            var length = Magnitude();
            if (length == 0)
                return;
            this.X = X / length;
            this.Y = Y / length;
            this.Z = Z / length;
        }

        public void Transform(Matrix3D transform)
        {
            float x = X, y = Y, z = Z;
            X = x * transform[0] + y * transform[4] + z * transform[8] + transform[12];
            Y = x * transform[1] + y * transform[5] + z * transform[9] + transform[13];
            Z = x * transform[2] + y * transform[6] + z * transform[10] + transform[14];
        }
        
        public void Multiply(float multiplier)
        {
            this.X *= multiplier;
            this.Y *= multiplier;
            this.Z *= multiplier;
        }

        #endregion

        #region Static Methods

        public static Vector3D CrossProduct(Vector3D a, Vector3D b)
        {
            float x0 = a.X, y0 = a.Y, z0 = a.Z;
            float x1 = b.X, y1 = b.Y, z1 = b.Z;
            return new Vector3D(y0 * z1 - z0 * y1, z0 * x1 - x0 * z1, x0 * y1 - y0 * x1);
        }

        public static Vector3D operator *(Vector3D vec, float f)
        {
            return new Vector3D(vec.X * f, vec.Y * f, vec.Z * f);
        }
        
        public static Vector3D operator /(Vector3D vec, float f)
        {
            return new Vector3D(vec.X / f, vec.Y / f, vec.Z / f);
        }

        #endregion
    }
}
