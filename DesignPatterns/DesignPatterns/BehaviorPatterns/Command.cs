using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehaviorPatterns
{
    static class Command
    {
        interface ICommand
        {
            void Execute();
            void Undo();
        }

        //Receiver
        class Panel
        {
            public void MakeVisible()
            {
                Console.WriteLine("Panel is visible");
            }

            public void MakeInvisible()
            {
                Console.WriteLine("Panel is invisible");
            }
        }

        //Command
        class CertainCommand : ICommand
        {
            Panel panel;

            public CertainCommand(Panel _panel)
            {
                panel = _panel;
            }

            public void Execute()
            {
                panel.MakeVisible();
            }

            public void Undo()
            {
                panel.MakeInvisible();
            }
        }

        //Invoker
        class UIButton
        {
            CertainCommand command;

            public void SetCommand(CertainCommand _command)
            {
                command = _command;
            }

            public void Run()
            {
                command.Execute();
            }

            public void Cancel()
            {
                command.Undo();
            }
        }
  
        static public void Run()
        {
            Console.WriteLine("------------Command------------");
            UIButton invoker = new UIButton();
            Panel receiver = new Panel();
            CertainCommand command = new CertainCommand(receiver);
            invoker.SetCommand(command);
            invoker.Run();
            invoker.Cancel();
        }
    }
}
