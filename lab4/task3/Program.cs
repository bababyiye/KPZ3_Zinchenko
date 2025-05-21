﻿using System;
using System.Linq;
using task3;

namespace task3
{
    internal class Program
    {
        private static void Main()
        {
            var div = new LightElementNode("div");
            div.AddClass("container");
            div.Attach("click", new EventObserver((ev, el) =>
                Console.WriteLine($"[{el.TagName}] was clicked.")));

            var ul = new LightElementNode("ul");
            ul.AddClass("list");

            for (int i = 1; i <= 3; i++)
            {
                var li = new LightElementNode("li");
                li.AddChild(new LightTextNode($"Item {i}"));
                li.Attach("mouseover", new EventObserver((ev, el) =>
                    Console.WriteLine($"Mouse over on {el.TagName}: {((LightTextNode)el.Children[0]).InnerHTML}")));
                ul.AddChild(li);
            }

            div.AddChild(ul);
            Console.WriteLine(div.OuterHTML);

            Console.WriteLine("Simulating Events");
            div.DispatchEvent("click");
            foreach (var li in ul.Children.OfType<LightElementNode>())
                li.DispatchEvent("mouseover");
        }
    }
}
