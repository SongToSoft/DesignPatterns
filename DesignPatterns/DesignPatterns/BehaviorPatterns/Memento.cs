using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehaviorPatterns
{
    static class Memento
    {
        class ComputerSystem
        {
            public string Version { get; set; }

            public ComputerSystem(string version)
            {
                Version = version;
            }
   
            public RestorePoint CreateSystemPoint()
            {
                return new RestorePoint(Version);
            }

            public void RestoreSystem(RestorePoint pointRestore)
            {
                Version = pointRestore.Version;
            }
        }

        class RestorePoint
        {
            public string Version { get; set; }

            public RestorePoint(string version)
            {
                Version = version;
            }
        }

        class SystemHistory
        {
            public Stack<RestorePoint> Points { get; set; }

            public SystemHistory()
            {
                Points = new Stack<RestorePoint>();
            }
        }
        static public void Run()
        {
            ComputerSystem computerSystem = new ComputerSystem("4.12");
            SystemHistory history = new SystemHistory();

            history.Points.Push(computerSystem.CreateSystemPoint());

            computerSystem.Version = "5.01";
            Console.WriteLine("New Version: " + computerSystem.Version);

            computerSystem.RestoreSystem(history.Points.Pop());
            Console.WriteLine("Version after restore: " + computerSystem.Version);
        }
    }
}
