
using Tao.OpenGl;

namespace RubiksChallenge.Textures
{
    public class Texture
    {
        #region Constructor

        public Texture(int target, int textureID)
        {
            this.Target = target;
            this.TextureID = textureID;
        }

        #endregion

        #region Attributes and Properties

        public int Target { get; set; }
        public int TextureID { get; set; }

        #endregion        

        #region Public Methods

        public void Bind()
        {            
            Gl.glBindTexture(this.Target, this.TextureID);                    
        }

        #endregion
    }
}
