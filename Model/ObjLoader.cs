using System.Drawing;
using System.IO;
using System.Reflection;
using RubiksChallenge.Textures;

namespace RubiksChallenge.Model
{
    public static class ObjLoader
    {
        #region Static Methods

        public static ObjModel LoadObj(string resourceName, Bitmap resourceBitmap, Bitmap anaglyphStereoscopyResourceBitmap)
        {
            ObjData objData;
            var texture = TextureLoader.GetTextureLoader().LoadTexture(resourceBitmap);
            var anaglyphStereoscopyTexture = TextureLoader.GetTextureLoader().LoadTexture(anaglyphStereoscopyResourceBitmap);

            var assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    objData = new ObjData(reader);
                }
            }

            return new ObjModel(objData, texture, anaglyphStereoscopyTexture);
        }

        #endregion
    }
}
