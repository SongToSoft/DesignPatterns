using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehaviorPatterns
{
    static class Strategy
    {
        interface IMovable
        {
            void Move();
        }
        
        class Car : IMovable
        {
            public void Move()
            {
                Console.WriteLine("Drive");
            }
        }

        class Airplane : IMovable
        {
            public void Move()
            {
                Console.WriteLine("Fly");
            }
        }

        class Person
        {
            private IMovable transport;

            public Person(IMovable _transport)
            {
                transport = _transport;
            }

            public void Move()
            {
                transport.Move();
            }
        }

        static public void Run()
        {
            Person person = new Person(new Car());
            person.Move();

            person = new Person(new Airplane());
            person.Move();
        }
    }
}
