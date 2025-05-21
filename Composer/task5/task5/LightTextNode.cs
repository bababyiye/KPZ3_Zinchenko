using System.Net;

namespace task5
{
    public class LightTextNode : LightNode
    {
        private readonly string _text;

        public LightTextNode(string text)
        {
            _text = text;
            OnTextRendered();
        }

        public override string OuterHTML => WebUtility.HtmlEncode(_text);
        public override int ChildCount => 0;

        protected override void OnCreated() { }
        protected override void OnInserted() { }
        protected override void OnRemoved() { }
        protected override void OnClassListApplied() { }

        public override void Accept(IVisitor visitor)
        {
            visitor.VisitText(this);
        }
    }
}
