using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warsztat
{
    public class Option
    {
        public string Name { get; }
        public Action Selected { get; }
 
        public Option(string name)
        {
            Name = name;
        }
    }
}
