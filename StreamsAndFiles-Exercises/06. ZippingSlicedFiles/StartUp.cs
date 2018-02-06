namespace _06._ZippingSlicedFiles
{
    using System;
    using System.IO;
    using System.IO.Compression;

    public class StartUp
    {
        static void Main()
        {
            var inputPartsCount = int.Parse(Console.ReadLine());

            using (var sourceFile = new FileStream("sliceMe.mp4", FileMode.Open))
            {
                using (var destinationFile = new FileStream("result.mp4", FileMode.CreateNew))
                {
                    var bufferSize = sourceFile.Length / inputPartsCount + sourceFile.Length % inputPartsCount;
                    var buffer = new byte[bufferSize];

                    Compress(inputPartsCount, sourceFile, buffer);

                    Decompress(inputPartsCount, destinationFile, buffer);
                }
            }
        }

        private static void Decompress(int inputPartsCount, FileStream destinationFile, byte[] buffer)
        {
            for (int counter = 1; counter <= inputPartsCount; counter++)
            {
                using (var parts = new FileStream($"part{counter}.gz", FileMode.Open))
                {
                    using (var deCompressed = new GZipStream(parts, CompressionMode.Decompress))
                    {
                        var bufferLength = deCompressed.Read(buffer, 0, buffer.Length);
                        destinationFile.Write(buffer, 0, bufferLength);
                    }
                }
            }
        }

        private static void Compress(int inputPartsCount, FileStream sourceFile, byte[] buffer)
        {
            for (int counter = 1; counter <= inputPartsCount; counter++)
            {
                using (var part = new FileStream($"part{counter}.gz", FileMode.CreateNew))
                {
                    var readBytes = sourceFile.Read(buffer, 0, buffer.Length);

                    using (var compressedPart = new GZipStream(part, CompressionMode.Compress))
                    {
                        compressedPart.Write(buffer, 0, readBytes);
                    }
                }
            }
        }
    }
}
