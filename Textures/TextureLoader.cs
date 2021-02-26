using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;

using Tao.OpenGl;

namespace RubiksChallenge.Textures
{
    public class TextureLoader
    {
        #region Constructors

        private TextureLoader()
        {
        }

        #endregion
        
        #region Private Fields
        
        private readonly List<int> intTextures = new List<int>(); 

        #endregion

        #region Singleton

        private static TextureLoader instance;

        public static TextureLoader GetTextureLoader()
        {
            if (instance == null)
                instance = new TextureLoader();
            return instance;
        } 

        #endregion        

        #region Public Methods

        public Texture LoadTexture(Bitmap bitmap)
        {
            BitmapData bitmapdata;
            var rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);

            bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);
            bitmapdata = bitmap.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            var textureID = intTextures.Count;
            intTextures.Add(intTextures.Count);
            Gl.glGenTextures(intTextures.Count, intTextures.ToArray());

            var texture = new Texture(Gl.GL_TEXTURE_2D, textureID);

            Gl.glBindTexture(Gl.GL_TEXTURE_2D, textureID);
            Gl.glPixelStorei(Gl.GL_UNPACK_ALIGNMENT, 1);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_S, Gl.GL_REPEAT);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_T, Gl.GL_REPEAT);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
            Gl.glTexEnvf(Gl.GL_TEXTURE_ENV, Gl.GL_TEXTURE_ENV_MODE, Gl.GL_MODULATE);

            Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGB, bitmap.Width, bitmap.Height, 0, Gl.GL_BGR_EXT, Gl.GL_UNSIGNED_BYTE, bitmapdata.Scan0);
            
            bitmap.UnlockBits(bitmapdata);
            bitmap.Dispose();

            return texture;
        } 

        #endregion        
    }
}
