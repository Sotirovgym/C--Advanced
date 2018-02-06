namespace _04._CopyBinaryFile
{
    using System.IO;

    public class StartUp
    {
        static void Main()
        {
            using (var sourceFile = new FileStream("copyMe.png", FileMode.Open))
            {
                using (var destinationFile = new FileStream("result.png", FileMode.Create))
                {
                    var buffer = new byte[4096];
                    while (true)
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
