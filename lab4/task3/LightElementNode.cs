using System;
using System.Collections.Generic;
using System.Linq;

namespace task3
{
    public class LightElementNode : LightNode, ISubject
    {
        private readonly Dictionary<string, List<IObserver>> _observers = new();

        public string TagName { get; }
        public bool IsBlock { get; }
        public bool IsSelfClosing { get; }
        public List<string> CssClasses { get; } = new();
        public List<LightNode> Children { get; } = new();

        public LightElementNode(string tagName, bool isBlock = true, bool isSelfClosing = false)
        {
            TagName = tagName;
            IsBlock = isBlock;
            IsSelfClosing = isSelfClosing;
        }

        public void AddClass(string className) => CssClasses.Add(className);
        public void AddChild(LightNode child) => Children.Add(child);

        public void Attach(string eventName, IObserver observer)
        {
            if (!_observers.TryGetValue(eventName, out var list))
                _observers[eventName] = list = new List<IObserver>();
            list.Add(observer);
        }

        public void Detach(string eventName, IObserver observer)
        {
            if (_observers.TryGetValue(eventName, out var list))
                list.Remove(observer);
        }

        public void Notify(string eventName)
        {
            if (_observers.TryGetValue(eventName, out var list))
                foreach (var obs in list)
                    obs.Update(eventName, this);
        }

        public void DispatchEvent(string eventName) => Notify(eventName);

        public override string InnerHTML => string.Concat(Children.Select(c => c.OuterHTML));

        public override string OuterHTML
        {
            get
            {
                var classAttr = CssClasses.Any()
                    ? $" class=\"{string.Join(' ', CssClasses)}\""
                    : string.Empty;

                return IsSelfClosing
                    ? $"<{TagName}{classAttr}/>"
                    : $"<{TagName}{classAttr}>{InnerHTML}</{TagName}>";
            }
        }
    }
}
