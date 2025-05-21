using task4;

internal class Program
{
    private static void Main()
    {
        const string filePath = "test.txt";
        File.WriteAllText(filePath, "Hello\nWorld!");

        Console.WriteLine("Using SmartTextChecker:");
        var checker = new SmartTextChecker(filePath);
        checker.ReadFile();

        Console.WriteLine();
        Console.WriteLine("Using SmartTextLocker:");
        var locker = new SmartTextLocker(filePath, @"forbidden.txt");
        locker.ReadFile();
    }
}