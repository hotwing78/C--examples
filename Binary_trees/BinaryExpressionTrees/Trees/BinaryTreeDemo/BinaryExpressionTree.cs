using System;

namespace BinaryTreeDemo
{
    class BinaryExpressionTree
    {
        public int Count { get; set; }
        public BinaryNode<char> rootNode { get; private set; }
        private string origExpression;

        public BinaryExpressionTree(String expression)
        {
            origExpression = expression;
            rootNode = Parse(ref expression);
        }
        
        public BinaryNode<char> Parse(ref string expression)
        {
            BinaryNode<char> myNode = new BinaryNode<char>();
            char nextChar;

            // consume the paren
           
            expression = expression.Substring(1);
            nextChar = expression[0];
            
            // possibilities are left paren or value
            if (nextChar == '(')
            {    
                // todo -- action if left side is an expression
                myNode.left = Parse(ref expression);
            }
            else
            {
                
                // todo -- action if left side is a value     
                
                    myNode.left = new BinaryNode<char>(nextChar);
                    expression = expression.Substring(1);
                
                    // todo -- don't forget to consume the value 
                
            }

            // should be at operand
            // todo -- deal with the operand
            nextChar = expression[0];
            myNode.item = nextChar;
            myNode.ToString();
            // todo -- consume the operator
            expression = expression.Substring(1);

            // possibilities are left paren or value
            // todo -- get nextChar
            nextChar = expression[0];
            if (nextChar == '(')
            {
                // todo -- action if left side is an expression
                myNode.right = Parse(ref expression);
            }
            else
            {
                // todo -- action if left side is a value
               
                    myNode.right = new BinaryNode<char>(nextChar);
                    expression = expression.Substring(1);
                
                // todo -- don't forget to consume the value         
            }
            // consume the right paren
            expression = expression.Substring(1);
            return myNode;
        }

        public void DisplayPreOrder()
        {
            if (rootNode != null)
            {
                DisplayPreOrder(rootNode);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Tree is empty.");
            }
        }

        private void DisplayPreOrder(BinaryNode<char> node)
        {
            Console.Write(node.item);
            if (node.left != null)
            {
               
                DisplayPreOrder(node.left);
            }
            
            if (node.right != null)
            {
                DisplayPreOrder(node.right);
                
            }
        }
        
        public void DisplayPostOrder()
        {
            if (rootNode != null)
            {
                DisplayPostOrder(rootNode);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Tree is empty.");
            }
        }

        private void DisplayPostOrder(BinaryNode<char> node)
        {
            
            if (node.left != null)
            {

                DisplayPostOrder(node.left);
            }

            if (node.right != null)
            {
                DisplayPostOrder(node.right);

            }
            Console.Write(node.item);
        }
        

        public double Eval()
        {
            return Eval(rootNode);
        }

        private double Eval(BinaryNode<char> node)
        {
            double value = 0;
            if (node.isLeaf())
            {
                // cheap way to convert a single digit number to an integer
                value = node.item - '0';
            }
            else
            switch (node.item)
            {
                case '+':
                    // evaluate operator
                    value = (Eval(node.left) + Eval(node.right));
                    break;
                case '-':
                    // evaluate operator
                    value = (Eval(node.left) - Eval(node.right));
                    break;
                case '*':
                    // evaluate operator
                    value = (Eval(node.left) * Eval(node.right));
                    break;
                case '/':
                    // evaluate operator
                    value = (Eval(node.left) / Eval(node.right));
                    break;
                default:
                    Console.WriteLine("Invalid OP {0}", node.item);
                    value = 0;
                    break;
            }

            return value;
        }

        public void DisplayInOrder()
        {
            if (rootNode != null)
            {
                DisplayInOrder(rootNode);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Tree is empty.");
            }
        }

        private void DisplayInOrder(BinaryNode<char> node)
        {
            if (node.left != null)
            {
                Console.Write('(');
                DisplayInOrder(node.left);
            }
            Console.Write(node.item);
            if (node.right != null)
            {
                DisplayInOrder(node.right);
                Console.Write(')');
            }
        }

    }
}
