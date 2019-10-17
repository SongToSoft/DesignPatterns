using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehaviorPatterns
{
    static class Interpreter
    {
        class Context
        {
        }

        abstract class AbstractExpression
        {
            public abstract void Interpret(Context context);
        }

        class TerminalExpression : AbstractExpression
        {
            public override void Interpret(Context context)
            {
            }
        }

        class NonterminalExpression : AbstractExpression
        {
            AbstractExpression expression1;
            AbstractExpression expression2;
            public override void Interpret(Context context)
            {

            }
        }

        static public void Run()
        {
            Console.WriteLine("------------Interpreter------------");
            Context context = new Context();

            var expression = new NonterminalExpression();
            expression.Interpret(context);
        }
    }
}
