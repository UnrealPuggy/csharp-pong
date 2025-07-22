using Pong.Content;

namespace Pong;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        Console.WriteLine("Starting Pong!");
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new Form1());

        AppDomain.CurrentDomain.ProcessExit += (s, e) =>
        {
            foreach (string file in FileUtils.tempFiles)
            {
                File.Delete(file);
            }
        };
    }
}