using System;
using System.Collections.Generic;
using MapperConsole.DTOs;
using MapperConsole.Entities;
using MapperLibrary;
using MapperLibrary.Interfaces;

namespace MapperConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Basic Test 1
            Person person = new Person
            {
                Id = Guid.NewGuid(),
                Name = "Name",
                Surname = "Surname",
                BirthDate = DateTime.Now,
                IdentityNumber = 12345678901
            };

            // Basic Test 2
            Employee employee = new Employee
            {
                Id = "123456",
                Name = "Test Name",
                Surname = "Test Surname",
                IdentityNumber = 10987654321,
                BirthDate = new DateTime(1991, 01, 01),
                Addresses = new List<Address>
                {
                    new Address
                    {
                        Country = "TR",
                        Description = "Office Address",
                        Province = "Istanbul",
                        District = "Maslak",
                        AddressType = AddressType.Office
                    },
                    new Address
                    {
                        Country = "TR",
                        Description = "Home Address",
                        Province = "Istanbul",

                        District = "Kagithane",
                        AddressType = AddressType.Home
                    }
                }
            };

            // Basic Test 3
            Address address = new Address
            {
                Country = "TR",
                Description = "Some directions",
                AddressType = AddressType.Home,
                District = "Beylikduzu",
                Province = "Istanbul"
            };

            MapperContainer.Assign<Employee, EmployeeDTO>();
            MapperContainer.Assign<Person, PersonDTO>();
            MapperContainer.Assign<Address, AddressDTO>();

            // 1. In the startup.cs file, register IMapper interface as Mapper class.
            // 2. Then using DI, use IMapper interface in any service class.
            IMapper mapper = new Mapper();
            //object employeeObject = mapper.Map(employee);
            //object personObject = mapper.Map(person);
            //PersonDTO personDto = mapper.Map<PersonDTO>(person);
            AddressDTO addressDto = mapper.Map<AddressDTO>(address);
        }
    }
}
