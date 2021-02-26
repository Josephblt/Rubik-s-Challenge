using RubiksChallenge.Geometry;
using Tao.OpenGl;

namespace RubiksChallenge.Entities.CubeStructure.Layers
{
    public abstract class AbstractLayer
    {
        #region Consts

        protected const float rotationFactor = 10.0f;

        #endregion

        #region Protected Fields

        public Point3D[] position = new Point3D[9];
        
        private bool selectedLayerGrowing = true;

        #endregion

        #region Attributes and Properties

        public Point3D MiddlePosition { get; protected set; }

        private float scaleFactor = 1.0f;
        private float ScaleFactor
        {
            get
            {
                if (this.selectedLayerGrowing)
                    this.scaleFactor += 0.01f;
                else
                    this.scaleFactor -= 0.01f;
                if (this.scaleFactor >= 1.1f)
                    this.selectedLayerGrowing = false;
                if (this.scaleFactor <= 1)
                    this.selectedLayerGrowing = true;
                return this.scaleFactor;
            }
        }

        #endregion

        #region Abstract Methods

        protected abstract void ExecuteRotation(RotationDirection rotationDirection);

        #endregion

        #region Private Methods

        protected void ExecuteMatrixRotation(RotationDirection rotationDirection)
        {
            Cube cubeOne = this.GetCube(position[0]);
            Cube cubeTwo = this.GetCube(position[1]);
            Cube cubeThree = this.GetCube(position[2]);
            Cube cubeFour = this.GetCube(position[3]);
            Cube cubeFive = this.GetCube(position[4]);
            Cube cubeSix = this.GetCube(position[5]);
            Cube cubeSeven = this.GetCube(position[6]);
            Cube cubeEight = this.GetCube(position[7]);

            if (rotationDirection == RotationDirection.Positive)
            {
                this.SetCube(cubeSeven ,position[0]);
                this.SetCube(cubeEight, position[1]);
                this.SetCube(cubeOne, position[2]);
                this.SetCube(cubeTwo, position[3]);
                this.SetCube(cubeThree, position[4]);
                this.SetCube(cubeFour, position[5]);
                this.SetCube(cubeFive, position[6]);
                this.SetCube(cubeSix, position[7]);
            }
            else
            {
                this.SetCube(cubeThree, position[0]);
                this.SetCube(cubeFour, position[1]);
                this.SetCube(cubeFive, position[2]);
                this.SetCube(cubeSix, position[3]);
                this.SetCube(cubeSeven, position[4]);
                this.SetCube(cubeEight, position[5]);
                this.SetCube(cubeOne, position[6]);
                this.SetCube(cubeTwo, position[7]);
            }   
        }

        protected void SetCube(Cube cube, Point3D position)
        {
            RubiksCube rubiksCube = RubiksCube.GetRubiksCube();
            rubiksCube.Cubes[(int)position.X, (int)position.Y, (int)position.Z] = cube;
        }

        #endregion

        #region Public Methods

        public Cube GetCube(Point3D position)
        {
            RubiksCube rubiksCube = RubiksCube.GetRubiksCube();
            return rubiksCube.Cubes[(int)position.X, (int)position.Y, (int)position.Z];
        }

        public void Rotate(RotationDirection rotationDirection, int step)
        {
            if (step == 90)
                this.ExecuteMatrixRotation(rotationDirection);
            else
                this.ExecuteRotation(rotationDirection);
        }

        public void RenderSelectedLayer()
        {
            var scale = this.ScaleFactor;
            
            Gl.glScalef(scale, scale, scale);

            for (int i = 0; i < 9; i++)
                if (this.position[i] != null)
                    this.GetCube(this.position[i]).Render();

            this.GetCube(this.MiddlePosition).Render();
        }

        public void SelectLayer()
        {
            this.scaleFactor = 1.0f;
            for (int i = 0; i < 9; i++)
                if (this.position[i] != null)
                    this.GetCube(this.position[i]).Selected = true;
            this.GetCube(this.MiddlePosition).Selected = true;
        }

        public void UnselectLayer()
        {
            for (int i = 0; i < 9; i++)
                if (this.position[i] != null)
                    this.GetCube(this.position[i]).Selected = false;
            this.GetCube(this.MiddlePosition).Selected = false;
        }

        #endregion
    }
}
