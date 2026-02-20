using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class Task4
    {
        public class Shape
        {
            protected int length;
            public Shape(int length)
            {
                this.Length = length;
            }
            public int Length
            {
                set
                {
                    if (value <= 0)
                        throw new ArgumentException("Length must be positive.");
                    this.length = value;
                }
                get { return this.length; }
            }
            public virtual double CalaculateArea()
            {
                return 0;
            }
            public virtual double CalaculatePerimeter()
            {
                return 0;
            }
        }
        // Derived Class: Rectangle
        public class Rectangle : Shape
        {
            private int width;
            public Rectangle(int length, int width) : base(length)
            {
                this.width = width;
            }
            public int Width
            {
                set
                {
                    if (value <= 0)
                        throw new ArgumentException("Width must be positive.");
                    this.width = value;
                }
                get { return this.width; }
            }
            public override double CalaculateArea()
            {
                return Length * this.width;
            }
            public override double CalaculatePerimeter()
            {
                return this.width * Length;
            }
        }
        // Derived Class: Circle
        public class Circle : Shape
        {
            public Circle(int radius) : base(radius)
            {
            }
            public override double CalaculateArea()
            {
                return Math.PI * Length * Length;
            }
            public override double CalaculatePerimeter()
            {
                return 2 * Math.PI * Length;
            }
        }
        // Derived Class: Triangle
        public class Triangle : Shape
        {
            private int width;
            private int height;

            public Triangle(int width, int length, int height): base(length)
            {
                this.Width = width;
                this.Height = height;
            }
            public int Width
            {
                set
                {
                    if (value <= 0)
                        throw new ArgumentException("Width must be positive.");
                    this.width = value;
                }
                get { return this.width; }
            }
            public int Height
            {
                set
                {
                    if (value <= 0)
                        throw new ArgumentException("Width must be positive.");
                    this.height = value;
                }
                get { return this.height; }
            }
            // Override methods
            public override double CalaculateArea()
            {
                return 0.5 * Length * Height;
            }
            public override double CalaculatePerimeter()
            {
                return Length + Width + Height;
            }
        }
        public static void task4()
        {
            Circle c = new Circle(5);
            Console.WriteLine("Circle Area = " + c.CalaculateArea());
            Console.WriteLine("Circle Perimeter = " + c.CalaculatePerimeter());
            Rectangle rect = new Rectangle(4, 5);
            Console.WriteLine("Rectangle Area = " + rect.CalaculateArea());
            Console.WriteLine("Rectangle Perimeter = " + rect.CalaculatePerimeter());
            Triangle tri = new Triangle(3, 4, 5);
            Console.WriteLine("Triangle Area = " + tri.CalaculateArea());
            Console.WriteLine("Triangle Perimeter = " + tri.CalaculatePerimeter());
        }
    }
}
