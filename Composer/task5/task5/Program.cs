using System;

namespace task5
{
    class Program
    {
        static void Main(string[] args)
        {
            var table = new LightElementNode("table", DisplayType.Block, ClosureType.OpenAndClose);
            table.AddCssClass("my-table");
            table.AddCssClass("table-bordered");

            var tr1 = new LightElementNode("tr", DisplayType.Block, ClosureType.OpenAndClose);

            var td11 = new LightElementNode("td", DisplayType.Inline, ClosureType.OpenAndClose);
            td11.AddCssClass("cell");
            td11.AddChild(new LightTextNode("Рядок 1, Стовпець 1"));
            tr1.AddChild(td11);

            var td12 = new LightElementNode("td", DisplayType.Inline, ClosureType.OpenAndClose);
            td12.AddCssClass("cell");
            td12.AddChild(new LightTextNode("Рядок 1, Стовпець 2"));
            tr1.AddChild(td12);

            table.AddChild(tr1);

            var tr2 = new LightElementNode("tr", DisplayType.Block, ClosureType.OpenAndClose);

            var td21 = new LightElementNode("td", DisplayType.Inline, ClosureType.OpenAndClose);
            td21.AddCssClass("cell");
            td21.AddChild(new LightTextNode("Рядок 2, Стовпець 1"));
            tr2.AddChild(td21);

            var td22 = new LightElementNode("td", DisplayType.Inline, ClosureType.OpenAndClose);
            td22.AddCssClass("cell");
            td22.AddChild(new LightTextNode("Рядок 2, Стовпець 2"));
            tr2.AddChild(td22);

            table.AddChild(tr2);

            Console.WriteLine(table.OuterHTML);

            var img = new LightElementNode("img", DisplayType.Inline, ClosureType.SelfClosing);
            img.AddCssClass("responsive");
            Console.WriteLine(img.OuterHTML);

            Console.ReadKey();
        }
    }
}
