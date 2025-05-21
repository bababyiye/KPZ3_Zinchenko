using System;
using System.Collections.Generic;
using System.Text;

namespace task5
{
    public class LightElementNode : LightNode
    {
        public string TagName { get; }
        public DisplayType Display { get; set; }
        public ClosureType Closure { get; set; }
        private readonly List<string> _cssClasses = new List<string>();
        private readonly List<LightNode> _children = new List<LightNode>();

        public LightElementNode(string tagName,
                                DisplayType display = DisplayType.Block,
                                ClosureType closure = ClosureType.OpenAndClose)
        {
            if (string.IsNullOrWhiteSpace(tagName))
                throw new ArgumentException("Ім'я тега не може бути порожнім.", nameof(tagName));

            TagName = tagName.Trim().ToLowerInvariant();
            Display = display;
            Closure = closure;
        }

        public void AddCssClass(string cssClass)
        {
            if (string.IsNullOrWhiteSpace(cssClass))
                return;

            cssClass = cssClass.Trim();
            if (!_cssClasses.Contains(cssClass))
                _cssClasses.Add(cssClass);
        }

        public void AddChild(LightNode child)
        {
            if (child == null)
                throw new ArgumentNullException(nameof(child));

            _children.Add(child);
        }

        public override int ChildCount => _children.Count;

        public override string InnerHTML
        {
            get
            {
                if (Closure == ClosureType.SelfClosing)
                    return string.Empty;

                var sb = new StringBuilder();
                foreach (var child in _children)
                {
                    sb.Append(child.OuterHTML);
                }
                return sb.ToString();
            }
        }

        private string BuildClassAttribute()
        {
            if (_cssClasses.Count == 0)
                return string.Empty;

            string joined = string.Join(" ", _cssClasses);
            return $" class=\"{joined}\"";
        }

        public override string OuterHTML
        {
            get
            {
                string classAttr = BuildClassAttribute();

                if (Closure == ClosureType.SelfClosing)
                {
                    return $"<{TagName}{classAttr} />";
                }
                else
                {
                    return $"<{TagName}{classAttr}>{InnerHTML}</{TagName}>";
                }
            }
        }
    }
}