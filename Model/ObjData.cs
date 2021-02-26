using System;
using System.IO;

using RubiksChallenge.Geometry;

namespace RubiksChallenge.Model
{
    public class ObjData 
    {
        #region Constructor

        public ObjData(StreamReader reader)
        {
            this.Faces = null;
            var n = 0;
            var t = 0;
            var v = 0;
            var f = 0;
            
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                line = line.Replace(".", ",");
                if (line == null)
                    break;

                if (line.StartsWith("l"))
                {
                    var lengths = this.ReadLenghts(line);
                    this.verts = new Point3D[lengths[0]];
                    this.normals = new Point3D[lengths[1]];
                    this.texCoords = new Point2D[lengths[2]];
                    this.Faces = new Face[lengths[3]];
                }
                else if (line.StartsWith("vn"))
                {
                    var normal = this.ReadPoint3D(line);
                    this.normals[n++] = normal;
                }
                else if (line.StartsWith("vt"))
                {
                    var tex = this.ReadPoint2D(line);
                    this.texCoords[t++] = tex;
                }
                else if (line.StartsWith("v"))
                {
                    var vert = this.ReadPoint3D(line);
                    this.verts[v++] = vert;
                }
                else if (line.StartsWith("f"))
                {
                    var face = this.ReadFace(line);
                    this.Faces[f++] = face;
                }
            }
        }
        
        #endregion

        #region Private Fields

        private readonly Point3D[] verts;
        private readonly Point3D[] normals;
        private readonly Point2D[] texCoords;

        #endregion

        #region Attributes and Properties

        public Face[] Faces { get; }

        #endregion

        #region Private Methods

        private Face ReadFace(String line)
        {
            var readFace = line.Split(' ');
            var face = new Face(readFace.Length - 1);

            foreach (var readPoints in readFace)
            {
                if (string.Equals(readPoints, "f"))
                    continue;

                var points = readPoints.Split('/');
                var v = int.Parse(points[0]);
                var t = int.Parse(points[1]);
                var n = int.Parse(points[2]);

                face.AddPoint(verts[v - 1], texCoords[t - 1], normals[n - 1]);
            }

            return face;
        }

        private int[] ReadLenghts(String line)
        {
            line = line.Replace("l ", String.Empty);
            var lengths = line.Split('/');

            var v = int.Parse(lengths[0]);
            var vn = int.Parse(lengths[1]);
            var vt = int.Parse(lengths[2]);
            var f = int.Parse(lengths[3]);

            return new int[] { v, vn, vt, f };
        }

        private Point3D ReadPoint3D(String line)
        {
            var tuple3 = line.Split(' ');

            var x = float.Parse(tuple3[1]);
            var y = float.Parse(tuple3[2]);
            var z = float.Parse(tuple3[3]);

            return new Point3D(x, y, z);
        }

        private Point2D ReadPoint2D(String line)
        {
            var tuple2 = line.Split(' ');

            var x = float.Parse(tuple2[1]);
            var y = float.Parse(tuple2[2]);

            return new Point2D(x, y);
        }

        #endregion
    }
}
