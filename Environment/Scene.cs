
using Tao.OpenGl;

namespace RubiksChallenge.Environment
{
    public class Scene
    {
        #region Constructor

        private Scene()
        {            
        }

        #endregion

        #region Singleton

        private static Scene instance;

        public static Scene GetScene()
        {
            if (instance == null)
                instance = new Scene();
            return instance;
        }

        #endregion

        #region Attributes and Properties

        public int Width { get; private set; }

        public int Height { get; private set; }

        #endregion

        #region Public Methods

        public void AdjustSize(int width, int height)
        {
            this.Width = width;
            this.Height = height;

            Gl.glEnable(Gl.GL_DEPTH_TEST);            
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glDepthFunc(Gl.GL_LEQUAL);          
            Gl.glHint(Gl.GL_PERSPECTIVE_CORRECTION_HINT, Gl.GL_NICEST);

            Gl.glViewport(0, 0, width, height);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPerspective(45.0f, width / (double)height, 0.1f, 600.0f);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            
            this.DefineLight();
        }

        #endregion

        #region Private Methods

        private void DefineLight()
        {
            var ambient = new float[] { 0.0f, 0.0f, 0.0f, 1.0f };
            var diffuse = new float[] { 1.0f, 1.0f, 1.0f, 1.0f };
            var specular = new float[] { 1.0f, 1.0f, 1.0f, 1.0f };
            var position = new float[] { -1.0f, 0.0f, 0.3f, 0.0f };

            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_AMBIENT, ambient);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_DIFFUSE, diffuse);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_SPECULAR, specular);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, position);

            var model_ambient = new float[] { 0.2f, 0.2f, 0.2f, 1.0f };
            var model_two_side = 1;
            var viewpoint = 1;

            Gl.glLightModelfv(Gl.GL_LIGHT_MODEL_AMBIENT, model_ambient);
            Gl.glLightModeli(Gl.GL_LIGHT_MODEL_LOCAL_VIEWER, viewpoint);
            Gl.glLightModeli(Gl.GL_LIGHT_MODEL_TWO_SIDE, model_two_side);

            Gl.glShadeModel(Gl.GL_SMOOTH);
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glEnable(Gl.GL_LIGHT0);
            Gl.glEnable(Gl.GL_LIGHTING);
        }
        
        #endregion
    }
}
