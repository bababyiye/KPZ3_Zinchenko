using System.Text;
using task1;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Simple console logger
        ILogger consoleLogger = new Logger();
        consoleLogger.Log("rttrkhyrthr");
        consoleLogger.Error("ergrehyrtytj");
        consoleLogger.Warn("regrthytjtuyutkytuk");

        // File writer usage
        var writer = new FileWriter();
        Console.WriteLine("Файл зберігається тут: " + Path.GetFullPath("file.txt"));
        writer.ClearFile();
        writer.Write("rthrtjytljyt yut jytyt");
        writer.WriteLine("th rthytjytjyu yutjyutj");

        // File logger via adapter
        ILogger fileLogger = new FileLogger(writer);
        fileLogger.Log("reghrtjhrtejtr rthrthrht");
        fileLogger.Error("erg trh rth yr rt y hy juytj ty");
        fileLogger.Warn("r rt rt rt rth trhtrh rt h trhrt");
    }
}