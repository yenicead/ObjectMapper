using System;

namespace MapperConsole.DTOs
{
    public class PersonDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public override string ToString()
        {
            return $"Id: {Id}\nName: {Name}\nSurname: {Surname}.";
        }
    }
}
