using BFH.Example._20161121;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _20161121_Example_Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (Type type in typeof(Demo).Assembly.GetTypes())
            {
                Console.WriteLine($"Found type {type}");
                foreach (MemberInfo info in type.GetMembers(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance))
                {
                    Console.WriteLine($" - {info.Name}");
                    if (info is ConstructorInfo)
                    {
                        foreach (ParameterInfo paramInfo in ((ConstructorInfo)info).GetParameters())
                        {
                            Console.WriteLine($"     -> {paramInfo.Name}: {paramInfo.ParameterType.Name}");
                        }
                    }
                }
            }

            Console.WriteLine();

            //create and us an instance using reflection
            object demoObject = Activator.CreateInstance(typeof(Demo));
            PropertyInfo propInfo = demoObject.GetType().GetProperty("IntegerProperty");
            propInfo.SetValue(demoObject, 42);

            Console.WriteLine("Property Value " + propInfo.GetValue(demoObject));


            //constructor with param
            demoObject = Activator.CreateInstance(typeof(Demo), new object[] { 44 });

            //call method via reflection
            MethodInfo methodInfo = demoObject.GetType().GetMethod(
                "DoSomething",
                new Type[] {
                typeof(int), typeof(string), typeof(DateTime)
             });

            methodInfo.Invoke(demoObject, new object[] { 42, "foo", DateTime.Now });

            Console.ReadKey();
        }
    }
}
