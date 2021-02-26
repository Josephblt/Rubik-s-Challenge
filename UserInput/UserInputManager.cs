
using RubiksChallenge.Environment;
using System;
using System.Windows.Forms;

namespace RubiksChallenge.UserInput
{
    public class UserInputManager
    {
        #region Constructor

        private UserInputManager()
        {
            this.SetBindings();            
        }

        #endregion

        #region Singleton

        private static UserInputManager instance;

        public static UserInputManager GetManager()
        {
            if (instance == null)
                instance = new UserInputManager();
            return instance;
        }

        #endregion        

        #region Private Fields

        private Keys downBind;
        private Keys leftBind;
        private Keys rightBind;
        private Keys upBind;

        private Keys selectBottomLayerBind;
        private Keys selectLeftLayerBind;
        private Keys selectRightLayerBind;
        private Keys selectTopLayerBind;

        private Keys rotateBottomLayerPosBind;
        private Keys rotateBottomLayerNegBind;
        private Keys rotateLeftLayerPosBind;
        private Keys rotateLeftLayerNegBind;
        private Keys rotateRightLayerPosBind;
        private Keys rotateRightLayerNegBind;
        private Keys rotateTopLayerPosBind;
        private Keys rotateTopLayerNegBind;

        private Keys rotateToBackLayerBind;
        private Keys rotateToBottomLayerBind;
        private Keys rotateToFrontLayerBind;
        private Keys rotateToLeftLayerBind;
        private Keys rotateToRightLayerBind;
        private Keys rotateToTopLayerBind;

        private Keys increaseEyeDistanceBind;
        private Keys relaxEyeDistanceBind;
        private Keys resetEyeDistanceBind;

        private Keys increaseEyeSeparationBind;
        private Keys relaxEyeSeparationBind;
        private Keys resetEyeSeparationBind;
                
        private bool downPressed;
        private bool leftPressed;
        private bool rightPressed;
        private bool upPressed;

        private bool selectBottomLayerPressed;
        private bool selectLeftLayerPressed;
        private bool selectRightLayerPressed;
        private bool selectTopLayerPressed;


        private bool increaseEyeDistancePressed;
        private bool relaxEyeDistancePressed;
        private bool resetEyeDistancePressed;

        private bool increaseEyeSeparationPressed;
        private bool relaxEyeSeparationPressed;
        private bool resetEyeSeparationPressed;

        #endregion

        #region Private Methods

        private void HandleLayerRotationKeys(Keys key)
        {
            if ((this.rotateBottomLayerNegBind == key) && (this.selectBottomLayerPressed))
                CubeLayerRotationManager.GetManager().ExecuteBottomNegativeRotation();
            if ((this.rotateBottomLayerPosBind == key) && (this.selectBottomLayerPressed))
                CubeLayerRotationManager.GetManager().ExecuteBottomPositiveRotation();
            if ((this.rotateLeftLayerNegBind == key) && (this.selectLeftLayerPressed))
                CubeLayerRotationManager.GetManager().ExecuteLeftNegativeRotation();
            if ((this.rotateLeftLayerPosBind == key) && (this.selectLeftLayerPressed))
                CubeLayerRotationManager.GetManager().ExecuteLeftPositiveRotation();
            if ((this.rotateRightLayerNegBind == key) && (this.selectRightLayerPressed))
                CubeLayerRotationManager.GetManager().ExecuteRightNegativeRotation();
            if ((this.rotateRightLayerPosBind == key) && (this.selectRightLayerPressed))
                CubeLayerRotationManager.GetManager().ExecuteRightPositiveRotation();
            if ((this.rotateTopLayerNegBind == key) && (this.selectTopLayerPressed))
                CubeLayerRotationManager.GetManager().ExecuteTopNegativeRotation();
            if ((this.rotateTopLayerPosBind == key) && (this.selectTopLayerPressed))
                CubeLayerRotationManager.GetManager().ExecuteTopPositiveRotation();
        }

        private void HandleRotationToLayerKeys(Keys key)
        {
            if (this.rotateToBackLayerBind == key)
                CubeLayerRotationManager.GetManager().ExecuteRotateToBackLayer();
            if (this.rotateToBottomLayerBind == key)
                CubeLayerRotationManager.GetManager().ExecuteRotateToBottomLayer();
            if (this.rotateToFrontLayerBind == key)
                CubeLayerRotationManager.GetManager().ExecuteRotateToFrontLayer();
            if (this.rotateToLeftLayerBind == key)
                CubeLayerRotationManager.GetManager().ExecuteRotateToLeftLayer();
            if (this.rotateToRightLayerBind == key)
                CubeLayerRotationManager.GetManager().ExecuteRotateToRightLayer();
            if (this.rotateToTopLayerBind == key)
                CubeLayerRotationManager.GetManager().ExecuteRotateToTopLayer();
        }

        private void SetBindings()
        {
            this.downBind = Keys.Down;
            this.leftBind = Keys.Left;
            this.rightBind = Keys.Right;
            this.upBind = Keys.Up;

            this.selectBottomLayerBind = Keys.N;
            this.selectLeftLayerBind = Keys.G;
            this.selectRightLayerBind = Keys.J;
            this.selectTopLayerBind = Keys.Y;

            this.rotateBottomLayerNegBind = Keys.B;
            this.rotateBottomLayerPosBind = Keys.M;
            this.rotateLeftLayerNegBind = Keys.B;
            this.rotateLeftLayerPosBind = Keys.T;
            this.rotateRightLayerNegBind = Keys.M;
            this.rotateRightLayerPosBind = Keys.U;
            this.rotateTopLayerNegBind = Keys.T;
            this.rotateTopLayerPosBind = Keys.U;

            this.rotateToBackLayerBind = Keys.A;
            this.rotateToBottomLayerBind = Keys.C;
            this.rotateToFrontLayerBind = Keys.D;
            this.rotateToLeftLayerBind = Keys.S;
            this.rotateToRightLayerBind = Keys.F;
            this.rotateToTopLayerBind = Keys.E;

            this.increaseEyeDistanceBind = Keys.PageUp;
            this.relaxEyeDistanceBind = Keys.PageDown;
            this.resetEyeDistanceBind = Keys.Delete;

            this.increaseEyeSeparationBind = Keys.Home;
            this.relaxEyeSeparationBind = Keys.End;
            this.resetEyeSeparationBind = Keys.Insert;
        }

        #endregion

        #region Public Methods

        public void HandleKeyDown(Keys keyCode)
        {
            if (this.downBind == keyCode)
                this.downPressed = true;
            if (this.leftBind == keyCode)
                this.leftPressed = true;
            if (this.rightBind == keyCode)
                this.rightPressed = true;
            if (this.upBind == keyCode)
                this.upPressed = true;

            if (this.selectBottomLayerBind == keyCode)
                this.selectBottomLayerPressed = true;
            if (this.selectLeftLayerBind == keyCode)
                this.selectLeftLayerPressed = true;
            if (this.selectRightLayerBind == keyCode)
                this.selectRightLayerPressed = true;
            if (this.selectTopLayerBind == keyCode)
                this.selectTopLayerPressed = true;

            if (this.increaseEyeDistanceBind == keyCode)
                this.increaseEyeDistancePressed = true;
            if (this.relaxEyeDistanceBind == keyCode)
                this.relaxEyeDistancePressed = true;
            if (this.resetEyeDistanceBind == keyCode)
                this.resetEyeDistancePressed = true;

            if (this.increaseEyeSeparationBind == keyCode)
                this.increaseEyeSeparationPressed = true;
            if (this.relaxEyeSeparationBind == keyCode)
                this.relaxEyeSeparationPressed = true;
            if (this.resetEyeSeparationBind == keyCode)
                this.resetEyeSeparationPressed = true;

            this.HandleLayerRotationKeys(keyCode);
            this.HandleRotationToLayerKeys(keyCode);

            switch (keyCode)
            {
                case Keys.D0:
                    if (AnaglyphStereoscopy.GetAnaglyphStereoscopy().Active)
                        AnaglyphStereoscopy.GetAnaglyphStereoscopy().Deactivate();
                    else
                        AnaglyphStereoscopy.GetAnaglyphStereoscopy().Activate();
                    return;
            }

            Console.WriteLine("WAGNER: " + keyCode);
        }

        public void HandleKeyUp(Keys keyCode)
        {
            if (this.downBind == keyCode)
                this.downPressed = false;
            if (this.leftBind == keyCode)
                this.leftPressed = false;
            if (this.rightBind == keyCode)
                this.rightPressed = false;
            if (this.upBind == keyCode)
                this.upPressed = false;

            if (this.selectBottomLayerBind == keyCode)
                this.selectBottomLayerPressed = false;
            if (this.selectLeftLayerBind == keyCode)
                this.selectLeftLayerPressed = false;
            if (this.selectRightLayerBind == keyCode)
                this.selectRightLayerPressed = false;
            if (this.selectTopLayerBind == keyCode)
                this.selectTopLayerPressed = false;

            if (this.increaseEyeDistanceBind == keyCode)
                this.increaseEyeDistancePressed = false;
            if (this.relaxEyeDistanceBind == keyCode)
                this.relaxEyeDistancePressed = false;
            if (this.resetEyeDistanceBind == keyCode)
                this.resetEyeDistancePressed = false;

            if (this.increaseEyeSeparationBind == keyCode)
                this.increaseEyeSeparationPressed = false;
            if (this.relaxEyeSeparationBind == keyCode)
                this.relaxEyeSeparationPressed = false;
            if (this.resetEyeSeparationBind == keyCode)
                this.resetEyeSeparationPressed = false;
        }

        public void HandleRotation()
        {
            if (this.downPressed)
                CubeRotationManager.GetManager().ExecuteDown();
            if (this.leftPressed)
                CubeRotationManager.GetManager().ExecuteLeft();
            if (this.rightPressed)
                CubeRotationManager.GetManager().ExecuteRight();
            if (this.upPressed)
                CubeRotationManager.GetManager().ExecuteUp();
        }

        public void HandleLayerSelection()
        {
            if (this.selectBottomLayerPressed)
            {
                CubeLayerRotationManager.GetManager().ExecuteSelectBottom();
                return;
            }
            if (this.selectLeftLayerPressed)
            {
                CubeLayerRotationManager.GetManager().ExecuteSelectLeft();
                return;
            }
            if (this.selectRightLayerPressed)
            {
                CubeLayerRotationManager.GetManager().ExecuteSelectRight();
                return;
            }
            if (this.selectTopLayerPressed)
            {
                CubeLayerRotationManager.GetManager().ExecuteSelectTop();
                return;
            }
            CubeLayerRotationManager.GetManager().ExecuteSelectNone();
        }

        public void HandleAnaglyphStereoscopy()
        {
            if (this.increaseEyeDistancePressed)
                AnaglyphStereoscopy.GetAnaglyphStereoscopy().IncreaseEyeDistance();
            if (this.relaxEyeDistancePressed)
                AnaglyphStereoscopy.GetAnaglyphStereoscopy().RelaxEyeDistance();
            if (this.resetEyeDistancePressed)
                AnaglyphStereoscopy.GetAnaglyphStereoscopy().ResetEyeDistance();

            if (this.increaseEyeSeparationPressed)
                AnaglyphStereoscopy.GetAnaglyphStereoscopy().IncreaseEyeSeparation();
            if (this.relaxEyeSeparationPressed)
                AnaglyphStereoscopy.GetAnaglyphStereoscopy().RelaxEyeSeparation();
            if (this.resetEyeSeparationPressed)
                AnaglyphStereoscopy.GetAnaglyphStereoscopy().ResetEyeSeparation();
        }

        #endregion
    }
}
