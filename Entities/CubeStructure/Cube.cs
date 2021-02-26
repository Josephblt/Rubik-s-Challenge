using RubiksChallenge.Model;

using Tao.OpenGl;

namespace RubiksChallenge.Entities.CubeStructure
{
    public class Cube : AbstractEntity
    {
        #region Constructor

        public Cube()
            : base(resourceName, Colors.Black)
        {            
        }

        #endregion

        #region Consts

        private const string resourceName = "RubiksChallenge.Resources.Cublet.obj";

        #endregion

        #region Attributes and Properties

        public CubeFace[] Faces { get; set; }
        public bool Selected { get; set; }

        #endregion

        #region Overriden Methods

        public override void Render()
        {           
            Gl.glPushMatrix();

            Gl.glTranslated(this.Position.Location.X, this.Position.Location.Y, this.Position.Location.Z);
            Gl.glRotatef(this.Position.Rotation, this.Position.Axis.X, this.Position.Axis.Y, this.Position.Axis.Z);
            
            if (this.Model != null)
                this.Model.Render();

            if (this.Faces != null)
                for (int i = 0; i < this.Faces.Length; i++)
                    this.Faces[i].Render();            

            Gl.glPopMatrix();
        }

        public override void ReInit()
        {
            foreach (CubeFace face in this.Faces)
                face.ReInit();
            this.Model = ObjLoader.LoadObj(resourceName, this.GetColor(this.Color), this.GetAnaglyphStereoscopyColor(this.Color));
        }

        #endregion
    }
}
