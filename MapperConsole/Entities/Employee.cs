using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MapperConsole.Entities
{
    public class Employee
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public long IdentityNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public List<Address> Addresses { get; set; }

        public Employee()
        {
            Addresses = new List<Address>();
        }
    }
}
