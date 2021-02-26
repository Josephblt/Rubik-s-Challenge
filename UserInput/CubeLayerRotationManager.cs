
using RubiksChallenge.Entities.CubeStructure;
using RubiksChallenge.Entities.CubeStructure.Layers;
using RubiksChallenge.Geometry;
using System.Collections.Generic;

namespace RubiksChallenge.UserInput
{
    public class CubeLayerRotationManager
    {
        #region Constructor

        private CubeLayerRotationManager()
        {
            this.BackLayer = new BackLayer();
            this.BottomLayer = new BottomLayer();
            this.FrontLayer = new FrontLayer();
            this.LeftLayer = new LeftLayer();
            this.RightLayer = new RightLayer();
            this.TopLayer = new TopLayer();

            this.Layers = new List<AbstractLayer>
                    {
                        this.BackLayer,
                        this.BottomLayer,
                        this.FrontLayer,
                        this.LeftLayer,
                        this.RightLayer,
                        this.TopLayer
                    };
        }

        #endregion

        #region Singleton

        private static CubeLayerRotationManager instance;

        public static CubeLayerRotationManager GetManager()
        {
            if (instance == null)
                instance = new CubeLayerRotationManager();
            return instance;
        }

        #endregion

        #region Attributes and Properties

        public AbstractLayer BackLayer { get; private set; }
        public AbstractLayer BottomLayer { get; private set; }
        public AbstractLayer FrontLayer { get; private set; }
        public AbstractLayer LeftLayer { get; private set; }
        public AbstractLayer RightLayer { get; private set; }
        public AbstractLayer TopLayer { get; private set; }

        public List<AbstractLayer> Layers { get; private set; }

        #endregion

        #region Public Methods

        #region Layer Rotation Methods

        public void ExecuteBottomPositiveRotation()
        {
            if (RubiksCube.GetRubiksCube().LayerRotating) return;
            var layer = RubiksCube.GetRubiksCube().SelectedLayer;
            if (layer != null)
            {
                if ((layer == this.BottomLayer) |
                   (layer == this.FrontLayer) |
                   (layer == this.RightLayer))
                    RubiksCube.GetRubiksCube().RotateLayer(RotationDirection.Negative);
                else
                    RubiksCube.GetRubiksCube().RotateLayer(RotationDirection.Positive);
            }
        }

        public void ExecuteBottomNegativeRotation()
        {
            if (RubiksCube.GetRubiksCube().LayerRotating) return;
            var layer = RubiksCube.GetRubiksCube().SelectedLayer;
            if (layer != null)
            {
                if ((layer == this.BottomLayer) |
                   (layer == this.FrontLayer) |
                   (layer == this.RightLayer))
                    RubiksCube.GetRubiksCube().RotateLayer(RotationDirection.Positive);
                else
                    RubiksCube.GetRubiksCube().RotateLayer(RotationDirection.Negative);
            }
        }

        public void ExecuteLeftPositiveRotation()
        {
            if (RubiksCube.GetRubiksCube().LayerRotating) return;
            var layer = RubiksCube.GetRubiksCube().SelectedLayer;
            if (layer != null)
            {
                if ((layer == this.LeftLayer) |
                   (layer == this.BackLayer) |
                   (layer == this.TopLayer))
                    RubiksCube.GetRubiksCube().RotateLayer(RotationDirection.Negative);
                else
                    RubiksCube.GetRubiksCube().RotateLayer(RotationDirection.Positive);
            }
        }

        public void ExecuteLeftNegativeRotation()
        {
            if (RubiksCube.GetRubiksCube().LayerRotating) return;
            var layer = RubiksCube.GetRubiksCube().SelectedLayer;
            if (layer != null)
            {
                if ((layer == this.LeftLayer) |
                   (layer == this.BackLayer) |
                   (layer == this.TopLayer))
                    RubiksCube.GetRubiksCube().RotateLayer(RotationDirection.Positive);
                else
                    RubiksCube.GetRubiksCube().RotateLayer(RotationDirection.Negative);
            }
        }

        public void ExecuteRightPositiveRotation()
        {
            if (RubiksCube.GetRubiksCube().LayerRotating) return;
            var layer = RubiksCube.GetRubiksCube().SelectedLayer;
            if (layer != null)
            {
                if ((layer == this.RightLayer) |
                   (layer == this.FrontLayer) |
                   (layer == this.BottomLayer))
                    RubiksCube.GetRubiksCube().RotateLayer(RotationDirection.Negative);
                else
                    RubiksCube.GetRubiksCube().RotateLayer(RotationDirection.Positive);
            }
        }

        public void ExecuteRightNegativeRotation()
        {
            if (RubiksCube.GetRubiksCube().LayerRotating) return;
            var layer = RubiksCube.GetRubiksCube().SelectedLayer;
            if (layer != null)
            {
                if ((layer == this.RightLayer) |
                   (layer == this.FrontLayer) |
                   (layer == this.BottomLayer))
                    RubiksCube.GetRubiksCube().RotateLayer(RotationDirection.Positive);
                else
                    RubiksCube.GetRubiksCube().RotateLayer(RotationDirection.Negative);
            }
        }

        public void ExecuteTopPositiveRotation()
        {
            if (RubiksCube.GetRubiksCube().LayerRotating) return;
            var layer = RubiksCube.GetRubiksCube().SelectedLayer;
            if (layer != null)
            {
                if ((layer == this.TopLayer) |
                   (layer == this.BackLayer) |
                   (layer == this.LeftLayer))
                    RubiksCube.GetRubiksCube().RotateLayer(RotationDirection.Negative);
                else
                    RubiksCube.GetRubiksCube().RotateLayer(RotationDirection.Positive);
            }
        }

        public void ExecuteTopNegativeRotation()
        {
            if (RubiksCube.GetRubiksCube().LayerRotating) return;
            var layer = RubiksCube.GetRubiksCube().SelectedLayer;
            if (layer != null)
            {
                if ((layer == this.TopLayer) |
                   (layer == this.BackLayer) |
                   (layer == this.LeftLayer))
                    RubiksCube.GetRubiksCube().RotateLayer(RotationDirection.Positive);
                else
                    RubiksCube.GetRubiksCube().RotateLayer(RotationDirection.Negative);
            }
        } 

        #endregion

        #region Layer Rotation Selection Methods

        public void ExecuteSelectBottom()
        {
            if (RubiksCube.GetRubiksCube().LayerRotating) return;

            var y = 0.0f;
            AbstractLayer retLayer = null;

            foreach (var layer in this.Layers)
            {
                var pos = layer.GetCube(layer.MiddlePosition).Position.Clone();
                var location = new Vector3D(pos.Location.X, pos.Location.Y, pos.Location.Z);
                var matrix = new Matrix3D(RubiksCube.GetRubiksCube().Position.RMatrix);
                matrix.Invert();
                location.Transform(matrix);
                location.Normalize();

                if (location.Y < y)
                {
                    y = location.Y;
                    retLayer = layer;
                }
            }

            if (retLayer != null)
                RubiksCube.GetRubiksCube().SelectedLayer = retLayer;
        }

        public void ExecuteSelectLeft()
        {
            if (RubiksCube.GetRubiksCube().LayerRotating) return;

            var x = 0.0f;
            AbstractLayer retLayer = null;

            foreach (var layer in this.Layers)
            {
                var pos = layer.GetCube(layer.MiddlePosition).Position.Clone();
                var location = new Vector3D(pos.Location.X, pos.Location.Y, pos.Location.Z);
                var matrix = new Matrix3D(RubiksCube.GetRubiksCube().Position.RMatrix);
                matrix.Invert();
                location.Transform(matrix);
                location.Normalize();

                if (location.X < x)
                {
                    x = location.X;
                    retLayer = layer;
                }
            }

            if (retLayer != null)
                RubiksCube.GetRubiksCube().SelectedLayer = retLayer;
        }

        public void ExecuteSelectNone()
        {
            if (RubiksCube.GetRubiksCube().LayerRotating) return;

            RubiksCube.GetRubiksCube().SelectedLayer = null;
        }

        public void ExecuteSelectRight()
        {
            if (RubiksCube.GetRubiksCube().LayerRotating) return;

            var x = 0.0f;
            AbstractLayer retLayer = null;

            foreach (var layer in this.Layers)
            {
                var pos = layer.GetCube(layer.MiddlePosition).Position.Clone();
                var location = new Vector3D(pos.Location.X, pos.Location.Y, pos.Location.Z);
                var matrix = new Matrix3D(RubiksCube.GetRubiksCube().Position.RMatrix);
                matrix.Invert();
                location.Transform(matrix);
                location.Normalize();

                if (location.X > x)
                {
                    x = location.X;
                    retLayer = layer;
                }
            }

            if (retLayer != null)
                RubiksCube.GetRubiksCube().SelectedLayer = retLayer;
        }

        public void ExecuteSelectTop()
        {
            if (RubiksCube.GetRubiksCube().LayerRotating) return;

            var y = 0.0f;
            AbstractLayer retLayer = null;

            foreach (var layer in this.Layers)
            {
                var pos = layer.GetCube(layer.MiddlePosition).Position.Clone();
                var location = new Vector3D(pos.Location.X, pos.Location.Y, pos.Location.Z);
                var matrix = new Matrix3D(RubiksCube.GetRubiksCube().Position.RMatrix);
                matrix.Invert();
                location.Transform(matrix);
                location.Normalize();

                if (location.Y > y)
                {
                    y = location.Y;
                    retLayer = layer;
                }
            }

            if (retLayer != null)
                RubiksCube.GetRubiksCube().SelectedLayer = retLayer;
        }

        #endregion

        #region Rotation to Layer Methods

        public void ExecuteRotateToBackLayer()
        {
            RubiksCube.GetRubiksCube().RotateToLayer(new Vector3D(0f, 1f, 0f), 180.0f);
        }

        public void ExecuteRotateToBottomLayer()
        {
            RubiksCube.GetRubiksCube().RotateToLayer(new Vector3D(-1.0f, 0.0f, 0.0f), 90.0f);
        }

        public void ExecuteRotateToFrontLayer()
        {
            RubiksCube.GetRubiksCube().RotateToLayer(new Vector3D(1f, 0f, 0f), 0.0f);
        }

        public void ExecuteRotateToLeftLayer()
        {
            RubiksCube.GetRubiksCube().RotateToLayer(new Vector3D(0f, 1f, 0f), 90.0f);
        }

        public void ExecuteRotateToRightLayer()
        {
            RubiksCube.GetRubiksCube().RotateToLayer(new Vector3D(0.0f, -1.0f, 0.0f), 90.0f);
        }

        public void ExecuteRotateToTopLayer()
        {
            RubiksCube.GetRubiksCube().RotateToLayer(new Vector3D(1f, 0f, 0f), 90.0f);
        }

        #endregion

        #endregion
    }
}
