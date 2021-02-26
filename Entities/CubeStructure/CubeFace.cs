using RubiksChallenge.Geometry;
using RubiksChallenge.Model;

namespace RubiksChallenge.Entities.CubeStructure
{
    public class CubeFace : AbstractEntity
    {
        #region Constructor

        public CubeFace(Colors color)
            : base(resourceName, color)
        {
            var rotationAngle = 90.0f;

            switch (color)
            {
                case Colors.Blue:
                    this.Position = new Position(this.bluePosition);
                    this.Position.Rotate(this.blueRotation, rotationAngle);
                    break;
                case Colors.Green:
                    this.Position = new Position(this.greenPosition);
                    this.Position.Rotate(this.greenRotation, rotationAngle);
                    break;
                case Colors.Orange:
                    this.Position = new Position(this.orangePosition);
                    this.Position.Rotate(this.orangeRotation, rotationAngle);
                    break;
                case Colors.Red:
                    this.Position = new Position(this.redPosition);
                    this.Position.Rotate(this.redRotation, rotationAngle);
                    break;
                case Colors.White:
                    this.Position = new Position(this.whitePosition);
                    this.Position.Rotate(this.whiteRotation, rotationAngle);
                    break;
                case Colors.Yellow:
                    this.Position = new Position(this.yellowPosition);
                    this.Position.Rotate(this.yellowRotation, rotationAngle);
                    break;
            }
        }

        #endregion

        #region Consts

        private const string resourceName = "RubiksChallenge.Resources.CubletFace.obj";

        #endregion

        #region Private Fields

        private readonly Point3D bluePosition = new Point3D(0.0f, 0.525f, 0.0f);
        private readonly Point3D greenPosition = new Point3D(0.0f, -0.525f, 0.0f);
        private readonly Point3D orangePosition = new Point3D(0.0f, 0.0f, -0.525f);
        private readonly Point3D redPosition = new Point3D(0.0f, 0.0f, 0.525f);
        private readonly Point3D whitePosition = new Point3D(-0.525f, 0.0f, 0.0f);
        private readonly Point3D yellowPosition = new Point3D(0.525f, 0.0f, 0.0f);

        private readonly Vector3D blueRotation = new Vector3D(-1.0f, 0.0f, 0.0f);
        private readonly Vector3D greenRotation = new Vector3D(-1.0f, 0.0f, 0.0f);
        private readonly Vector3D orangeRotation = new Vector3D(0.0f, 0.0f, 0.0f);
        private readonly Vector3D redRotation = new Vector3D(0.0f, 0.0f, 0.0f);
        private readonly Vector3D whiteRotation = new Vector3D(0.0f, 1.0f, 0.0f);
        private readonly Vector3D yellowRotation = new Vector3D(0.0f, 1.0f, 0.0f);

        #endregion        

        #region Override Methods

        public override void ReInit()
        {            
            this.Model = ObjLoader.LoadObj(resourceName, this.GetColor(this.Color), this.GetAnaglyphStereoscopyColor(this.Color));
        }

        #endregion
    }
}
