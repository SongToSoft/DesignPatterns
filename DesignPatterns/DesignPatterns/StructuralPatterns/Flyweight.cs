using System;
using System.Collections.Generic;

namespace DesignPatterns.StructuralPatterns
{
    static class Flyweight
    {
        abstract class House
        {
            protected int floorsNumber; // количество этажей

            public abstract void Build();
        }

        class WoodHouse : House
        {            
            public override void Build()
            {
                floorsNumber = 3;
                Console.WriteLine("Wood House was builded");
            }
        }

        class BrickHouse : House
        {
            public override void Build()
            {
                Console.WriteLine("Brick House was builded");
            }
        }

        class HouseFactory
        {
            private Dictionary<string, House> houses = new Dictionary<string, House>();

            public HouseFactory()
            {
                houses.Add("Wood", new WoodHouse());
                houses.Add("Brick", new BrickHouse());
            }

            public House GetUnit(string unitName)
            {
                if (houses.ContainsKey(unitName))
                {
                    return houses[unitName];
                }
                else
                {
                    return null;
                }
            }
        }

        static public void Run()
        {
            Console.WriteLine("------------Flyweight------------");
            HouseFactory houseFactory = new HouseFactory();
            List<House> streat = new List<House>();
            streat.Add(houseFactory.GetUnit("Wood"));
            streat.Add(houseFactory.GetUnit("Brick"));
            streat.Add(houseFactory.GetUnit("Wood"));
            streat.Add(houseFactory.GetUnit("Brick"));
            streat.Add(houseFactory.GetUnit("Wood"));
            Console.WriteLine(streat.Count);
        }
    }
}
