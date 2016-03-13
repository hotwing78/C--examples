using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stacks
{
    class SimpleCalculator
    {
        Stack<char> operators;
        Stack<int> operands;
        public SimpleCalculator()
        {
            operators = new Stack<char>();
            operands = new Stack<int>();
        }

        public int getValue(char op, int val1, int val2)
        {
            int value = 0;
            switch (op)
            {
                case '+': value = val1 + val2; break;
                case '-': value = val1 - val2; break;
                case '/': value = val1 / val2; break;
                case '*': value = val1 * val2; break;
                default: Console.WriteLine("Unknown Operand: {0}", op); break;
            }
            return value;
        }

        public int evaluate(string expression)
        {
            foreach (char c in expression)
            {
                if (char.IsDigit(c))
                {
                    Console.WriteLine("Digit: {0}", c);
                    operands.Push(int.Parse(c.ToString()));
                }
                else if (c == ')')
                {
                    char op = (char)operators.Pop();
                    int val2 = (int)operands.Pop();
                    int val1 = (int)operands.Pop();
                    operands.Push(getValue(op, val1, val2));
                }
                else if ("+-*/".Contains(c))
                {
                    operators.Push(c);
                }
                else
                {
                    Console.WriteLine("Other: {0}", c);
                }
            }

            if (operands.Count > 0)
                return (int)operands.Pop();
            return 999999999;
        }

        static void Main(string[] args)
        {
            SimpleCalculator calc = new SimpleCalculator();
            int num = calc.evaluate("(7+((4-6)*2))");
            Console.WriteLine("answer: " + num);
        }
    }

}
