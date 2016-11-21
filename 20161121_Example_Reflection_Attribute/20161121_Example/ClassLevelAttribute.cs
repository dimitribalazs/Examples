using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH.Example._20161121
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true, Inherited = false)]
    public sealed class ClassLevelAttribute : Attribute
    {
        public string Name { get; set; }
        public int IntegerProperty { get; set; }

        public Type TypeWorkingFor { get; set; }

        public bool IsImplementingInterface(Type type)
        {
            if(type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            if(!type.IsInterface)
            {
                throw new ArgumentException("Argument " + nameof(type) + "is not an interface");
            }

            if(TypeWorkingFor == null)
            {
                throw new InvalidOperationException(string.Format(BFH.Example._20161121.Properties.Resources.InvalidTypeWorkingFor, nameof(TypeWorkingFor)));
            }

            //type.GetInterface
            return type.IsAssignableFrom(TypeWorkingFor);
        }
    }
}
