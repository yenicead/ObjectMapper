using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperConsole.Entities
{
    public enum AddressType
    {
        Home, 
        Office
    }

    public class Address
    {
        public string Country { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Description { get; set; }
        public AddressType AddressType { get; set; }
    }
}
