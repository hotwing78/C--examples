using System;

namespace BinaryTreeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string expression = "((3*(8-2))-(1+9))";
            while (expression != "")
            {
                BinaryExpressionTree bet = new BinaryExpressionTree(expression);
                Console.Write("Infix: ");
                bet.DisplayInOrder();
                Console.Write("Postfix: ");
                bet.DisplayPostOrder();
                Console.Write("Prefix: ");
                bet.DisplayPreOrder();
                Console.WriteLine("{0} = {1}", expression, bet.Eval());


                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Enter a new expression or leave blank, hit enter to quit");
                expression = Console.ReadLine();
            }
        }
    }
}
