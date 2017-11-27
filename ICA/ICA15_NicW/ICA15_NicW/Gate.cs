using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICA15_NicW
{
    abstract class Gate
    {
        //Our input and output members
        protected bool inputA;
        protected bool inputB;
        protected bool output;
        //Public interface to read our members
        public bool InputA { get { return inputA; } }
        public bool InputB { get { return inputB; } }
        public bool Output { get { return output; } }

        //Set the values of A and B inputs
        public void Set(bool A, bool B)
        {
            inputA = A;
            inputB = B;
        }

        //latch will set the output, as determined by gate type and inputs
        protected abstract void latch();
        public void Latch() { latch(); }

        //Name of gate type
        protected abstract string name();
        public string Name() { return name(); }

        //Returns the truth table for the gate
        public static string ToTable(Gate gate)
        {
            //We are building the string to output
            StringBuilder sb = new StringBuilder();

            //Start with the top line, inputs and output
            sb.AppendLine($"A B  {gate.Name()}");

            //Each input used and output generated
            for(int a = 0; a < 2; a++)
            {
                for(int b = 0; b < 2; b++)
                {
                    gate.Set(a == 1, b == 1); //Set the inputs of the gate, where true is 1
                    gate.latch();             //Sets the output
                    sb.AppendLine($"{a} {b}  {Convert.ToInt32(gate.output)}"); //Adds the input/output line
                }
            }

            return sb.ToString();
        }
    }

    class NANDGate : Gate
    {
        protected override string name()
        {
            return "NAND";
        }

        protected override void latch()
        {
            output = !(inputA & inputB);
        }
    }

    class ANDGate : NANDGate
    {
        protected override string name()
        {
            return "AND";
        }
        protected override void latch()
        {
            base.latch();
            output = !output;
        }
    }

    class ORGate : Gate
    {
        protected override string name()
        {
            return "OR";
        }
        protected override void latch()
        {
            output = (inputA | inputB);
        }
    }

    class XORGate : Gate
    {
        protected override string name()
        {
            return "XOR";
        }
        protected override void latch()
        {
            output = (inputA ^ inputB);
        }
    }
}
