// See https://aka.ms/new-console-template for more information
using Task4;

Console.WriteLine("Hello, World!");
Cannon defaultCannon = new Cannon(); 
Cannon colorCannon = new Cannon("Color Model", "Red"); 
Cannon modelOnlyCannon = new Cannon("Coustom Model");

defaultCannon.TakePhoto(800, 600);
colorCannon.TakePhoto(1200, 800);
modelOnlyCannon.TakePhoto(1024, 768);