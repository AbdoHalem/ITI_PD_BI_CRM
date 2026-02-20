using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class Task5
    {
        public abstract class Animal
        {
            public abstract void MakeSound();
            public abstract void Move();
        }
        public class Dog : Animal
        {
            public override void MakeSound()
            {
                Console.WriteLine("Woof! Woof!");
            }
            public override void Move()
            {
                Console.WriteLine("Running on four legs!");
            }
        }
        public class Cat : Animal
        {
            public override void MakeSound()
            {
                Console.WriteLine("Meow! Meow!");
            }
            public override void Move()
            {
                Console.WriteLine("Walking on four legs!");
            }
        }
        public class Bird : Animal
        {
            public override void MakeSound()
            {
                Console.WriteLine("Tweet! Tweet!");
            }
            public override void Move()
            {
                Console.WriteLine("Flying on four legs!");
            }
        }
        public static void task5()
        {
            Dog dog = new Dog();
            Cat cat = new Cat();
            Bird bird = new Bird();
            dog.MakeSound();
            dog.Move();
            cat.MakeSound();
            cat.Move();
            bird.MakeSound();
            bird.Move();
        }
    }
}
