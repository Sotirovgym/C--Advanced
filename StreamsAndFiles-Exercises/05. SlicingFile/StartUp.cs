namespace _05._SlicingFile
{
    using System;
    using System.IO;

    public class StartUp
    {
        static void Main()
        {
            var inputPartsCount = int.Parse(Console.ReadLine());

            Slice(inputPartsCount);

            Assemble(inputPartsCount);
        }

        private static void Assemble(int inputPartsCount)
        {
            using (var destinationFile = new FileStream("CombinedResult/combinedFile.mp4", FileMode.Create))
            {
                for (int counter = 1; counter <= inputPartsCount; counter++)
                {
                    using (var sourceFile = new FileStream($"SlisedResult/sliceResult{counter}.mp4", FileMode.Open))
                    {
                        var buffer = new byte[sourceFile.Length];
                        var readBytesCount = sourceFile.Read(buffer, 0, buffer.Length);

                        if (readBytesCount == 0)
                        {
                            break;
                        }
                        else
                        {
                            destinationFile.Write(buffer, 0, buffer.Length);
                        }
                    }
                }
            }
        }

        private static void Slice(int inputPartsCount)
        {
            using (var sourceFile = new FileStream("sliceMe.mp4", FileMode.Open))
            {
                var bufferSize = sourceFile.Length / inputPartsCount + sourceFile.Length % inputPartsCount;
                var buffer = new byte[bufferSize];

                for (int counter = 1; counter <= inputPartsCount; counter++)
                {
                    using (var destinationFile = new FileStream($"SlisedResult/sliceResult{counter}.mp4", FileMode.Create))
                    {
                        var readBytesCount = sourceFile.Read(buffer, 0, buffer.Length);

                        if (readBytesCount == 0)
                        {
                            break;
                        }
                        else
                        {
                            destinationFile.Write(buffer, 0, buffer.Length);
                        }
                    }
                }
            }
        }
    }
}
