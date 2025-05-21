using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    public class LightElementNode : LightNode
    {
        private readonly string _tagName;
        private readonly List<LightNode> _children = new List<LightNode>();

        public LightElementNode(string tagName) => _tagName = tagName;

        public void AddChild(LightNode child) => _children.Add(child);

        public override string OuterHTML =>
            $"<{_tagName}>{string.Concat(_children.Select(c => c.OuterHTML))}</{_tagName}>";
    }
}
