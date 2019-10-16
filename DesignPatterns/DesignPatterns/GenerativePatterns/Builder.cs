using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.GenerativePatterns
{
    static class Builder
    {
        class Hero
        {
            public Hero()
            {
                Console.WriteLine("Hero was created");
            }
        }

        class Enemy
        {
            public Enemy()
            {
                Console.WriteLine("Enemy was created");
            }
        }

        class Chest
        {
            public Chest()
            {
                Console.WriteLine("Chest was created");
            }
        }

        abstract class LevelBuilder
        {
            protected Hero hero;
            protected List<Enemy> enemyes = new List<Enemy>();
            protected List<Chest> chest = new List<Chest>();

            protected void AddHero()
            {
                hero = new Hero();
            }

            protected void AddEnemyes(int num)
            {
                for (int i = 0; i < num; ++i)
                {
                    enemyes.Add(new Enemy());
                }
            }

            protected void AddChest(int num)
            {
                for (int i = 0; i < num; ++i)
                {
                    chest.Add(new Chest());
                }
            }

            abstract public void Create();
        }

        class BonusLevelBuilder : LevelBuilder
        {
            public override void Create()
            {
                AddHero();
                AddChest(5);
                Console.WriteLine("Bonus Level was create");
            }
        }
    
        class SimpleLevelBuilder : LevelBuilder
        {
            public override void Create()
            {
                AddHero();
                AddChest(1);
                AddEnemyes(5);
                Console.WriteLine("Simple Level was create");
            }
        }

        static public void Run()
        {
            LevelBuilder levelBuilder = new SimpleLevelBuilder();
            levelBuilder.Create();

            levelBuilder = new BonusLevelBuilder();
            levelBuilder.Create();
        }
    }
}
