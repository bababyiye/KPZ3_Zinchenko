using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace task3
{
    public interface IObserver
    {
        void Update(string eventName, LightElementNode element);
    }
}
