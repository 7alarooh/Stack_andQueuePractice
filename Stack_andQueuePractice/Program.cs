
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Stack_andQueuePractice
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Task 1: Evaluate Postfix Expression
            //Write a program that evaluates a mathematical expression in postfix notation(also known as Reverse Polish
            //Notation). The expression consists of operands and operators +, -, *, /.The program should return the result of the
            //expression.
            Stack S1 = new Stack();
           // S1.Push("5 1 2 + 4 * + 3 -");
            S1.Push('-');
            S1.Push(3);
            S1.Push('+');
            S1.Push('*');
            S1.Push(4);
            S1.Push('+');
            S1.Push(2);
            S1.Push(1);
            S1.Push(5);
            Stack S2 = new Stack();

            int n1, n2;
            foreach (var x in S1)
            {
               // var TopItem = S1.Peek();
                if (x is int)
                {
                    //S1.Pop();
                    S2.Push(x);
                }
                else { if (x is char op) 
                    {
                        if (op == '+')
                        {
                            n1 = (int)S2.Pop();
                            n2 = (int)S2.Pop();
                            S2.Push(n1 + n2);


                        }
                        if (op == '-')
                        {
                            n1 = (int)S2.Pop();
                            n2 = (int)S2.Pop();
                            S2.Push(n1 - n2);


                        }
                        if (op == '*')
                        {
                            n1 = (int)S2.Pop();
                            n2 = (int)S2.Pop();
                            S2.Push(n1 * n2);


                        }
                        if (op == '/')
                        {
                            n1 = (int)S2.Pop();
                            n2 = (int)S2.Pop();
                            S2.Push(n1 + n2);


                        }
                    } }
            }

            int result = (int)S2.Pop();
            Console.WriteLine(result);



            //            Task 2: Reverse a String Using a Stack
            //Write a program that takes a string as input and uses a stack to reverse it.Print the reversed string.
            //Example Input: Input: "hello" Example Output: Output: "olleh"
            Stack<char> reverse = new Stack<char>();
            Console.WriteLine("type any text to Reverse: ");
            string word=Console.ReadLine();
            foreach (char l in word) {
                reverse.Push(l);
            }
            while (reverse.Count > 0)
            {
                Console.Write(reverse.Pop());
            }



            //            Task 3: Check for Balanced Parentheses
            //Write a program to check whether a string of parentheses is balanced.Use a stack to solve this problem.You need
            //to ensure that for every opening parenthesis(, there is a corresponding closing parenthesis).
            //Example Input:
            //• Input: "(())"
            //Example Output:
            //• Output: Balanced
            //Example Input:
            //• Input: "(()"
            //Example Output:
            //• Output: Not Balanced

            Stack<char> reverseText = new Stack<char>();
            Console.WriteLine("type any text to Reverse: ");
            string Input = Console.ReadLine();
            bool isBalanced = true;

            //foreach (char ch in Input)
            //{
            //    if (ch == '(')
            //    {
            //        // Push opening parentheses to the stack
            //        reverseText.Push(ch);
            //    }
            //    else if (ch == ')')
            //    {
            //        // If stack is empty, it means there's no matching opening parenthesis
            //        if (reverseText.Count == 0)
            //        {
            //            isBalanced = false;
            //            break;
            //        }

        }
    }
}
