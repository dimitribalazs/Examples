using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20161114_Example
{
    public class Class1
    {
        public static void Main(string[] args)
        {
            //kompiliertt, aber runtime hat probleme
            //class demo muss sealed sein, damit dies vom Compiler erkannt wird
            Demo demo = new Demo();
            //error
            //IDemo castedDemo = (IDemo)demo;

            //dynamic types, dynmaische programmierung
            var Foo = new { Now = DateTime.Now };

            List<Demo> demoList = new List<Demo>
            {
                new Demo() { Foo = "1"},
                new Demo() { Foo = "2"},
                new Demo() { Foo = "3"}
            };

            //projektion von Demo (Select (expr))
            foreach (var item in demoList.Select(i => new { Bla = i.Foo }))
            {
                Console.WriteLine(item.Bla);
            }


            //programming dynamic types
            dynamic dynamicObject = new Demo();
            //intellisense kennt jetzt Foo property nicht mehr
            dynamicObject.Foo = "test";

            //runtimebindexception
            //Error -> dynamicObject.Test = "testtest";


            //programming pure dynamic types
            dynamic pureDynamic = new System.Dynamic.ExpandoObject();
            pureDynamic.Bar = "bar";
            pureDynamic.ToString = new Action(() => Console.WriteLine("Hello"));

            Console.WriteLine(pureDynamic.Bar);
            pureDynamic.ToString();


            Console.ReadKey();
        }


        public class Demo
        {
            public string Foo { get; set; }
        }

        public interface IDemo { }
    }

}
