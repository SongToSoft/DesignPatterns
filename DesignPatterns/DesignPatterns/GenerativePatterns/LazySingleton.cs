using System;

namespace DesignPatterns.GenerativePatterns
{
    class LazySingleton
    {
        class WorldCreator
        {
            private static Lazy<WorldCreator> instance;
            private static string worldName;

            private void SetName(string _worldName)
            {
                worldName = _worldName;
            }
  
            public static WorldCreator Instance(string _worldName = "")
            {
                if (instance == null)
                {
                    instance = new Lazy<WorldCreator>();
                    instance.Value.SetName(_worldName);
                }
                return instance.Value;
            }

            public void Create()
            {
                Console.WriteLine(worldName + " was created");
            }

        }

        static public void Run()
        {
            Console.WriteLine("------------LazySingleton------------");
            WorldCreator.Instance("Mario World");
            WorldCreator.Instance().Create();

            //The world name don't be changed
            WorldCreator.Instance("Yoshi's World");
            WorldCreator.Instance().Create();
        }
    }
}
