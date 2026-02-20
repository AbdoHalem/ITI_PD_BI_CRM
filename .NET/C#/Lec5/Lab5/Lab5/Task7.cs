using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    internal class Task7
    {
        public class Calculator
        {
            // Methods
            public int Divide(int num1, int num2)
            {
                return num1 / num2;
            }
        }
        // ==========================
        public static void task7()
        {
            Calculator calc = new Calculator();
            try
            {
                double result = calc.Divide(10, 0);
            }
            catch(DivideByZeroException ex)
            {
                Console.WriteLine("Can not divide by zero");
            }
            catch(FormatException ex)
            {
                Console.WriteLine("Invalid number format! ");
            }
            catch (Exception ex) // General catch - MUST be last!
            {
                Console.WriteLine("Unknown error!");
            }
        }
    }
}
