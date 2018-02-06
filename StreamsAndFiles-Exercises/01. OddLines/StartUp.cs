namespace StreamsAndFiles_Exercises
{
    using System;
    using System.IO;

    public class StartUp
    {
        static void Main()
        {
            var reader = new StreamReader("text.txt");

            var line = string.Empty;
            var counter = 0;

            while ((line = reader.ReadLine()) != null)
            {
                if (counter % 2 != 0)
                {
                    Console.WriteLine(line);
                }
                counter++;
            }
        }
    }
}
