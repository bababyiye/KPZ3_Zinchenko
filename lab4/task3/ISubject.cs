using System;
using System.Collections.Generic;

namespace task3
{
    public interface ISubject
    {
        void Attach(string eventName, IObserver observer);
        void Detach(string eventName, IObserver observer);
        void Notify(string eventName);
    }
}
