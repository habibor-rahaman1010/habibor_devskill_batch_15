using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Student : Person
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }

        public override string GenerateId()
        {
            return $"S-{Name.Substring(0, 3)}{DateOfBirth.Year.ToString().Substring(2)}";
        }
    }
}
