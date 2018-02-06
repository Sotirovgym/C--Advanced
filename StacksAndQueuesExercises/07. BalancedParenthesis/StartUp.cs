namespace _07._BalancedParenthesis
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            var input = Console.ReadLine();

            var brackets = new Stack<char>();

            var openBrackets = new char[] { '(', '[', '{' };
            var closeBrackets = new char[] { ')', ']', '}' };

            if (input.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                Environment.Exit(0);
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(' || input[i] == '[' || input[i] == '{')
                {
                    brackets.Push(input[i]);
                }
                else
                {
                    var openBracketIndex = Array.IndexOf(openBrackets, brackets.Pop());
                    var closeBracketIndex = Array.IndexOf(closeBrackets, input[i]);

                    if (openBracketIndex == closeBracketIndex)
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("NO");
                        Environment.Exit(0);
                    }
                }
            }

            Console.WriteLine("YES");
        }
    }
}
