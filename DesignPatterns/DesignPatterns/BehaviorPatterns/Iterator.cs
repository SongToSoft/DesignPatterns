using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehaviorPatterns
{
    static class Iterator
    {
        interface IItemIterator
        {
            bool HasNext();
            bool HasPrevious();
            void Next();
            void Previous();
            Item GetCurrentItem();
        }

        class Item
        {
            public string name;
        }

        class Inventory : IItemIterator
        {
            public Item[] items;
            private int index = 0;

            public bool HasNext()
            {
                return ((index + 1) <= (items.Length - 1));
            }

            public bool HasPrevious()
            {
                return ((index - 1) >= 0);
            }

            public void Next()
            {
                ++index;
            }

            public void Previous()
            {
                --index;
            }

            public Item GetCurrentItem()
            {
                return ((index >= 0) && (index <= (items.Length - 1)) ? items[index] : null);
            }
        }

        static public void Run()
        {
            Console.WriteLine("------------Iterator------------");
            Inventory inventory = new Inventory();
            inventory.items = new Item[]
            {
                new Item{name = "Sword"},
                new Item{name = "Armor"},
                new Item{name = "Helmet"},
                new Item{name = "Bottle"},
            };
            Console.WriteLine(inventory.GetCurrentItem().name);
            do
            {
                inventory.Next();
                Console.WriteLine(inventory.GetCurrentItem().name);
            }
            while (inventory.HasNext());
            Console.WriteLine();
            Console.WriteLine(inventory.GetCurrentItem().name);
            do
            {
                inventory.Previous();
                Console.WriteLine(inventory.GetCurrentItem().name);
            }
            while (inventory.HasPrevious());
        }
    }
}
