namespace RubiksChallenge.Geometry
{
    public class Face
    {
        #region Constructor

        public Face(int points)
        {
            Vertex = new Point3D[points];
            Normal = new Point3D[points];
            TexCoord = new Point2D[points];
        }

        #endregion        

        #region Private Fields

        private int points;

        #endregion

        #region Attributes and Properties

        public Point3D[] Vertex { get; }

        public Point3D[] Normal { get; }

        public Point2D[] TexCoord { get; }

        #endregion

        #region Public Methods

        public void AddPoint(Point3D vert, Point2D tex, Point3D norm)
        {
            this.Vertex[points] = vert;
            this.TexCoord[points] = tex;
            this.Normal[points] = norm;
            points++;
        }
        
        #endregion
    }
}
