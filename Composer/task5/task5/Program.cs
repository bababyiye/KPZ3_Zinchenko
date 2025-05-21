using task5;

static void Main(string[] args)
{
    var root = new LightElementNode("div", DisplayType.Block, ClosureType.OpenAndClose);
    root.AddCssClassInternal("hook-test");

    var span = new LightElementNode("span", DisplayType.Inline, ClosureType.OpenAndClose);
    root.AddChildInternal(span);

    var txt = new LightTextNode("Hello Hooks!");
    span.AddChildInternal(txt);

    Console.WriteLine(root.OuterHTML);

    foreach (var node in root.Traverse())
    {
        Console.WriteLine(node.GetType().Name + ": " + node.OuterHTML);
    }

    Console.ReadKey();
}
