namespace task5
{
    public abstract class LightNode
    {
        public INodeState State { get; private set; }

        protected LightNode()
        {
            State = new CreatedState();
            OnCreated();
        }

        public abstract string OuterHTML { get; }
        public virtual string InnerHTML => string.Empty;
        public abstract int ChildCount { get; }

        protected virtual void OnCreated() { }
        protected virtual void OnInserted() { }
        protected virtual void OnRemoved() { }
        protected virtual void OnClassListApplied() { }
        protected virtual void OnTextRendered() { }

        public void SetState(INodeState state)
        {
            State = state;
        }

        public abstract void Accept(IVisitor visitor);

        public IEnumerable<LightNode> Traverse()
        {
            return new LightNodeEnumerator(this);
        }
    }
}
