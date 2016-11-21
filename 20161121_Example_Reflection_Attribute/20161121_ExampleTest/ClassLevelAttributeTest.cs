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
    public class DemoTest
    {
        [TestMethod()]
        public void CheckAssemblyLevelTest()
        {
            Assembly assembly = typeof(Demo).GetAssembly();
        }
    }
}