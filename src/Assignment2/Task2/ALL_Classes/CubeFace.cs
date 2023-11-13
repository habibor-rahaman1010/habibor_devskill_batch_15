using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.ALL_Classes
{
    public class CubeFace
    {
        public Sticker[,] Stickers { get; set; }

        public CubeFace(int size, StickerColor color)
        {
            Stickers = new Sticker[size, size];
            InitializeFace(color);
        }

        private void InitializeFace(StickerColor color)
        {
            int size = Stickers.GetLength(0);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Stickers[i, j] = new Sticker(color);
                }
            }
        }
    }
}
