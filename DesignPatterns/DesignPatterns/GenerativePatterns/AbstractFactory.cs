using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.GenerativePatterns
{
    static class AbstractFactory
    {
        abstract class Magic
        {
            public abstract void Cast();
        }
   
        abstract class Artifact
        {
            public abstract void Use();
        }

        class FireBall : Magic
        {
            public override void Cast()
            {
                Console.WriteLine("Cast Fireball");
            }
        }

        class BoltLighting : Magic
        {
            public override void Cast()
            {
                Console.WriteLine("Cast Bolt Lighting");
            }
        }

        class MaskOfMadness  : Artifact
        {
            public override void Use()
            {
                Console.WriteLine("Use Mask of Madness");
            }
        }

        class EulOfScepter : Artifact
        {
            public override void Use()
            {
                Console.WriteLine("Use Eul of Scepter");
            }
        }
        
        abstract class HeroFactory
        {
            public abstract Magic CreateMagic();
            public abstract Artifact CreateArtifact();
        }

        class MagicHeroFactory : HeroFactory
        {
            public override Magic CreateMagic()
            {
                return new BoltLighting();
            }

            public override Artifact CreateArtifact()
            {
                return new EulOfScepter();
            }
        }

        class AgilityHeroFactory : HeroFactory
        {
            public override Magic CreateMagic()
            {
                return new FireBall();
            }

            public override Artifact CreateArtifact()
            {
                return new MaskOfMadness();
            }
        }

        class Hero
        {
            private Magic magic;
            private Artifact artifact;
            
            public Hero(HeroFactory heroFactory)
            {
                magic = heroFactory.CreateMagic();
                artifact = heroFactory.CreateArtifact();
            }

            public void Cast()
            {
                magic.Cast();
            }

            public void Use()
            {
                artifact.Use();
            }
        }

        static public void Run()
        {
            Console.WriteLine("------------AbstractFactory------------");
            HeroFactory heroFactory = new MagicHeroFactory();
            Hero hero = new Hero(heroFactory);
            hero.Cast();
            hero.Use();

            heroFactory = new AgilityHeroFactory();
            hero = new Hero(heroFactory);
            hero.Cast();
            hero.Use();
        }
    }
}
