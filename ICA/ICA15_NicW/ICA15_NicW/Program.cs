using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICA15_NicW
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Gate[] lGate = { new NANDGate(), new ANDGate(), new ORGate(), new XORGate()};
            foreach(Gate g in lGate)
            {
                Console.WriteLine(Gate.ToTable(g));
            }
            Console.ReadLine();
            Console.Clear();

            //Main program
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"A B C D  O");

            ANDGate and = new ANDGate();
            NANDGate nand = new NANDGate();
            ORGate or = new ORGate();
            XORGate xor = new XORGate();

            for(int a = 0; a < 2; a++)
            {
                for (int b = 0; b < 2; b++)
                {
                    for (int c = 0; c < 2; c++)
                    {
                        for (int d = 0; d < 2; d++)
                        {
                            //1
                            and.Set(a == 1, a == 1);
                            and.Latch();
                            //2
                            or.Set(a == 1, b == 1);
                            or.Latch();
                            //3
                            nand.Set(b == 1, c == 1);
                            nand.Latch();
                            //4
                            xor.Set(nand.Output, c == 1);
                            xor.Latch();
                            //5
                            nand.Set(and.Output, or.Output);
                            nand.Latch();
                            //6
                            or.Set(and.Output, nand.Output);
                            //7
                            and.Set(or.Output, xor.Output);
                            or.Latch();
                            and.Latch();
                            //8
                            xor.Set(xor.Output, d == 1);
                            xor.Latch();
                            //9
                            and.Set(or.Output, and.Output);
                            and.Latch();
                            //10
                            or.Set(and.Output, xor.Output);
                            or.Latch();

                            sb.AppendLine($"{a} {b} {c} {d}  {Convert.ToInt32(or.Output)}");
                        }
                    }
                }
            }

            Console.WriteLine(sb.ToString());

            Console.ReadLine();
        }
    }
}
