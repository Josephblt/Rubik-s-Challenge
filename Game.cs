using RubiksChallenge.Entities.CubeStructure;
using RubiksChallenge.Environment;
using RubiksChallenge.Properties;
using RubiksChallenge.Textures;
using RubiksChallenge.UserInput;

using Tao.OpenGl;

namespace RubiksChallenge
{
    public class Game
    {
        #region Constructor

        public Game()
        {
            this.BackgroundTexture = TextureLoader.GetTextureLoader().LoadTexture(Resources.Background);
        }

        #endregion

        #region Attributes and Properties

        public Texture BackgroundTexture { get; private set; }

        #endregion

        #region Private Methods

        private void DrawBackground()
        {
            var width = Scene.GetScene().Width;
            var height = Scene.GetScene().Height;

            this.EnterOrtho();

            this.BackgroundTexture.Bind();

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glTexCoord2f(0, 0);
            Gl.glVertex2i(0, 0);
            Gl.glTexCoord2f(0, 1);
            Gl.glVertex2i(0, height);
            Gl.glTexCoord2f(1, 1);
            Gl.glVertex2i(width, height);
            Gl.glTexCoord2f(1, 0);
            Gl.glVertex2i(width, 0);
            Gl.glEnd();

            this.LeaveOrtho();
        }

        private void DrawAnaglyphStereoscopyBackground()
        {
            var width = Scene.GetScene().Width;
            var height = Scene.GetScene().Height;

            this.EnterOrtho();

            this.BackgroundTexture.Bind();

            Gl.glColorMask(Gl.GL_FALSE, Gl.GL_FALSE, Gl.GL_TRUE, Gl.GL_TRUE);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glTexCoord2f(0, 0);
            Gl.glVertex2i(0, 0);
            Gl.glTexCoord2f(0, 1);
            Gl.glVertex2i(0, height);
            Gl.glTexCoord2f(1, 1);
            Gl.glVertex2i(width, height);
            Gl.glTexCoord2f(1, 0);
            Gl.glVertex2i(width, 0);
            Gl.glEnd();

            Gl.glColorMask(Gl.GL_TRUE, Gl.GL_FALSE, Gl.GL_FALSE, Gl.GL_TRUE);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glTexCoord2f(0, 0);
            Gl.glVertex2i(0, 0);
            Gl.glTexCoord2f(0, 1);
            Gl.glVertex2i(0, height);
            Gl.glTexCoord2f(1, 1);
            Gl.glVertex2i(width, height);
            Gl.glTexCoord2f(1, 0);
            Gl.glVertex2i(width, 0);
            Gl.glEnd();

            this.LeaveOrtho();
        }

        private void EnterOrtho()
        {
            var width = Scene.GetScene().Width;
            var height = Scene.GetScene().Height;

            Gl.glPushAttrib(Gl.GL_DEPTH_BUFFER_BIT | Gl.GL_ENABLE_BIT);
            Gl.glPushMatrix();
            Gl.glLoadIdentity();
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glPushMatrix();

            Gl.glLoadIdentity();
            Glu.gluOrtho2D(0, width, 0, height);
            Gl.glDisable(Gl.GL_DEPTH_TEST);
            Gl.glDisable(Gl.GL_LIGHTING);  
        }

        private void LeaveOrtho()
        {
            Gl.glPopMatrix();
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glPopMatrix();
            Gl.glPopAttrib();            
        }

        #endregion

        #region Public Methods

        public void Render()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glClearColor(.3f, .3f, .3f, 1f);

            this.DrawBackground();            
            Gl.glLoadIdentity();
            Glu.gluLookAt(0f, 0f, 7f, 0f, 0f, -1f, 0f, 1f, 0f);

            RubiksCube.GetRubiksCube().Render();
        }

        public void RenderAnaglyphStereoscopy()
        {
            var anag = AnaglyphStereoscopy.GetAnaglyphStereoscopy();

            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            this.DrawAnaglyphStereoscopyBackground();

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Glu.gluLookAt(0 - anag.EyeSeparation, 0, 7 + anag.EyeDistance,
                          0, 0, -1,
                          0, 1, 0);

            Gl.glColorMask(Gl.GL_FALSE, Gl.GL_FALSE, Gl.GL_TRUE, Gl.GL_TRUE);
            RubiksCube.GetRubiksCube().Render();

            Gl.glClear(Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Glu.gluLookAt(0 + anag.EyeSeparation, 0, 7 + anag.EyeDistance,
                          0, 0, -1,
                          0, 1, 0);

            Gl.glColorMask(Gl.GL_TRUE, Gl.GL_FALSE, Gl.GL_FALSE, Gl.GL_TRUE);
            RubiksCube.GetRubiksCube().Render();

            Gl.glColorMask(Gl.GL_TRUE, Gl.GL_TRUE, Gl.GL_TRUE, Gl.GL_TRUE);
        } 

        public void Update()
        {
            RubiksCube.GetRubiksCube().Update();

            if (AnaglyphStereoscopy.GetAnaglyphStereoscopy().Active)
                UserInputManager.GetManager().HandleAnaglyphStereoscopy();
        }
        
        #endregion
    }
}
