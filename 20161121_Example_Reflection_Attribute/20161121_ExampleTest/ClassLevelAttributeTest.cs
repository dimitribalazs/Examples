using Microsoft.VisualStudio.TestTools.UnitTesting;
using BFH.Example._20161121;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH.Example._20161121.Test
{
    [TestClass()]
    public class ClassLevelAttributeTest
    {
        [TestMethod()]
        public void IsImplementingInterfaceTestPositiv()
        {

           //Arrange
            ClassLevelAttribute attribute = new ClassLevelAttribute
            {
                TypeWorkingFor = typeof(string)
            };

            Assert.IsTrue(attribute.IsImplementingInterface(typeof(IComparable)), "Type string does not implement IComparable");

            Assert.IsFalse(attribute.IsImplementingInterface(typeof(IDisposable)), "Type does implement IDisposable");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsImplementingInterfaceTestNegative()
        {
            ClassLevelAttribute attribute = new ClassLevelAttribute();
            attribute.TypeWorkingFor = typeof(string);

            attribute.IsImplementingInterface(null);

            //no assertion because the act must throw an exception
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void IsImplementingInterfaceTestNegativeInterface()
        {
            ClassLevelAttribute attribute = new ClassLevelAttribute();
            attribute.TypeWorkingFor = typeof(string);

            attribute.IsImplementingInterface(typeof(object));

            //no assertion because the act must throw an exception
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void IsImplementingInterfaceTestNegativeInvalidOperationException()
        {
            ClassLevelAttribute attribute = new ClassLevelAttribute();
            //attribute.TypeWorkingFor = typeof(string);

            attribute.IsImplementingInterface(typeof(IComparable));

            //no assertion because the act must throw an exception
        }

    }
}