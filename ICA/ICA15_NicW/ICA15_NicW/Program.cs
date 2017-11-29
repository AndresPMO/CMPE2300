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

            //Truth Tables
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

            Gate[] circuit = {new ANDGate(), new ORGate(), new NANDGate(), new XORGate(), new NANDGate(), new ORGate(), new ANDGate(), new XORGate(), new ANDGate(), new ORGate()};

            for(int a = 0; a < 2; a++)
            {
                for (int b = 0; b < 2; b++)
                {
                    for (int c = 0; c < 2; c++)
                    {
                        for (int d = 0; d < 2; d++)
                        {
                            //1
                            circuit[0].Set(a == 1, a == 1);
                            circuit[0].Latch();
                            //2
                            circuit[1].Set(a == 1, b == 1);
                            circuit[1].Latch();
                            //3
                            circuit[2].Set(b == 1, c == 1);
                            circuit[2].Latch();
                            //4
                            circuit[3].Set(circuit[2].Output, c == 1);
                            circuit[3].Latch();
                            //5
                            circuit[4].Set(circuit[0].Output, circuit[1].Output);
                            circuit[4].Latch();
                            //6
                            circuit[5].Set(circuit[0].Output, circuit[4].Output);
                            circuit[5].Latch();
                            //7
                            circuit[6].Set(circuit[1].Output, circuit[3].Output);
                            circuit[6].Latch();
                            //8
                            circuit[7].Set(circuit[3].Output, d == 1);
                            circuit[7].Latch();
                            //9
                            circuit[8].Set(circuit[5].Output, circuit[6].Output);
                            circuit[8].Latch();
                            //10
                            circuit[9].Set(circuit[8].Output, circuit[7].Output);
                            circuit[9].Latch();

                            sb.AppendLine($"{a} {b} {c} {d}  {Convert.ToInt32(circuit[9].Output)}");
                        }
                    }
                }
            }

            Console.WriteLine(sb.ToString());

            Console.ReadLine();
        }
    }
}
