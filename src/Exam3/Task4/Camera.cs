using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class Cannon : ICamera
    {
        public string Model { get; set; }
        public string Color { get; set; }

        public Cannon() : this("Default Model", "Default Color") { }

        public Cannon(string model, string color)
        {
            Model = model;
            Color = color;
        }
 
        public Cannon(string model) : this(model, "Default Color") { }

        public void TakePhoto(int width, int height)
        {
            Console.WriteLine($"Cannon {Model} in {Color} took photo of size: {width}x{height}");
        }
    }
}
