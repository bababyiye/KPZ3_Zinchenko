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
        public IReadOnlyList<LightNode> Children => _children;

        public LightElementNode(string tagName,
                                DisplayType display = DisplayType.Block,
                                ClosureType closure = ClosureType.OpenAndClose)
        {
            TagName = tagName.Trim().ToLowerInvariant();
            Display = display;
            Closure = closure;
        }

        public void AddCssClassInternal(string cssClass)
        {
            if (string.IsNullOrWhiteSpace(cssClass)) return;
            cssClass = cssClass.Trim();
            if (!_cssClasses.Contains(cssClass))
                _cssClasses.Add(cssClass);
            OnClassListApplied();
        }

        public void AddChildInternal(LightNode child)
        {
            if (child == null) throw new ArgumentNullException(nameof(child));
            _children.Add(child);
            State.OnInsert(this);
            OnInserted();
        }

        public void RemoveChildInternal(LightNode child)
        {
            if (_children.Remove(child))
            {
                State.OnRemove(this);
                OnRemoved();
            }
        }

        protected override void OnCreated()
        {
            Console.WriteLine($"[{TagName}] created.");
        }

        protected override void OnInserted()
        {
            Console.WriteLine($"[{TagName}] inserted into tree.");
        }

        protected override void OnRemoved()
        {
            Console.WriteLine($"[{TagName}] removed from tree.");
        }

        protected override void OnClassListApplied()
        {
            Console.WriteLine($"[{TagName}] CSS class list updated.");
        }

        protected override void OnTextRendered() { }

        public override int ChildCount => _children.Count;

        public override string InnerHTML
        {
            get
            {
                if (Closure == ClosureType.SelfClosing) return string.Empty;
                var sb = new StringBuilder();
                foreach (var child in _children)
                    sb.Append(child.OuterHTML);
                return sb.ToString();
            }
        }

        private string BuildClassAttribute()
        {
            if (_cssClasses.Count == 0) return string.Empty;
            string joined = string.Join(" ", _cssClasses);
            return $" class=\"{joined}\"";
        }

        public override string OuterHTML
        {
            get
            {
                string classAttr = BuildClassAttribute();
                if (Closure == ClosureType.SelfClosing)
                    return $"<{TagName}{classAttr} />";
                else
                    return $"<{TagName}{classAttr}>{InnerHTML}</{TagName}>";
            }
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.VisitElement(this);
            foreach (var child in _children)
                child.Accept(visitor);
        }
    }
}
