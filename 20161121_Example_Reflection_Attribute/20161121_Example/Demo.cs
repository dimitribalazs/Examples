using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH.Example._20161121
{
    //statische variable sind hier nicht möglich. nichts was zur lauftzeit aufgelöst wird
    [ClassLevel(TypeWorkingFor = typeof(Demo), Name = "Demo Class")]
    public class Demo
    {
        private int PrivateIntegerField;

        public int PublicIntegerField;
        public int IntegerProperty { get; set; }

        public Demo()
        {

        }

        public Demo(int iParam)
        {
            PublicIntegerField = iParam;
        }


        public int DoSomething(int intParam, string strParam, DateTime dateParam)
        {
            Console.WriteLine($"{intParam} - {strParam} - {dateParam}");
            return intParam * 10;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
