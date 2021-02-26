using System;
using System.Diagnostics;

namespace RubiksChallenge.Geometry
{

    public struct Quaternion
    {
        #region Constructor

        public Quaternion(float x, float y, float z, float w)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.W = w;
        }

        #endregion

        #region Attributes and Properties

        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float W { get; set; }

        public float this[int index]
        {
            get
            {
                if (index <= 1)
                {
                    if (index == 0)
                        return this.X;
                    return this.Y;
                }

                if (index == 2)
                    return this.Z;
                
                return this.W;
            }
            set
            {
                if (index <= 1)
                    if (index == 0)
                        this.X = value;
                    else
                        this.Y = value;
                else
                    if (index == 2)
                        this.Z = value;
                    else
                        this.W = value;
            }
        }

        #endregion

        #region Public Methods

        public void AxisAngle(out Vector3D axis, out float radians)
        {
            radians = (float)Math.Acos(this.W);
            
            if ((radians != 0) & (!float.IsNaN(radians)))
            {
                axis = new Vector3D(this.X, this.Y, this.Z);
                axis /= (float)Math.Sin(radians);
                axis.Normalize();
                radians *= 2;
            }
            else
            {
                radians = 0.0f;
                axis = new Vector3D(1f, 0f, 0f);
            }
        }

        #endregion

        #region Static Methods

        public static Quaternion FromAxisAngle(Vector3D axis, float radians)
        {
            axis.Normalize();
            var scaledAxis = axis * (float)Math.Sin(radians * 0.5f);
            return new Quaternion(scaledAxis.X, scaledAxis.Y, scaledAxis.Z, (float)Math.Cos(radians * 0.5f));
        }

        public static Quaternion FromTransform(Matrix3D transform)
        {
            var quat = new Quaternion();

            var tr = transform[0, 0] + transform[1, 1] + transform[2, 2];
            if (tr > 0.0f)
            {
                var s = (float)Math.Sqrt(tr + 1.0f);
                quat.W = s * 0.5f;
                s = 0.5f / s;
                quat.X = (transform[1, 2] - transform[2, 1]) * s;
                quat.Y = (transform[2, 0] - transform[0, 2]) * s;
                quat.Z = (transform[0, 1] - transform[1, 0]) * s;
            }
            else
            {
                var nIndex = new int[] { 1, 2, 0 };
                int i, j, k;
                i = 0;
                if (transform[1, 1] > transform[i, i])
                    i = 1;
                if (transform[2, 2] > transform[i, i])
                    i = 2;
                j = nIndex[i];
                k = nIndex[j];

                var s = (float)Math.Sqrt((transform[i, i] - (transform[j, j] + transform[k, k])) + 1.0f);
                quat[i] = s * 0.5f;
                if (s != 0.0)
                {
                    s = 0.5f / s;
                }
                quat[j] = (transform[i, j] + transform[j, i]) * s;
                quat[k] = (transform[i, k] + transform[k, i]) * s;
                quat[3] = (transform[j, k] - transform[k, j]) * s;
            }
            return quat;
        }

        #endregion
    }
}
