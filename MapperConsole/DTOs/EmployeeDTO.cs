using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperConsole.DTOs
{
    public class EmployeeDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<AddressDTO> Addresses { get; set; }

        public EmployeeDTO()
        {
            Addresses = new List<AddressDTO>();
        }

        public override string ToString()
        {
            return $"{Name} {Surname} has Id: {Id}, and has {Addresses.Count} address(es).";
        }
    }
}
