
using RubiksChallenge.Geometry;

namespace RubiksChallenge.Entities.CubeStructure
{
    public class RubiksCubeFactory
    {
        #region Private Methods

        private Cube CreateSingleFaced(Colors colorOne)
        {
            var cube = new Cube
            {
                Faces = new CubeFace[1]
            };

            cube.Faces[0] = new CubeFace(colorOne);
            return cube;
        }

        private Cube CreateDoubleFaced(Colors colorOne, Colors colorTwo)
        {
            var cube = new Cube
            {
                Faces = new CubeFace[2]
            };

            cube.Faces[0] = new CubeFace(colorOne);
            cube.Faces[1] = new CubeFace(colorTwo);
            return cube;
        }

        private Cube CreateTripleFaced(Colors colorOne, Colors colorTwo, Colors colorThree)
        {
            var cube = new Cube
            {
                Faces = new CubeFace[3]
            };

            cube.Faces[0] = new CubeFace(colorOne);
            cube.Faces[1] = new CubeFace(colorTwo);
            cube.Faces[2] = new CubeFace(colorThree);
            return cube;
        }

        private void CreateAllSingleFaced(RubiksCube rubiksCube)
        {
            rubiksCube.Cubes[1, 0, 1] = CreateSingleFaced(Colors.Green);
            rubiksCube.Cubes[1, 0, 1].Position = new Position(new Point3D(0.0f, -1.0f, 0.0f));

            rubiksCube.Cubes[0, 1, 1] = CreateSingleFaced(Colors.White);
            rubiksCube.Cubes[0, 1, 1].Position = new Position(new Point3D(-1.0f, 0.0f, 0.0f));

            rubiksCube.Cubes[2, 1, 1] = CreateSingleFaced(Colors.Yellow);
            rubiksCube.Cubes[2, 1, 1].Position = new Position(new Point3D(1.0f, 0.0f, 0.0f));

            rubiksCube.Cubes[1, 1, 0] = CreateSingleFaced(Colors.Orange);
            rubiksCube.Cubes[1, 1, 0].Position = new Position(new Point3D(0.0f, 0.0f, -1.0f));

            rubiksCube.Cubes[1, 1, 2] = CreateSingleFaced(Colors.Red);
            rubiksCube.Cubes[1, 1, 2].Position = new Position(new Point3D(0.0f, 0.0f, 1.0f));

            rubiksCube.Cubes[1, 2, 1] = CreateSingleFaced(Colors.Blue);
            rubiksCube.Cubes[1, 2, 1].Position = new Position(new Point3D(0.0f, 1.0f, 0.0f));
        }

        private void CreateAllDoubleFaced(RubiksCube rubiksCube)
        {
            rubiksCube.Cubes[1, 0, 0] = CreateDoubleFaced(Colors.Green, Colors.Orange);
            rubiksCube.Cubes[1, 0, 0].Position = new Position(new Point3D(0.0f, -1.0f, -1.0f));

            rubiksCube.Cubes[0, 0, 1] = CreateDoubleFaced(Colors.Green, Colors.White);
            rubiksCube.Cubes[0, 0, 1].Position = new Position(new Point3D(-1.0f, -1.0f, 0.0f));

            rubiksCube.Cubes[2, 0, 1] = CreateDoubleFaced(Colors.Green, Colors.Yellow);
            rubiksCube.Cubes[2, 0, 1].Position = new Position(new Point3D(1.0f, -1.0f, 0.0f));

            rubiksCube.Cubes[1, 0, 2] = CreateDoubleFaced(Colors.Green, Colors.Red);
            rubiksCube.Cubes[1, 0, 2].Position = new Position(new Point3D(0.0f, -1.0f, 1.0f));

            rubiksCube.Cubes[0, 1, 0] = CreateDoubleFaced(Colors.Orange, Colors.White);
            rubiksCube.Cubes[0, 1, 0].Position = new Position(new Point3D(-1.0f, 0.0f, -1.0f));

            rubiksCube.Cubes[2, 1, 0] = CreateDoubleFaced(Colors.Yellow, Colors.Orange);
            rubiksCube.Cubes[2, 1, 0].Position = new Position(new Point3D(1.0f, 0.0f, -1.0f));

            rubiksCube.Cubes[0, 1, 2] = CreateDoubleFaced(Colors.Red, Colors.White);
            rubiksCube.Cubes[0, 1, 2].Position = new Position(new Point3D(-1.0f, 0.0f, 1.0f));

            rubiksCube.Cubes[2, 1, 2] = CreateDoubleFaced(Colors.Red, Colors.Yellow);
            rubiksCube.Cubes[2, 1, 2].Position = new Position(new Point3D(1.0f, 0.0f, 1.0f));
            
            rubiksCube.Cubes[1, 2, 0] = CreateDoubleFaced(Colors.Orange, Colors.Blue);
            rubiksCube.Cubes[1, 2, 0].Position = new Position(new Point3D(0.0f, 1.0f, -1.0f));

            rubiksCube.Cubes[0, 2, 1] = CreateDoubleFaced(Colors.White, Colors.Blue);
            rubiksCube.Cubes[0, 2, 1].Position = new Position(new Point3D(-1.0f, 1.0f, 0.0f));

            rubiksCube.Cubes[1, 2, 2] = CreateDoubleFaced(Colors.Red, Colors.Blue);
            rubiksCube.Cubes[1, 2, 2].Position = new Position(new Point3D(0.0f, 1.0f, 1.0f));

            rubiksCube.Cubes[2, 2, 1] = CreateDoubleFaced(Colors.Yellow, Colors.Blue);
            rubiksCube.Cubes[2, 2, 1].Position = new Position(new Point3D(1.0f, 1.0f, 0.0f));
        }

        private void CreateAllTripleFaced(RubiksCube rubiksCube)
        {
            rubiksCube.Cubes[0, 0, 0] = CreateTripleFaced(Colors.Green, Colors.Orange, Colors.White);
            rubiksCube.Cubes[0, 0, 0].Position = new Position(new Point3D(-1.0f, -1.0f, -1.0f));
            
            rubiksCube.Cubes[2, 0, 0] = CreateTripleFaced(Colors.Green, Colors.Yellow, Colors.Orange);
            rubiksCube.Cubes[2, 0, 0].Position = new Position(new Point3D(1.0f, -1.0f, -1.0f));
            
            rubiksCube.Cubes[0, 0, 2] = CreateTripleFaced(Colors.Green, Colors.White, Colors.Red);
            rubiksCube.Cubes[0, 0, 2].Position = new Position(new Point3D(-1.0f, -1.0f, 1.0f));
            
            rubiksCube.Cubes[2, 0, 2] = CreateTripleFaced(Colors.Green, Colors.Red, Colors.Yellow);
            rubiksCube.Cubes[2, 0, 2].Position = new Position(new Point3D(1.0f, -1.0f, 1.0f));
            
            rubiksCube.Cubes[0, 2, 0] = CreateTripleFaced(Colors.Orange, Colors.Blue, Colors.White);
            rubiksCube.Cubes[0, 2, 0].Position = new Position(new Point3D(-1.0f, 1.0f, -1.0f));
            
            rubiksCube.Cubes[2, 2, 0] = CreateTripleFaced(Colors.Yellow, Colors.Blue, Colors.Orange);
            rubiksCube.Cubes[2, 2, 0].Position = new Position(new Point3D(1.0f, 1.0f, -1.0f));
            
            rubiksCube.Cubes[0, 2, 2] = CreateTripleFaced(Colors.White, Colors.Blue, Colors.Red);
            rubiksCube.Cubes[0, 2, 2].Position = new Position(new Point3D(-1.0f, 1.0f, 1.0f));
            
            rubiksCube.Cubes[2, 2, 2] = CreateTripleFaced(Colors.Red, Colors.Blue, Colors.Yellow);
            rubiksCube.Cubes[2, 2, 2].Position = new Position(new Point3D(1.0f, 1.0f, 1.0f));
        }

        #endregion

        #region Public Methods

        public void Assemble(RubiksCube rubiksCube)
        {
            this.CreateAllSingleFaced(rubiksCube);
            this.CreateAllDoubleFaced(rubiksCube);
            this.CreateAllTripleFaced(rubiksCube);
        }

        #endregion
    }
}
