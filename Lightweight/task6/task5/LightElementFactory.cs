using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    public static class LightElementFactory
    {
        public static LightElementNode CreateElement(string tagName)
            => new LightElementNode(tagName);
    }

}
