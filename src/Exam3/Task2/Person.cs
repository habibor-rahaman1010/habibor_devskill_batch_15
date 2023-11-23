using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public abstract class Person
    {
        public string Name { get; set; }
        public int DateOfBirth { get; set; }
        public abstract string GenerateId();
    }
}
