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

            MapperContainer.Assign<Employee, EmployeeDTO>();
            // MapperContainer.Assign<Person, PersonDTO>();

            // 1. In the startup.cs file, register IMapper interface as Mapper class.
            // 2. Then using DI, use IMapper anywhere in the constructor.
            var mapper = new Mapper();
            var employeeDto = mapper.Map(employee);
            var personDto = mapper.Map(person);
        }
    }
}
