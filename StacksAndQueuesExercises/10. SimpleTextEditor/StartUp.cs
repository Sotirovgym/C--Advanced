namespace _10._SimpleTextEditor
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class StartUp
    {
        static void Main()
        {
            var commandsCount = int.Parse(Console.ReadLine());

            var textEditor = new StringBuilder();

            var oldVersion = new Stack<string>();

            for (int i = 0; i < commandsCount; i++)
            {
                var inputParams = Console.ReadLine().Split(' ');
                var command = int.Parse(inputParams[0]);

                switch (command)
                {
                    case 1:
                        oldVersion.Push(textEditor.ToString());
                        var parameter = inputParams[1];
                        textEditor.Append(parameter);
                        break;
                    case 2:
                        oldVersion.Push(textEditor.ToString());
                        var length = int.Parse(inputParams[1]);
                        textEditor.Remove(textEditor.Length - length, length);
                        break;
                    case 3:
                        var index = int.Parse(inputParams[1]);
                        Console.WriteLine(textEditor[index - 1].ToString());
                        break;
                    case 4:
                        textEditor.Clear();
                        textEditor.Append(oldVersion.Pop());
                        break;
                }
            }
        }
    }
}
