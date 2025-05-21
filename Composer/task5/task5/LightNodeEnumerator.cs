using System.Collections;
using System.Collections.Generic;

namespace task5
{
    public class LightNodeEnumerator : IEnumerable<LightNode>
    {
        private readonly LightNode _root;

        public LightNodeEnumerator(LightNode root)
        {
            _root = root;
        }

        public IEnumerator<LightNode> GetEnumerator()
        {
            return Traverse(_root).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private IEnumerable<LightNode> Traverse(LightNode node)
        {
            yield return node;

            if (node is LightElementNode element)
            {
                foreach (var child in element.Children)
                {
                    foreach (var descendant in Traverse(child))
                        yield return descendant;
                }
            }
        }
    }
}
