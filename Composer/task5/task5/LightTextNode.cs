using System;
using System.Net;

namespace task5
{
    public class LightTextNode : LightNode
    {
        private readonly string _text;

        public LightTextNode(string text)
        {
            _text = text ?? throw new ArgumentNullException(nameof(text));
        }

        public override string OuterHTML => WebUtility.HtmlEncode(_text);
        public override int ChildCount => 0;
    }
}