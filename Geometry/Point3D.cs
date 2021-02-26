namespace RubiksChallenge.Geometry
{
    public class Point3D
    {
        #region Constructor

		public Point3D(float x, float y, float z)
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
    }	
}