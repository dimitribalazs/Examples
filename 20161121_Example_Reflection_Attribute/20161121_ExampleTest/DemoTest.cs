using Microsoft.VisualStudio.TestTools.UnitTesting;
using BFH.Example._20161121;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace BFH.Example._20161121.Test
{
    [TestClass()]
    public class DemoTest
    {

        public TestContext TestContext { get; set; }

        [TestMethod()]
        public void CheckAssemblyLevelTest()
        {

            //Arrange som test object
            Assembly assembly = typeof(Demo).Assembly;

            //AssemblyName asmName = assembly.GetName();
            //asmName.Version

            //Act getting the attribute
            object[] attributes = assembly.GetCustomAttributes(false);
            AssemblyLevelAttribute attribute = assembly.GetCustomAttribute<AssemblyLevelAttribute>();


            //Assert the result
            Assert.IsNotNull(attribute, "The attribute AssemblyLevel is not defined");
            foreach(Attribute item in attributes)
            {
                TestContext.WriteLine($"Found attribute: {item}");
             
            }
        }

        [TestMethod()]
        public void CheckClassLevelTest()
        {
            Type typeToTest = typeof(Demo);

            ClassLevelAttribute attribute = typeToTest.GetCustomAttribute<ClassLevelAttribute>();

            Assert.IsNotNull(attribute, "The ClassLevelAttribute is not set on type Demo");
            Assert.AreEqual(typeof(Demo), attribute.TypeWorkingFor, "the defined type is either null or not the type of TypeWorking for");

        }

    }
}