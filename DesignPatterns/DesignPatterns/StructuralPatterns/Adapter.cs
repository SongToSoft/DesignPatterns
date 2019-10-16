using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns
{
    static class Adapter
    {
        interface IProgramming
        {
            void Programming();
        }

        class ProgrammingDriver : IProgramming
        {
            public void Programming()
            {
                Console.WriteLine("Write new Driver");
            }
        }

        class Programmer
        {
            public void Execute(IProgramming process)
            {
                process.Programming();
            }
        }

        interface IAutomation
        {
            void Automation();
        }

        class AutomationTesting : IAutomation
        {
            public void Automation()
            {
                Console.WriteLine("Automation testing");
            }
        }

        class AutomationTestingToProgrammingAdapter : IProgramming
        {
            AutomationTesting automationTester;
            public AutomationTestingToProgrammingAdapter(AutomationTesting _automationTester)
            {
                automationTester = _automationTester;
            }

            public void Programming()
            {
                automationTester.Automation();
            }
        }

        static public void Run()
        {
            Programmer programmer = new Programmer();
            ProgrammingDriver programmingDriver = new ProgrammingDriver();

            programmer.Execute(programmingDriver);

            AutomationTesting automationTesting = new AutomationTesting();

            IProgramming adapter = new AutomationTestingToProgrammingAdapter(automationTesting);

            programmer.Execute(adapter);
        }
    }
}
