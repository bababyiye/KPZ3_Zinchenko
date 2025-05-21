using System;

namespace task5
{
    class Program
    {
        static void Main(string[] args)
        {
            var root = new LightElementNode("div", DisplayType.Block, ClosureType.OpenAndClose);
            root.AddCssClassInternal("hook-test");
            var span = new LightElementNode("span", DisplayType.Inline, ClosureType.OpenAndClose);
            root.AddChildInternal(span);
            var txt = new LightTextNode("Hello Hooks!");
            span.AddChildInternal(txt);
            Console.WriteLine(root.OuterHTML);
            Console.ReadKey();
        }
    }
}
