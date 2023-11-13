using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.ALL_Classes
{
    public class RubiksCube
    {
        public CubeFace[,] Faces { get; set; }

        public RubiksCube(int size)
        {
            Faces = new CubeFace[size, size];
            InitializeCube(size);
        }

        private void InitializeCube(int size)
        {
            foreach (StickerColor color in Enum.GetValues(typeof(StickerColor)))
            {
                Faces[(int)color, 0] = new CubeFace(size, color);
            }
        }

        public void RotateRow(int row, bool clockwise)
        {
            throw new NotImplementedException();
        }

        public void RotateColumn(int column, bool clockwise)
        {
            throw new NotImplementedException();
        }

        public void DisplayCube()
        {
            foreach (var face in Faces)
            {
                Console.WriteLine($"Rubiks Cube Face Color: {face.Stickers[0, 0].Color}");
            }
        }
    }
}
