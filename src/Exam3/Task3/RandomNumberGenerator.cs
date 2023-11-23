using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class RandomNumberGenerator
    {
        private int _seed;
        private Random _rand;

        public RandomNumberGenerator()
        {
            _seed = DateTime.Now.Microsecond;
            _rand = new Random(_seed);
        }

        public int Generate()
        {
            return _rand.Next();
        }
    }
}
