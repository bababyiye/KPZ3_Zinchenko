namespace task5
{
    public class AddClassCommand : ICommand
    {
        private readonly LightElementNode _target;
        private readonly string _cssClass;

        public AddClassCommand(LightElementNode target, string cssClass)
        {
            _target = target;
            _cssClass = cssClass;
        }

        public void Execute()
        {
            _target.AddCssClassInternal(_cssClass);
        }
    }
}
