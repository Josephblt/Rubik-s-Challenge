namespace RubiksChallenge.Geometry
{
    public class Position
    {
        #region Constructor

        public Position()
		{
            this.UpdatePosition();            
		}

        public Position(Point3D point)
        {
            this.UpdatePosition();
            this.Translate(point.X, point.Y, point.Z);
        }

        public Position(Matrix3D matrix)
        {
            this.TMatrix = matrix;
            this.UpdatePosition();
        }

        #endregion

        #region Attributes and Properties

        public Vector3D Axis { get; set; }
        public Point3D Location { get; set; }
        public float Rotation { get; set; }
        public Matrix3D TMatrix { get; private set; }
        public Matrix3D RMatrix { get; private set; }

        #endregion

        #region Private Fields

        private Quaternion quaternion;

        #endregion

        #region Private Methods

        private void UpdatePosition()
        {
            if (this.TMatrix == null)
                this.TMatrix = new Matrix3D();
            if (this.RMatrix == null)
                this.RMatrix = new Matrix3D();

            this.quaternion = Quaternion.FromTransform(this.RMatrix);
            this.quaternion.AxisAngle(out Vector3D axis, out float rotation);
            this.Axis = axis;
            this.Rotation = (float)Math3D.Deg(rotation);
            
            var loc = this.TMatrix.ExtractTranslation();            
            this.Location = new Point3D(loc.X, loc.Y, loc.Z);
        }

        #endregion

        #region Public Methods

        public Position Clone()
        {
            var matrix = new Matrix3D(this.TMatrix);
            return new Position(matrix);
        }

        public void Rotate(Vector3D rotationAxis, float rotationAngle)
        {
            this.RMatrix.Rotate(rotationAxis, (float)Math3D.Rad(rotationAngle));
            this.UpdatePosition();
        }

        public void RotateAndTranslate(Vector3D rotationAxis, float rotationAngle)
        {
            var origin = new Vector3D(this.Location.X, this.Location.Y, this.Location.Z);
            var destination = new Vector3D(this.Location.X, this.Location.Y, this.Location.Z);

            var matrix = new Matrix3D();
            matrix.Rotate(rotationAxis, -(float)Math3D.Rad(rotationAngle));
            destination.Transform(matrix);

            var translationVector = new Vector3D(destination.X - origin.X, 
                destination.Y - origin.Y,
                destination.Z - origin.Z);
            
            this.TMatrix.Translate(translationVector);            
            this.RMatrix.Rotate(rotationAxis, (float)Math3D.Rad(rotationAngle));
            
            this.UpdatePosition();
        }

        public void Translate(float x, float y, float z)
        {
            this.TMatrix.Translate(x, y, z);
            this.UpdatePosition();
        }        

        #endregion
    }
}
