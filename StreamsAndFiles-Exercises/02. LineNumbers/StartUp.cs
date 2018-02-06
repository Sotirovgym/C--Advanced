namespace _02._LineNumbers
{
    using System.IO;

    public class StartUp
    {
        static void Main()
        {
            using (var reader = new StreamReader("text.txt"))
            {
                var line = string.Empty;
                var counter = 1;

                using (var writer = new StreamWriter("result.txt"))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        writer.WriteLine($"Line {counter}: {line}");
                        counter++;
                    }
                }
            }
        }
    }
}
