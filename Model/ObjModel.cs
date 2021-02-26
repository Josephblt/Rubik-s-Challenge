
using RubiksChallenge.Geometry;
using RubiksChallenge.Textures;

using Tao.OpenGl;
using RubiksChallenge.Environment;

namespace RubiksChallenge.Model
{
    public class ObjModel
    {
        #region Constructors

        public ObjModel(ObjData objData, Texture texture, Texture anaglyphStereoscopyTexture)
        {
            this.Texture = texture;
            this.AnaglyphStereoscopyTexture = anaglyphStereoscopyTexture;

            this.listID = Gl.glGenLists(1);

            Gl.glNewList(listID, Gl.GL_COMPILE);
            Gl.glPushMatrix();

            float[] mat_ambient = new float[] { 0.7f, 0.7f, 0.7f, 1.0f };
            float[] mat_diffuse = new float[] { 0.7f, 0.7f, 0.7f, 1.0f };
            float[] mat_specular = new float[] { 1.0f, 1.0f, 1.0f, 1.0f };
            float[] mat_emission = new float[] { 0.2f, 0.2f, 0.2f, 0.0f };

            float shininess = 10.0f;

            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT, mat_ambient);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, mat_diffuse);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, mat_specular);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_EMISSION, mat_emission);
            Gl.glMaterialf(Gl.GL_FRONT, Gl.GL_SHININESS, shininess);

            Gl.glBegin(Gl.GL_TRIANGLES);

            for (int i = 0; i < objData.Faces.Length; i++)
            {
                for (int v = 0; v < 3; v++)
                {
                    Point3D vert = objData.Faces[i].Vertex[v];
                    Point3D norm = objData.Faces[i].Normal[v];
                    Point2D tex = objData.Faces[i].TexCoord[v];

                    Gl.glNormal3f(norm.X, norm.Y, norm.Z);
                    Gl.glTexCoord2f(tex.X, tex.Y);
                    Gl.glVertex3f(vert.X, vert.Y, vert.Z);
                }
            }

            Gl.glEnd();
            Gl.glPopMatrix();
            Gl.glEndList();            
        }

        #endregion

        #region Private Fields

        private readonly int listID;

        #endregion

        #region Attributes and Properties

        public Texture Texture { get; }

        public Texture AnaglyphStereoscopyTexture { get; }

        #endregion

        #region Public Methods

        public void Render()
        {
            if (AnaglyphStereoscopy.GetAnaglyphStereoscopy().Active)
            {
                if (this.AnaglyphStereoscopyTexture != null)
                    this.AnaglyphStereoscopyTexture.Bind();
            }
            else
            {
                if (this.Texture != null)
                    this.Texture.Bind();
            }

            Gl.glCallList(this.listID);
        }
        
        #endregion        
    }
}
