using System;

namespace DesignPatterns.StructuralPatterns
{
    static class Proxy
    {
        //Subject
        interface ISolveMatrix
        {
            void Solve(int[,] matrix);
        }

        //RealSubject
        class KramerSolveMatrix: ISolveMatrix
        {
            public void Solve(int[,] matrix)
            {
                Console.WriteLine("Matrix will be resolve over Kramer method");
            }
        }

        //Proxy
        class ProxySolveMatrix : ISolveMatrix
        {
            KramerSolveMatrix solver;
            public void Solve(int[,] matrix)
            {
                if (matrix.GetLength(0) < 3)
                {
                    if (solver == null)
                    {
                        solver = new KramerSolveMatrix();
                    }
                    solver.Solve(matrix);
                }
                else
                {
                    Console.WriteLine("Matrix will be resolve over Gauss method");
                }
            }
        }

        static public void Run()
        {
            Console.WriteLine("------------Proxy------------");
            int[,] matrixFirst = { { 1, 2 }, { 3, 4 } };
            int[,] matrixSecond = { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, };
            ISolveMatrix solver = new ProxySolveMatrix();
            solver.Solve(matrixFirst);
            solver.Solve(matrixSecond);
        }
    }
}
