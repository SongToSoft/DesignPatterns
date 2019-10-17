using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehaviorPatterns
{
    static class State
    {
        interface IAnimatedStay
        {
            void Idle(Animator animator);
            void Run(Animator animator);
            void Jump(Animator animator);
        }

        class RunAnimation : IAnimatedStay
        {
            public void Idle(Animator animator)
            {
                Console.WriteLine("Character stop");
                animator.animatedStay = new IdleAnimation();
            }

            public void Run(Animator animator)
            {
                Console.WriteLine("Continue Run");
            }

            public void Jump(Animator animator)
            {
                Console.WriteLine("Character jumped");
                animator.animatedStay = new JumpAnimation();
            }
        }

        class IdleAnimation : IAnimatedStay
        {
            public void Idle(Animator animator)
            {
                Console.WriteLine("Character contine idle");
            }

            public void Run(Animator animator)
            {
                Console.WriteLine("Character running");
                animator.animatedStay = new RunAnimation();
            }

            public void Jump(Animator animator)
            {
                Console.WriteLine("Character jumped");
                animator.animatedStay = new JumpAnimation();
            }
        }

        class JumpAnimation : IAnimatedStay
        {
            public void Idle(Animator animator)
            {
                Console.WriteLine("Character landed");
                animator.animatedStay = new IdleAnimation();
            }

            public void Run(Animator animator)
            {
                Console.WriteLine("Character can't running in time jumping");
            }

            public void Jump(Animator animator)
            {
                Console.WriteLine("Character continue jumped");
            }
        }

        class Animator
        {
            public IAnimatedStay animatedStay;

            public Animator()
            {
                animatedStay = new IdleAnimation();
            }

            public void Idle()
            {
                animatedStay.Idle(this);
            }

            public void Run()
            {
                animatedStay.Run(this);
            }

            public void Jump()
            {
                animatedStay.Jump(this);
            }
        }

        static public void Run()
        {
            Console.WriteLine("------------State------------");
            Animator animator = new Animator();
            animator.Run();
            animator.Idle();
            animator.Jump();
            animator.Run();
            animator.Idle();        
            animator.Run();
        }
    }
}
