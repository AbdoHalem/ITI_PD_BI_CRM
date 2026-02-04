using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public delegate double MathOperation(double a, double b);
    internal class Task1
    {
        public class Calculator
        {
            public static double Add(double a, double b)
            {
                return a + b;
            }
            public static double Subtract(double a, double b)
            {
                return a - b;
            }
            public static double Multiply(double a, double b)
            {
                return a * b;
            }
            public static double Divide(double a, double b)
            {
                return a / b;
            }
        }
        public static void task1()
        {
            MathOperation operation = Calculator.Add;
            Console.WriteLine("Add:" + operation(10, 5));
            operation = Calculator.Subtract;
            Console.WriteLine("Subtract:" + operation(10, 5));
            operation = Calculator.Multiply;
            Console.WriteLine("Multiply:" + operation(10, 5));
            operation = Calculator.Divide;
            Console.WriteLine("Divide:" + operation(10, 5));
        }
    }

    
}
