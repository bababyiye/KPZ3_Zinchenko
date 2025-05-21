using System;

namespace task5
{
    public class NodeCountVisitor : IVisitor
    {
        public int ElementCount { get; private set; }
        public int TextNodeCount { get; private set; }

        public void VisitElement(LightElementNode element)
        {
            ElementCount++;
        }

        public void VisitText(LightTextNode text)
        {
            TextNodeCount++;
        }

        public void PrintSummary()
        {
            Console.WriteLine($"[Visitor] Element nodes: {ElementCount}");
            Console.WriteLine($"[Visitor] Text nodes: {TextNodeCount}");
        }
    }
}
