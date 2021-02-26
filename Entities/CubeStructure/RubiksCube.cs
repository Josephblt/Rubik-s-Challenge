using RubiksChallenge.Entities.CubeStructure.Layers;
using RubiksChallenge.Geometry;
using RubiksChallenge.UserInput;
using Tao.OpenGl;

namespace RubiksChallenge.Entities.CubeStructure
{
    public class RubiksCube : AbstractEntity
    {
        #region Constructor

        private RubiksCube()
            : base()
        {
            this.Cubes = new Cube[3, 3, 3];
            var rubiksCubeFactory = new RubiksCubeFactory();
            rubiksCubeFactory.Assemble(this);
        }

        #endregion

        #region Singleton

        private static RubiksCube instance;

        public static RubiksCube GetRubiksCube()
        {
            if (instance == null)
                instance = new RubiksCube();
            return instance;
        }

        #endregion        

        #region Attributes and Properties

        public Cube[,,] Cubes { get; private set; }

        public bool LayerRotating { get; private set; }

        public bool RotatingToLayer { get; private set; }

        public bool ResetingRotation { get; private set; }

        private AbstractLayer selectedLayer;        
        public AbstractLayer SelectedLayer
        {
            get { return this.selectedLayer; }
            set
            {
                if (this.SelectedLayer == value) return;
                if (this.selectedLayer != null)
                    this.selectedLayer.UnselectLayer();
                this.selectedLayer = value;
                if (this.selectedLayer != null)
                    this.selectedLayer.SelectLayer();
            }
        }
        
        #endregion

        #region Private Fields

        private RotationDirection rotationDirection;
        
        private Vector3D rotateToVector;        
        private float rotateToAngle;

        private int step = 0;        

        #endregion

        #region Overriden Methods

        public override void Render()
        {
            Gl.glPushMatrix();
            
            Gl.glTranslated(this.Position.Location.X, this.Position.Location.Y, this.Position.Location.Z);
            Gl.glRotatef(this.Position.Rotation, this.Position.Axis.X, this.Position.Axis.Y, this.Position.Axis.Z);
            
            for (int x = 0; x < 3; x++)
                for (int y = 0; y < 3; y++)
                    for (int z = 0; z < 3; z++)
                        if (this.Cubes[x, y, z] != null)
                            if (!this.Cubes[x, y, z].Selected)
                                this.Cubes[x, y, z].Render();

            if (this.SelectedLayer != null)
                this.SelectedLayer.RenderSelectedLayer();

            Gl.glPopMatrix();
        }

        public override void ReInit()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    for (int k = 0; k < 3; k++)
                        if (this.Cubes[i, j, k] != null)
                            this.Cubes[i, j, k].ReInit();
        }

        public override void Update()
        {
            if (this.LayerRotating)
            {
                this.RotateLayer();
                return;
            }
            if (this.RotatingToLayer)
            {
                this.RotateToLayer();
                return;
            }

            UserInputManager.GetManager().HandleRotation();
            UserInputManager.GetManager().HandleLayerSelection();
        }

        #endregion

        #region Public Methods

        public void RotateLayer(RotationDirection rotationDirection)
        {
            this.rotationDirection = rotationDirection;
            this.LayerRotating = true;
            this.step = 0;            
        }

        public void RotateToLayer(Vector3D rotationVector, float rotationAngle)
        {
            this.ResetingRotation = true;
            this.RotatingToLayer = true;
            this.rotateToVector = rotationVector;
            this.rotateToAngle = rotationAngle;
            this.RotateToLayer();
        }

        #endregion

        #region Private Methods

        private void RotateLayer()
        {
            if (this.SelectedLayer != null)
            {
                if (this.LayerRotating)
                {
                    this.SelectedLayer.Rotate(this.rotationDirection, step);
                    this.step += 10;
                    if (this.step > 90)
                        this.LayerRotating = false;
                }                
            }
        }

        private void ResetRotation()
        {
            float step = CubeRotationManager.GetManager().RotationSpeed;

            if (this.ResetingRotation)
            {
                Vector3D rotationVector = this.Position.Axis;
                float rotationAngle = this.Position.Rotation;

                if (rotationAngle == 0)
                    this.ResetingRotation = false;
                else if (rotationAngle >= step)
                    this.Position.Rotate(rotationVector, -step);
                else
                    this.Position.Rotate(rotationVector, -rotationAngle);
            }            
        }

        private void RotateToLayer()
        {
            float step = CubeRotationManager.GetManager().RotationSpeed;

            if (this.ResetingRotation)
                this.ResetRotation();
            else
            {
                if (this.RotatingToLayer)
                {
                    Vector3D rotationVector = this.Position.Axis;
                    float rotationAngle = this.Position.Rotation;

                    if ((Math3D.FloatComparison(rotationVector.X, this.rotateToVector.X, Math3D.EpsilonF)) &&
                        (Math3D.FloatComparison(rotationVector.Y, this.rotateToVector.Y, Math3D.EpsilonF)) &&
                        (Math3D.FloatComparison(rotationVector.Z, this.rotateToVector.Z, Math3D.EpsilonF)) &&
                        (rotationAngle == this.rotateToAngle))
                    {
                        this.RotatingToLayer = false;
                        return;
                    }

                    if ((this.rotateToAngle - rotationAngle) >= step)
                        this.Position.Rotate(this.rotateToVector, step);
                    else
                        this.Position.Rotate(this.rotateToVector, (this.rotateToAngle - rotationAngle));
                }
            }
        }
        
        #endregion
    }
}
