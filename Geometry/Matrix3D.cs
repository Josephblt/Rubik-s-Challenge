using System;
using System.Diagnostics;

namespace RubiksChallenge.Geometry
{
    public class Matrix3D
    {
        #region Constructor

        public Matrix3D()
        {
            elements[0] = 1;
            elements[1] = 0;
            elements[2] = 0;
            elements[3] = 0;
            elements[4] = 0;
            elements[5] = 1;
            elements[6] = 0;
            elements[7] = 0;
            elements[8] = 0;
            elements[9] = 0;
            elements[10] = 1;
            elements[11] = 0;
            elements[12] = 0;
            elements[13] = 0;
            elements[14] = 0;
            elements[15] = 1;
        }

        public Matrix3D(Matrix3D matrix)
        {
            matrix.elements.CopyTo(elements, 0);
        }

        #endregion

        #region Private Fields

        private readonly float[] elements = new float[16];

        #endregion

        #region Attributes and Properties

        public float this[int index]
        {
            get
            {
                return elements[index];
            }
            set
            {
                elements[index] = value;
            }
        }

        public float this[int column, int row]
        {
            get
            {
                return elements[column + row * 4];
            }
            set
            {
                elements[column + row * 4] = value;
            }
        }

        #endregion

        #region Public Methods

        public Vector3D ExtractTranslation()
        {
            return new Vector3D(elements[12], elements[13], elements[14]);
        }

        public void Invert()
        {
            double[] matrix = Utils.Create_m4();
            double[] matrixInverse = Utils.Create_m4();

            Utils.Transform_2_m4(this, matrix);
            Utils.M4_inverse(matrixInverse, matrix);
            Utils.M4_2_transform(matrixInverse, this);
        }

        public void Rotate(Vector3D axis, float radians)
        {
            Rotate(Quaternion.FromAxisAngle(axis, radians));
        }

        public void Rotate(Quaternion quat)
        {
            Matrix3D mTemp = Matrix3D.FromMultiplication(this, Matrix3D.FromRotation(quat));
            mTemp.elements.CopyTo(this.elements, 0);
        }

        public void Translate(float x, float y, float z)
        {
            elements[12] = elements[0] * x + elements[4] * y + elements[8] * z + elements[12];
            elements[13] = elements[1] * x + elements[5] * y + elements[9] * z + elements[13];
            elements[14] = elements[2] * x + elements[6] * y + elements[10] * z + elements[14];
        }

        public void Translate(Vector3D pt)
        {
            Translate(pt.X, pt.Y, pt.Z);
        }

        #endregion

        #region Static Methods

        public static Matrix3D FromRotation(Quaternion quarternion)
        {
            var matrix = new Matrix3D();

            float x2 = quarternion.X + quarternion.X, y2 = quarternion.Y + quarternion.Y, z2 = quarternion.Z + quarternion.Z;
            float xx = quarternion.X * x2, xy = quarternion.X * y2, xz = quarternion.X * z2;
            float yy = quarternion.Y * y2, yz = quarternion.Y * z2, zz = quarternion.Z * z2;
            float wx = quarternion.W * x2, wy = quarternion.W * y2, wz = quarternion.W * z2;

            var elements = matrix.elements;
            elements[3] = elements[7] = elements[11] = elements[12] = elements[13] = elements[14] = 0; elements[15] = 1;
            elements[0] = 1 - (yy + zz); elements[4] = xy + wz; elements[8] = xz - wy;
            elements[1] = xy - wz; elements[5] = 1 - (xx + zz); elements[9] = yz + wx;
            elements[2] = xz + wy; elements[6] = yz - wx; elements[10] = 1 - (xx + yy);
            return matrix;
        }

        public static Matrix3D FromMultiplication(Matrix3D m0, Matrix3D m1)
        {
            var mResult = new Matrix3D();

            var e0 = m0.elements;
            var e1 = m1.elements;
            var result = mResult.elements;

            result[0] = e0[0] * e1[0] + e0[4] * e1[1] + e0[8] * e1[2];
            result[4] = e0[0] * e1[4] + e0[4] * e1[5] + e0[8] * e1[6];
            result[8] = e0[0] * e1[8] + e0[4] * e1[9] + e0[8] * e1[10];
            result[12] = e0[0] * e1[12] + e0[4] * e1[13] + e0[8] * e1[14] + e0[12];

            result[1] = e0[1] * e1[0] + e0[5] * e1[1] + e0[9] * e1[2];
            result[5] = e0[1] * e1[4] + e0[5] * e1[5] + e0[9] * e1[6];
            result[9] = e0[1] * e1[8] + e0[5] * e1[9] + e0[9] * e1[10];
            result[13] = e0[1] * e1[12] + e0[5] * e1[13] + e0[9] * e1[14] + e0[13];

            result[2] = e0[2] * e1[0] + e0[6] * e1[1] + e0[10] * e1[2];
            result[6] = e0[2] * e1[4] + e0[6] * e1[5] + e0[10] * e1[6];
            result[10] = e0[2] * e1[8] + e0[6] * e1[9] + e0[10] * e1[10];
            result[14] = e0[2] * e1[12] + e0[6] * e1[13] + e0[10] * e1[14] + e0[14];

            result[3] = 0;
            result[7] = 0;
            result[11] = 0;
            result[15] = 1;

            return mResult;
        }
        
        #endregion

        internal class Utils
        {
            static public double[] Create_m3()
            {
                var m = new double[9];
                M3_identity(m);
                return m;
            }

            static public double[] Create_m4()
            {
                var m = new double[16];
                M4_identity(m);
                return m;
            }

            static public void M3_identity(double[] m)
            {
                m[0] = m[4] = m[8] = 1;
                m[1] = m[2] = m[3] = m[5] = m[6] = m[7] = 0;
            }

            static public void M4_identity(double[] m)
            {
                m[0] = m[5] = m[10] = m[15] = 1;
                m[1] = m[2] = m[3] = m[4] = m[6] = m[7] = m[8] = m[9] = m[11] = m[12] = m[13] = m[14] = 0;
            }

            static public double M3_det(double[] mat)
            {
                return mat[0] * (mat[4] * mat[8] - mat[7] * mat[5])
                    - mat[1] * (mat[3] * mat[8] - mat[6] * mat[5])
                    + mat[2] * (mat[3] * mat[7] - mat[6] * mat[4]);
            }

            static public void M4_submat(double[] mr, double[] mb, int i, int j)
            {
                for (var di = 0; di < 3; di++)
                    for (var dj = 0; dj < 3; dj++)
                    {
                        int si = di + ((di >= i) ? 1 : 0);
                        int sj = dj + ((dj >= j) ? 1 : 0);
                        mb[di * 3 + dj] = mr[si * 4 + sj];
                    }
            }

            static public double M4_det(double[] mr)
            {
                double det, result = 0, i = 1;
                double[] msub3 = Create_m3();
                int n;

                for (n = 0; n < 4; n++, i *= -1)
                {
                    M4_submat(mr, msub3, 0, n);
                    det = M3_det(msub3);
                    result += mr[n] * det * i;
                }

                return result;
            }

            static public void Transform_2_m4(Matrix3D m, double[] mx)
            {
                for (var i = 0; i < 4; i++)
                    for (var j = 0; j < 4; j++)
                    {
                        mx[i * 4 + j] = m[i + j * 4];
                    }
            }

            static public void M4_2_transform(double[] mx, Matrix3D m)
            {
                for (var i = 0; i < 4; i++)
                    for (var j = 0; j < 4; j++)
                    {
                        m[i + j * 4] = (float)mx[i * 4 + j];
                    }
            }

            static public int M4_inverse(double[] mr, double[] ma)
            {
                double mdet = M4_det(ma);
                double[] mtemp = Create_m3();
                int i, j, sign;

                if (Math.Abs(mdet) < 0.000005)
                    return 0;

                for (i = 0; i < 4; i++)
                    for (j = 0; j < 4; j++)
                    {
                        sign = (((i + j) % 2) == 0) ? 1 : -1;
                        M4_submat(ma, mtemp, i, j);
                        mr[i + j * 4] = (M3_det(mtemp) * sign) / mdet;
                    }

                return (1);
            }
        }
    }
}