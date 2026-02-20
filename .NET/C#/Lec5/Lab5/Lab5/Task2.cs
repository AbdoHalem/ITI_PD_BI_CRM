using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    internal class Task2
    {
        public class Rectangle
        {
            int _id;
            public Rectangle(int width, int height)
            {
                Width = width;
                Height = height;
                Id = 1; // Example of setting read-only property in constructor
            }
            // Auto-implemented properties
            public int Width { get; set; }
            public int Height { get; set; }
            // Auto-implemented properties with default values
            public string Color { get; set; } = "White";
            public string Unit { get; set; } = "cm";
            // Read-only (set only in constructor)
            public int Id { get; }
            // Computed property
            public double Area => Width * Height;
        }
        //===================================
        public static void task2()
        {
            Rectangle rect = new Rectangle(10, 20);
            Console.WriteLine($"Default values of color = {rect.Color}, unit = {rect.Unit}");
            rect.Color = "Blue";
            rect.Unit = "inches";
            Console.WriteLine($"Rectangle ID: {rect.Id}");
            Console.WriteLine($"Width: {rect.Width} {rect.Unit}");
            Console.WriteLine($"Height: {rect.Height} {rect.Unit}");
            Console.WriteLine($"Color: {rect.Color}");
            Console.WriteLine($"Area: {rect.Area} {rect.Unit}²");
        }
    }
}
