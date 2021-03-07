using System;

namespace MapperConsole.Entities
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
