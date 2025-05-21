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

            Console.WriteLine("\n[DOM]");
            Console.WriteLine(root.OuterHTML);

            Console.WriteLine("\n[Traversal]");
            foreach (var node in root.Traverse())
            {
                Console.WriteLine(node.GetType().Name + ": " + node.OuterHTML);
            }

            Console.WriteLine("\n[Visitor]");
            var visitor = new NodeCountVisitor();
            root.Accept(visitor);
            visitor.PrintSummary();

            Console.ReadKey();
        }
    }
}
