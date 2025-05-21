namespace task5
{
    public class CreatedState : INodeState
    {
        public void OnInsert(LightElementNode node)
        {
            node.SetState(new InsertedState());
        }
        public void OnRemove(LightElementNode node) { }
    }

    public class InsertedState : INodeState
    {
        public void OnInsert(LightElementNode node) { }
        public void OnRemove(LightElementNode node)
        {
            node.SetState(new RemovedState());
        }
    }

    public class RemovedState : INodeState
    {
        public void OnInsert(LightElementNode node)
        {
            node.SetState(new InsertedState());
        }
        public void OnRemove(LightElementNode node) { }
    }
}
