namespace task5
{
    public interface INodeState
    {
        void OnInsert(LightElementNode node);
        void OnRemove(LightElementNode node);
    }
}
