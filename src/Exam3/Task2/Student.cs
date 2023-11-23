using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Student
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string GenerateId()
        {
            return "S" + Name;
        }
    }
}
