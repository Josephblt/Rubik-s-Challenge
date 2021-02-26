
using RubiksChallenge.Entities.CubeStructure;
using RubiksChallenge.Geometry;

namespace RubiksChallenge.UserInput
{
    public class CubeRotationManager
    {
        #region Constructor

        private CubeRotationManager()
        {
            this.RotationSpeed = 5.0f;
        }

        #endregion

        #region Singleton

        private static CubeRotationManager instance;

        public static CubeRotationManager GetManager()
        {
            if (instance == null)
                instance = new CubeRotationManager();
            return instance;
        }

        #endregion

        #region Attributes and Properties

        public float RotationSpeed { get; set; }

        #endregion        

        #region Public Methods

        public void ExecuteDown()
        {
            RubiksCube.GetRubiksCube().Position.Rotate(new Vector3D(1f, 0f, 0f), this.RotationSpeed);
        }

        public void ExecuteLeft()
        {
            RubiksCube.GetRubiksCube().Position.Rotate(new Vector3D(0f, 1f, 0f), - this.RotationSpeed);
        }

        public void ExecuteRight()
        {
            RubiksCube.GetRubiksCube().Position.Rotate(new Vector3D(0f, 1f, 0f), this.RotationSpeed);
        }

        public void ExecuteUp()
        {
            RubiksCube.GetRubiksCube().Position.Rotate(new Vector3D(1f, 0f, 0f), - this.RotationSpeed);
        }        

        #endregion
    }
}