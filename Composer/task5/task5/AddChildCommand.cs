namespace task5
{
    public class AddChildCommand : ICommand
    {
        private readonly LightElementNode _parent;
        private readonly LightNode _child;

        public AddChildCommand(LightElementNode parent, LightNode child)
        {
            _parent = parent;
            _child = child;
        }

        public void Execute()
        {
            _parent.AddChildInternal(_child);
        }
    }
}
