
using RubiksChallenge.Geometry;

namespace RubiksChallenge.Environment
{
    public class AnaglyphStereoscopy
    {
        #region Constructor

        private AnaglyphStereoscopy()
        {
            this.EyeDistance = 0f;
            this.EyeSeparation = 0.5f;
        }

        #endregion

        #region Singleton

        private static AnaglyphStereoscopy instance;

        public static AnaglyphStereoscopy GetAnaglyphStereoscopy()
        {
            if (instance == null)
                instance = new AnaglyphStereoscopy();
            return instance;
        }

        #endregion

        #region Attributes and Properties

        public bool Active { get; private set; }
        public float EyeDistance { get; private set; }
        public float EyeSeparation { get; private set; }

        #endregion

        #region Public Methods

        public void Activate()
        {
            this.Active = true;
        }

        public void Deactivate()
        {
            this.Active = false;
        }

        public void IncreaseEyeDistance()
        {
            this.EyeDistance += 0.01f;
        }

        public void RelaxEyeDistance()
        {
            this.EyeDistance -= 0.01f;
        }

        public void ResetEyeDistance()
        {
            this.EyeDistance = 0.0f;
        }

        public void IncreaseEyeSeparation()
        { 
            this.EyeSeparation += 0.01f;
            if (this.EyeSeparation > 2f)
                this.EyeSeparation = 2f;
        }

        public void RelaxEyeSeparation()
        {
            this.EyeSeparation -= 0.01f;
            if (this.EyeSeparation < 0f)
                this.EyeSeparation = 0f;
        }

        public void ResetEyeSeparation()
        {
            this.EyeSeparation = 0.5f;
        }

        #endregion
    }
}
