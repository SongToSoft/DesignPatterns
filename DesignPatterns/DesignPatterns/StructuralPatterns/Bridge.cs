using System;

namespace DesignPatterns.StructuralPatterns
{
    static class Bridge
    {
        interface IFoodExtraction
        {
            void Waiting();
            void Production();
            void Butchering();
        }

        class Hunting : IFoodExtraction
        {
            public void Waiting()
            {
                Console.WriteLine("Beast tracking");
            }

            public void Production()
            {
                Console.WriteLine("Shooting in the beast");
            }

            public void Butchering()
            {
                Console.WriteLine("Butchering beast");
            }
        }

        class Fishsing : IFoodExtraction
        {
            public void Waiting()
            {
                Console.WriteLine("Waiting for fish");
            }

            public void Production()
            {
                Console.WriteLine("Getting fish");
            }

            public void Butchering()
            {
                Console.WriteLine("Fish cleaning");
            }
        }

        class Men
        {
            public IFoodExtraction FoodExtracting { set; get; }

            public Men(IFoodExtraction _foodExtracting)
            {
                FoodExtracting = _foodExtracting;
            }

            public virtual void Do()
            {
                FoodExtracting.Waiting();
                FoodExtracting.Production();
                FoodExtracting.Butchering();
            }
        }

        static public void Run()
        {
            Console.WriteLine("------------Bridge------------");
            Men men = new Men(new Hunting());
            men.Do();

            men.FoodExtracting = new Fishsing();
            men.Do();          
        }
    }
}
