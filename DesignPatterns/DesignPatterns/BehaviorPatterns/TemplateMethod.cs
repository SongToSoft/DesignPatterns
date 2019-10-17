using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehaviorPatterns
{
    static class TemplateMethod
    {
        abstract class Vehice
        {
            public void Cycle()
            {
                Refueling();
                Move();
            }
            public abstract void Refueling();
            public abstract void Move();
        }

        class Car : Vehice
        {
            public override void Refueling()
            {
                Console.WriteLine("Gas refueling");
            }

            public override void Move()
            {
                Console.WriteLine("Drive");
            }
        }

        class ElectricBike : Vehice
        {
            public override void Refueling()
            {
                Console.WriteLine("Electric charge");
            }

            public override void Move()
            {
                Console.WriteLine("Rides");
            }
        }

        static public void Run()
        {
            Console.WriteLine("------------TemplateMethod------------");
            Car car = new Car();
            car.Cycle();

            ElectricBike electricBike = new ElectricBike();
            electricBike.Cycle();
        }
    }
}
