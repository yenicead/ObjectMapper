using System;
using MapperConsole.DTOs;
using MapperConsole.Entities;
using MapperLibrary;

namespace MapperConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person
            {
                Id = Guid.NewGuid(),
                Name = "Name",
                Surname = "Surname",
                BirthDate = DateTime.Now,
                IdentityNumber = 12345678901
            };

            var mapper = new MapperType<Person, PersonDTO>();
            PersonDTO personDto = mapper.Map(person);

            Console.WriteLine(personDto.ToString());
        }
    }
}
