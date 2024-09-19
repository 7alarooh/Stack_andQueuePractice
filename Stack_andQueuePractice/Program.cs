
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Formats.Asn1.AsnWriter;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Stack_andQueuePractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ////////////////////////////////////
            ///////////1. Stack /////////
            ////////////////////////////////////

            //Task 1: Evaluate Postfix Expression
            //Write a program that evaluates a mathematical expression in postfix notation(also known as Reverse Polish
            //Notation). The expression consists of operands and operators +, -, *, /.The program should return the result of the
            //expression.
            Stack S1 = new Stack();
            Console.WriteLine("to give solve this:\"5 1 2 + 4 * + 3 -\" by using Evaluate Postfix Expression");
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
                else
                {
                    if (x is char op)
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
                            if (n1 > n2)
                            {
                                S2.Push(n1 - n2);
                            }
                            else { S2.Push(n2 - n1); }
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
                            S2.Push(n1 / n2);
                        }
                    }
                }
            }

            int result = (int)S2.Pop();
            Console.WriteLine(result);



            //            Task 2: Reverse a String Using a Stack
            //Write a program that takes a string as input and uses a stack to reverse it.Print the reversed string.
            //Example Input: Input: "hello" Example Output: Output: "olleh"
            Console.WriteLine("Reverse a String Using a Stack");
            Stack<char> reverse = new Stack<char>();
            Console.WriteLine("type any text to Reverse: ");
            string word = Console.ReadLine();
            foreach (char l in word)
            {
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
            Console.WriteLine("\n\nCheck for Balanced Parentheses");

            Stack<char> Balanced = new Stack<char>();
            Console.WriteLine("type any text to Reverse: ");
            string Input = Console.ReadLine();
            bool isBalanced = true;

            foreach (char ch in Input)
            {
                if (ch == '(')
                {
                    // Push opening parentheses to the stack
                    Balanced.Push(ch);
                }
                else if (ch == ')')
                {
                    // If stack is empty, it means there's no matching opening parenthesis
                    if (Balanced.Count == 0)
                    {
                        isBalanced = false;
                        break;
                    }

                    // Pop the matching opening parenthesis from the stack
                    Balanced.Pop();
                }
            }
            // If stack is not empty, it means there are unmatched opening parentheses
            if (Balanced.Count > 0)
            {
                isBalanced = false;
            }

            // Display the result
            if (isBalanced)
            {
                Console.WriteLine("The parentheses are balanced.");
            }
            else
            {
                Console.WriteLine("The parentheses are not balanced.");
            }

            //            Task 4: Find the Maximum Element in a Stack
            //Write a program that uses a stack to store integers. Implement a function Max() that returns the maximum value in
            //the stack at any given time, in addition to the basic stack operations Push() and Pop().

            Console.WriteLine("\n\n Find the Maximum Element in a Stack");

            Stack<int> numbers = new Stack<int>();
            Console.WriteLine("\n\n Type number of digits ,you will Enter:");
            int numberDigits = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberDigits; i++)
            {

                Console.WriteLine($" enter digit ({i + 1}):");
                int number = int.Parse(Console.ReadLine());
                numbers.Push(number);
            }
            Console.Write("\n The Maximum number in a Stack :");
            int maxnumber = 0;
            foreach (int n in numbers)
            {
                if (n > maxnumber)
                    maxnumber = n;
            }
            Console.Write(maxnumber);

            //        Bonus: Sort a Stack Using Another Stack
            //Given a stack, write a function to sort the elements in ascending order using only one additional stack. You may
            //use additional variables but you are not allowed to use arrays or other data structures.
            Console.WriteLine("\n\n Sort a Stack Using Another Stack");
            Stack<int> sortNum = new Stack<int>();
            Console.WriteLine("\n\n Type number of digits ,you will Enter:");
            int numDigits = int.Parse(Console.ReadLine());

            for (int i = 0; i < numDigits; i++)
            {
                Console.WriteLine($" enter digit ({i + 1}):");
                int number = int.Parse(Console.ReadLine());
                sortNum.Push(number);
            }
            int count= 0;
            int maxToAdd ;
            while (count< numDigits)
            {
                maxToAdd=int.MinValue;
                Stack<int> tempStack = new Stack<int>(); // Temporary stack to hold elements during the search for max

                // Find the maximum element in sortNum
                while (sortNum.Count > count)
                {
                    int current = sortNum.Pop();

                    if (current > maxToAdd)
                    {
                        maxToAdd = current;
                    }

                    tempStack.Push(current);
                }

                // Push elements back to sortNum, except for the maximum element
                bool maxPushed = false; // To ensure only one instance of max is removed
                while (tempStack.Count > 0)
                {
                    int tempValue = tempStack.Pop();

                    // Skip pushing the maximum element once
                    if (tempValue == maxToAdd && !maxPushed)
                    {
                        maxPushed = true; // Mark max as pushed
                        continue; // Skip this element
                    }

                    sortNum.Push(tempValue);
                }

                // Push the maximum element to the sorted stack
                sortNum.Push(maxToAdd);
                count++;
            }

            // Output the sorted stack
            Console.WriteLine("\nSorted stack in ascending order:");
            while (sortNum.Count > 0)
            {
                Console.Write(sortNum.Pop() + " ");
            }
            ////////////////////////////////////
            ///////////2.  Queue////////////////
            ////////////////////////////////////

            //            Task 1: Reverse a Queue
            //Write a function that takes a queue of integers as input and reverses the order of its elements.You should
            //only use the queue's basic operations (Enqueue, Dequeue) and an auxiliary stack.
            //Example Input:
            //• Queue: 1, 2, 3, 4, 5
            //Example Output:
            //• Reversed Queue: 5, 4, 3, 2, 1

            Console.WriteLine("\n\n Reverse a Queue");
            Queue<int> Q1 = new Queue<int>();
            Stack<int> tempQueue = new Stack<int>();
            Console.WriteLine("\n\n Type number of digits ,you will Enter:");
            int no = int.Parse(Console.ReadLine());
            for (int i = 0; i < no; i++)
            {
                Console.WriteLine($" enter digit ({i + 1}):");
                int number = int.Parse(Console.ReadLine());
                Q1.Enqueue(number);
            }


            while (Q1.Count > 0)
            {
                tempQueue.Push(Q1.Dequeue());
            }
            while (tempQueue.Count > 0)
            {
                Q1.Enqueue(tempQueue.Pop());
            }
            foreach (int i in Q1) {
                
               Console.Write( i +" ");
            }

            //            Task 2: Check if a Queue is a Palindrome
            //Write a function that checks whether a queue is a palindrome. A palindrome is a sequence that reads the
            //same backward as forward.You can only use queue operations(Enqueue, Dequeue) and a stack to help with
            //the check.
            //Example Input:
            //• Queue: 1, 2, 3, 2, 1
            //Example Output:
            //• Output: True
            Console.WriteLine("\n\n Check if a Queue is a Palindrome");
            Queue<int> Q2 = new Queue<int>();
            Stack<int> CheckQueue = new Stack<int>();
            Console.WriteLine("\n\n Type number of digits ,you will Enter:");
            int numnum = int.Parse(Console.ReadLine());
            for (int i = 0; i < numnum; i++)
            {
                Console.WriteLine($" enter digit ({i + 1}):");
                int number = int.Parse(Console.ReadLine());
                Q1.Enqueue(number);
            }

            foreach (int num in Q2)
            {
                CheckQueue.Push(num);
            }

            // Check if the queue is a palindrome
            bool test = true;
            foreach (int num in Q2)
            {
                if (num != CheckQueue.Pop())
                {
                    test = false;
                    break;
                }
            }

            Console.WriteLine(test);


            //        Bonus: Find the Maximum Element in a Sliding Window of Size K
            //Write a program that processes an array of integers and finds the maximum element in each sliding window of
            //size K. Use a deque to efficiently solve the problem.
            //Example Input:
            //• Array: [1, 3, -1, -3, 5, 3, 6, 7]
            //• K = 3
            //Example Output:
            //• Output: [3, 3, 5, 5, 6, 7]
            Console.WriteLine("\n\n Find the Maximum Element in a Sliding Window of Size K");
            Queue<int> Array = new Queue<int>();
            Queue<int> resultMaxk = new Queue<int>();
            Console.WriteLine("\n\n Type number of digits ,you will Enter:");
            int numnum1 = int.Parse(Console.ReadLine());
            for (int i = 0; i < numnum1; i++)
            {
                Console.WriteLine($" enter digit ({i + 1}):");
                int number = int.Parse(Console.ReadLine());
                Array.Enqueue(number);
            }

            while (Array.Count > 0)
            { if (Array.Count < 3)
                {
                    int maxnn;
                    int nn1 = Array.Dequeue();
                    int nn2 = Array.Dequeue();
                    int nn3 = Array.Dequeue();
                    if (nn1 > nn2) { if (nn1 > 3) maxnn = nn1; else maxnn = nn3; }
                    else if (nn2 > nn3) { maxnn = nn2; } else { maxnn = nn3; }
                    resultMaxk.Enqueue(maxnn);
                    Array.Enqueue((int)nn2);
                    Array.Enqueue((int)nn3);
                }
            }
            foreach (int i in resultMaxk)
            {

                Console.Write(i + " ");
            }

        }
    }
}
