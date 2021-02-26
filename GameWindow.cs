using RubiksChallenge.Environment;
using RubiksChallenge.UserInput;
using System;
using System.Windows.Forms;
using Tao.OpenGl;

namespace RubiksChallenge
{
    public partial class GameWindow : Form
    {
        #region Constructor

        public GameWindow()
        {
            InitializeComponent();
        }

        #endregion

        #region Private Fields

        private Game game;
        private bool gameRunning = true;

        #endregion

        #region Private Methods

        private void Start()
        {
            this.openGlControl.InitializeContexts();
            this.Reshape();
            this.game = new Game();
        }
        
        private void Loop()
        {
            while (this.gameRunning)
            {
                if (AnaglyphStereoscopy.GetAnaglyphStereoscopy().Active)
                    this.game.RenderAnaglyphStereoscopy();
                else
                    this.game.Render();

                this.game.Update();

                this.openGlControl.Refresh();
                Application.DoEvents();
            }
        }

        private void End()
        {
            this.gameRunning = false;
            openGlControl.DestroyContexts();
        }

        private void Reshape()
        {
            Scene.GetScene().AdjustSize(openGlControl.Width, openGlControl.Height);
        }

        #endregion

        #region Signed Events Methods

        private void GameWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            End();
        }

        private void GameWindow_Load(object sender, System.EventArgs e)
        {
            Start();
        }

        private void GameWindow_Shown(object sender, System.EventArgs e)
        {
            Loop();
        }

        private void OpenGlControl_KeyUp(object sender, KeyEventArgs e)
        {
            UserInputManager.GetManager().HandleKeyUp(e.KeyCode);
            this.openGlControl.Focus();
        }

        private void OpenGlControl_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            UserInputManager.GetManager().HandleKeyDown(e.KeyCode);
            this.openGlControl.Focus();
        }

        private void OpenGlControl_Resize(object sender, EventArgs e)
        {
            this.Reshape();
        }

        #endregion
    }
}