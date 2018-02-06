namespace _03._WordCount
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        static void Main()
        {
            using (var reader = new StreamReader("text.txt"))
            {
                using (var wordsToCount = new StreamReader("words.txt"))
                {
                    using (var writer = new StreamWriter("result.txt"))
                    {
                        var wordsCounter = new Dictionary<string, int>();

                        var word = string.Empty;
                        while ((word = wordsToCount.ReadLine()) != null)
                        {
                            wordsCounter[word] = 0;
                        }

                        var matchList = Regex.Matches(reader.ReadToEnd().ToLower(), @"[a-z A-Z]+");
                        var sentences = matchList
                            .Cast<Match>()
                            .Select(m => m.Value
                                .Split(new[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries))
                            .ToArray();

                        for (int row = 0; row < sentences.Length; row++)
                        {
                            for (int col = 0; col < sentences[row].Length; col++)
                            {
                                var currentWord = sentences[row][col];

                                if (wordsCounter.ContainsKey(currentWord))
                                {
                                    wordsCounter[currentWord]++;
                                }
                            }
                        }

                        wordsCounter = wordsCounter
                            .OrderByDescending(w => w.Value)
                            .ToDictionary(x => x.Key, x => x.Value);

                        foreach (var wordCount in wordsCounter)
                        {
                            writer.WriteLine($"{wordCount.Key} - {wordCount.Value}");
                        }
                    }
                }
            }
        }
    }
}
