using System;

namespace DesignPatterns.GenerativePatterns
{
    static class Singleton
    {
        class WorldCreator
        {
            private static WorldCreator instance;
            private static string worldName;
  
            private WorldCreator(string _worldName)
            {
                worldName = _worldName;
            }

            public static WorldCreator Instance(string _worldName = "")
            {
                if (instance == null)
                {
                    instance = new WorldCreator(_worldName);
                }
                return instance;
            }
 
            public void Create()
            {
                Console.WriteLine(worldName + " was created");
            }

        }

        static public void Run()
        {
            Console.WriteLine("------------Singleton------------");
            //Two way for use Singleton
            //1
            WorldCreator worldCreator = WorldCreator.Instance("Mario World");
            worldCreator.Create();
            //2
            WorldCreator.Instance("Mario World");
            WorldCreator.Instance().Create();

            //The world name don't be changed
            worldCreator = WorldCreator.Instance("Yoshi's World");
            worldCreator.Create();
        }
    }
}
