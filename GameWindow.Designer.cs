
namespace RubiksChallenge
{
    partial class GameWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameWindow));
            this.openGlControl = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.SuspendLayout();
            // 
            // openGlControl
            // 
            this.openGlControl.AccumBits = ((byte)(0));
            this.openGlControl.AutoCheckErrors = false;
            this.openGlControl.AutoFinish = false;
            this.openGlControl.AutoMakeCurrent = true;
            this.openGlControl.AutoSwapBuffers = true;
            this.openGlControl.BackColor = System.Drawing.Color.Black;
            this.openGlControl.ColorBits = ((byte)(32));
            this.openGlControl.DepthBits = ((byte)(16));
            this.openGlControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.openGlControl.Location = new System.Drawing.Point(0, 0);
            this.openGlControl.Name = "openGlControl";
            this.openGlControl.Size = new System.Drawing.Size(800, 600);
            this.openGlControl.StencilBits = ((byte)(0));
            this.openGlControl.TabIndex = 0;
            this.openGlControl.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OpenGlControl_KeyUp);
            this.openGlControl.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.OpenGlControl_PreviewKeyDown);
            this.openGlControl.Resize += new System.EventHandler(this.OpenGlControl_Resize);
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.openGlControl);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "GameWindow";
            this.Text = "Rubik\'s Challenge 2008";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameWindow_FormClosing);
            this.Load += new System.EventHandler(this.GameWindow_Load);
            this.Shown += new System.EventHandler(this.GameWindow_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl openGlControl;
    }
}