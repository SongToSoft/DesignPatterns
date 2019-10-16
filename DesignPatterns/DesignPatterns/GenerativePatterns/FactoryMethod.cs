using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.GenerativePatterns
{
    static public class FactoryMethod
    {
        abstract class Item
        {
            public abstract void Equip();
        }

        class Armor : Item
        {
            public override void Equip()
            {
                Console.WriteLine("Equip Armor");
            }
        }

        class Weapon : Item
        {
            public override void Equip()
            {
                Console.WriteLine("Equip Weapon");
            }
        }

        abstract class Smith
        {
            public abstract Item Create();
        }

        class WeaponSmith : Smith
        {
            public override Item Create()
            {
                return new Weapon();
            }
        }

        class ArmorSmith : Smith
        {
            public override Item Create()
            {
                return new Armor();
            }
        }

        static public void Run()
        {
            Smith smith = new ArmorSmith();
            Item item = smith.Create();
            item.Equip();

            smith = new WeaponSmith();
            item = smith.Create();
            item.Equip();
        }
    }
}
