using System;
using System.Collections.Generic;
using System.Text;

namespace MapperConsole
{
    public class Person
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public long IdentityNumber { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
