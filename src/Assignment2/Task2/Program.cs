using System;
using Task2.ALL_Classes;

namespace Task2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // here just design oop concept
            int cubeSize = 3;
            RubiksCube rubiksCube = new RubiksCube(cubeSize);
            rubiksCube.DisplayCube();
        }
    }
}