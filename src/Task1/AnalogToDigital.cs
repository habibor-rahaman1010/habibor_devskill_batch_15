using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class AnalogToDigital
    {
        private string? _ip;
        private string? _fullAddress;
        public void MakeConnection(string caller)
        {
            _fullAddress = GetFullAddress(caller);
        }

        public void Close()
        {
            _ip = null;
        }

        public string? GetFullAddress(string caller)
        {
            return _ip + caller;
        }
    }
}
