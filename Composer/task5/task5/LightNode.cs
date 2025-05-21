using System;

namespace task5
{
    public abstract class LightNode
    {
        public abstract string OuterHTML { get; }
        public virtual string InnerHTML => string.Empty;
        public abstract int ChildCount { get; }
    }
}