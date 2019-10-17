using System;

namespace DesignPatterns.GenerativePatterns
{
    static class Prototype
    {
        abstract class Unit
        {
            protected int attack;
            protected int x, y;

            public Unit(int _x, int _y)
            {
                x = _x;
                y = _y;
            }
            
            public void Info()
            {
                Console.WriteLine("Attack: " + attack + ", Position: X = " + x + ", Y = " + y);
            }

            abstract public Unit Clone();
        }

        class Warrior : Unit
        {
            public Warrior(int _x, int _y) : base(_x, _y)
            {
                attack = 10;
            }
            public override Unit Clone()
            {
                return new Warrior(x, y);
            }
        }

        class Archer : Unit
        {
            public Archer(int _x, int _y) : base(_x, _y)
            {
                attack = 5;
            }
            public override Unit Clone()
            {
                return new Archer(x, y);
            }
        }

        static public void Run()
        {
            Console.WriteLine("------------Prototype------------");
            Unit unit;
            Warrior warrior = new Warrior(-10, 15);
            unit = warrior.Clone();
            unit.Info();

            Archer archer = new Archer(4, 9);
            unit = archer.Clone();
            unit.Info();
        }
    }
}
