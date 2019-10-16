using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns
{
    static class Flyweight
    {
        abstract class Unit
        {
            protected int helth; // количество этажей

            public abstract void Attack();
        }

        class Warrior : Unit
        {
            public override void Attack()
            {
                Console.WriteLine("Warrior attack");
            }
        }

        class Archer : Unit
        {
            public override void Attack()
            {
                Console.WriteLine("Archer attack");
            }
        }

        class UnitFactory
        {
            private Dictionary<string, Unit> units = new Dictionary<string, Unit>();

            public UnitFactory()
            {
                units.Add("Warrior", new Warrior());
                units.Add("Archer", new Archer());
            }

            public Unit GetUnit(string unitName)
            {
                if (units.ContainsKey(unitName))
                {
                    return units[unitName];
                }
                else
                {
                    return null;
                }
            }
        }

        static public void Run()
        {
            UnitFactory unitFactory = new UnitFactory();
            List<Unit> army = new List<Unit>();
            army.Add(unitFactory.GetUnit("Warroir"));
            army.Add(unitFactory.GetUnit("Archer"));
            army.Add(unitFactory.GetUnit("Warroir"));
            army.Add(unitFactory.GetUnit("Archer"));
            army.Add(unitFactory.GetUnit("Warroir"));
            Console.WriteLine(army.Count);
        }
    }
}
