using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.ALL_Classes
{
    public enum StickerColor
    {
        Red,
        Blue,
        Green,
        White,
        Yellow,
        Orange
    }
    public class Sticker
    {
        public StickerColor Color { get; set; }

        public Sticker(StickerColor color)
        {
            Color = color;
        }
    }
}
