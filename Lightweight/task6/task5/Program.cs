using System.Text;
using task5;

internal class Program
{
    static void Main()
    {
        string url = "https://www.gutenberg.org/cache/epub/1513/pg1513.txt";
        string bookText = DownloadText(url);

        var body = new LightElementNode("body");
        var lines = bookText.Split('\n');

        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;

            string trimmed = line.Trim();
            LightElementNode element;

            if (!bodyHasContent(body))
            {
                element = new LightElementNode("h1");
            }
            else if (trimmed.Length < 20)
            {
                element = new LightElementNode("h2");
            }
            else if (line.StartsWith(" "))
            {
                element = new LightElementNode("blockquote");
            }
            else
            {
                element = new LightElementNode("p");
            }

            element.AddChild(new LightTextNode(trimmed));
            body.AddChild(element);
        }

        string html = new StringBuilder()
            .Append("<!DOCTYPE html><html><head>")
            .Append("<meta charset='UTF-8'><title>Book</title>")
            .Append("</head>")
            .Append(body.OuterHTML)
            .Append("</html>")
            .ToString();

        File.WriteAllText("output.html", html, Encoding.UTF8);
        Console.WriteLine("HTML-файл збережено як output.html");
        Console.WriteLine($"Memory used: {GC.GetTotalMemory(true):N0} bytes");
    }

    static bool bodyHasContent(LightElementNode body) =>
        body.OuterHTML.Length > "<body></body>".Length;

    static string DownloadText(string url)
    {
        using var client = new HttpClient();
        return client.GetStringAsync(url).Result;
    }
}
