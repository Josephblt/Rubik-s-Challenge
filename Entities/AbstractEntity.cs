using System.Drawing;
using RubiksChallenge.Entities.CubeStructure;
using RubiksChallenge.Geometry;
using RubiksChallenge.Model;
using RubiksChallenge.Properties;

using Tao.OpenGl;

namespace RubiksChallenge.Entities
{
    public abstract class AbstractEntity
    {
        #region Constructors

        public AbstractEntity()
        {
            this.Position = new Position();
        }

        public AbstractEntity(string resourceName, Colors color) : this()
        {
            this.Model = ObjLoader.LoadObj(resourceName, this.GetColor(color), this.GetAnaglyphStereoscopyColor(color));
            this.Color = color;
        }

        #endregion

        #region Attributes and Properties

        public Colors Color { get; set; }
        public ObjModel Model { get; set; }
        public Position Position { get; set; }

        #endregion

        #region Abstract Methods

        public abstract void ReInit();

        #endregion

        #region Protected Methods

        protected Bitmap GetColor(Colors color)
        {
            switch (color)
            {
                case Colors.Black:
                    return Resources.Black;
                case Colors.Blue:
                    return Resources.Blue;
                case Colors.Green:
                    return Resources.Green;
                case Colors.Orange:
                    return Resources.Orange;
                case Colors.Red:
                    return Resources.Red;
                case Colors.White:
                    return Resources.White;
                case Colors.Yellow:
                    return Resources.Yellow;
                default:
                    return Resources.Black;
            }
        }

        protected Bitmap GetAnaglyphStereoscopyColor(Colors color)
        {
            //switch (color)
            //{
            //    case Colors.Black:
            //        return Resources.Black;
            //    case Colors.Blue:
            //        return Resources.BlueAnaglyphStereoscopy;
            //    case Colors.Green:
            //        return Resources.GreenAnaglyphStereoscopy;
            //    case Colors.Orange:
            //        return Resources.OrangeAnaglyphStereoscopy;
            //    case Colors.Red:
            //        return Resources.RedAnaglyphStereoscopy;
            //    case Colors.White:
            //        return Resources.WhiteAnaglyphStereoscopy;
            //    case Colors.Yellow:
            //        return Resources.YellowAnaglyphStereoscopy;
            //    default:
            //        return Resources.Black;
            //}            
            switch (color)
            {
                case Colors.Black:
                    return Resources.WhiteAnaglyphStereoscopy;
                default:
                    return Resources.OrangeAnaglyphStereoscopy;
            }    
        }
        
        #endregion

        #region Public Virtual Methods

        public virtual void Render()
        {
            Gl.glPushMatrix();

            Gl.glTranslated(this.Position.Location.X, this.Position.Location.Y, this.Position.Location.Z);
            Gl.glRotatef(this.Position.Rotation, this.Position.Axis.X, this.Position.Axis.Y, this.Position.Axis.Z);

            if (this.Model != null)
                this.Model.Render();

            Gl.glPopMatrix();
        }

        public virtual void Update()
        {            
        }

        #endregion
    }
}
