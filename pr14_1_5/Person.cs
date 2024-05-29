using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr14_1_5
{
    class Person
    {
        public string sname { get; set; }
        public string name { get; set; }
        public string otc { get; set; }
        public int age { get; set; }
        public int ves { get; set; }
        public Person(string sname, string name, string otc, int age, int ves)
        {
            this.sname = sname;
            this.name = name;
            this.otc = otc;
            this.age = age;
            this.ves = ves;
        }
        public Person() { }
    }
}
