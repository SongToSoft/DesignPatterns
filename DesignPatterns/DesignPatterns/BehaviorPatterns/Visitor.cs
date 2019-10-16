using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehaviorPatterns
{
    static class Visitor
    {

        interface IVisitor
        {
            void VisitFootballer(Footballer footballer);
            void VisitManager(Manager manager);
        }

        class RaiseSalary : IVisitor
        {
            public void VisitFootballer(Footballer footballer)
            {
                footballer.Salary += 10;
                Console.WriteLine("Salary of footballer increase by 10 million");
            }

            public void VisitManager(Manager manager)
            {
                Console.WriteLine("Manager will be fired");
            }
        }

        class SendOnVacation : IVisitor
        {
            public void VisitFootballer(Footballer footballer)
            {
                footballer.Salary += 10;
                Console.WriteLine("Footballer send on vacation");
            }

            public void VisitManager(Manager manager)
            {
                Console.WriteLine("... No");
            }
        }

        class Club
        {
            List<IPerson> persons = new List<IPerson>();
       
            public void Add(IPerson acc)
            {
                persons.Add(acc);
            }

            public void Remove(IPerson acc)
            {
                persons.Remove(acc);
            }

            public void Accept(IVisitor visitor)
            {
                foreach (IPerson person in persons)
                {
                    person.Execute(visitor);
                }
            }
        }

        interface IPerson
        {
            void Execute(IVisitor visitor);
        }

        class Footballer : IPerson
        {
            public int Salary { get; set; }

            public void Execute(IVisitor visitor)
            {
                visitor.VisitFootballer(this);
            }
        }

        class Manager : IPerson
        {
            public int Salary { get; set; }

            public void Execute(IVisitor visitor)
            {
                visitor.VisitManager(this);
            }
        }

        static public void Run()
        {
            Club club = new Club();
            club.Add(new Footballer { Salary = 100 });
            club.Add(new Footballer { Salary = 200 });
            club.Add(new Manager { Salary = 10 });
            club.Accept(new SendOnVacation());
            club.Accept(new RaiseSalary());

            Console.Read();
        }
    }
}
