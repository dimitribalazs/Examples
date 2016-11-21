using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH.Example._20161121
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false, Inherited = false)]
    public sealed class AssemblyLevelAttribute : Attribute
    {
        public string Name { get; }
        public string Description { get; set; }
        public AssemblyLevelAttribute(string name)
        {
            Name = name;
        }
    }
}
