using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class Task6
    {
        public interface IMovable
        {
            void Move();
            void Stop();
            int GetSpeed();
        }
        public interface IChargeable
        {

        }
        class Car : IMovable
        {
            private int speed;
            public void Move() { speed = 60; }
            public void Stop() { speed = 0; }
            public int GetSpeed() { return speed; }
        }
        class Robot : IMovable, IChargeable
        {
            private int speed;
            public void Move() { speed = 10; }
            public void Stop() { speed = 0; }
            public int GetSpeed() { return speed; }
        }
        public static void task6()
        {
            Car car = new Car();
            car.Move();
            Console.WriteLine($"Car Speed = {car.GetSpeed()}");
            Robot robotr = new Robot();
            robotr.Move();
            Console.WriteLine($"Robot Speed = {robotr.GetSpeed()}");
        }
    }
}
