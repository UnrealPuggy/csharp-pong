using System.Drawing.Text;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Reflection;

namespace Pong.Content
{

    static class FileUtils
    {

        public static List<string> tempFiles = new();
        public static string ExtractEmbeddedAsset(string embeddedPath)
        {
            string resourceName = "pong." + embeddedPath.Replace('/', '.');
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
            if (stream == null)
                throw new Exception("Missing embedded resource: " + resourceName);
            string tempPath = Path.GetTempFileName(); //Path.Combine(Path.GetTempPath(), embeddedPath);
            Directory.CreateDirectory(Path.GetDirectoryName(tempPath)!);
            Console.WriteLine(tempPath);
            using var outFile = File.Create(tempPath);
            stream.CopyTo(outFile);
            tempFiles.Add(tempPath);
            return tempPath; // Now usable by any API that requires a real file
        }

    }
}
