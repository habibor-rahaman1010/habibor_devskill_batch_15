using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public interface ICamera
    {
        string Model { get; set; }
        string Color { get; set; }

        void TakePhoto(int width, int height);
    }
}
