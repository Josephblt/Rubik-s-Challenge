namespace RubiksChallenge.Geometry
{
    public class Point2D
    {
        #region Constructor

        public Point2D(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        #endregion

        #region Attributes and Properties

        public float X { get; set; }
        public float Y { get; set; }

        #endregion        
    }
}
