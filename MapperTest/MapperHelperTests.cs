using System;
using MapperConsole.Entities;
using MapperLibrary;
using MapperLibrary.Interfaces;
using MapperTest.MoqDataGenerator;
using Xunit;

namespace MapperTest
{
    public class MapperHelperTests
    {
        [Fact]
        public void GetProperties_ShouldThrowArgumentNullException()
        {
            IMapperHelper<Employee> employeeMapperHelper = new MapperHelper<Employee>();
            Assert.Throws<ArgumentNullException>(() => employeeMapperHelper.GetProperties(null));
        }

        [Fact]
        public void GetProperties_ShouldReturnAddressProperties()
        {
            Address address = EntityGenerator.NewAddress();
            IMapperHelper<Address> addressMapperHelper = new MapperHelper<Address>();
            var properties = addressMapperHelper.GetProperties(address);
            Assert.Equal(address.GetType().GetProperties().Length, properties.Count);
        }

        [Fact]
        public void GetProperties_ShouldReturnEmployeeProperties()
        {
            Employee employee = EntityGenerator.NewEmployee();
            IMapperHelper<Employee> employeeMapperHelper = new MapperHelper<Employee>();
            var properties = employeeMapperHelper.GetProperties(employee);
            Assert.Equal(employee.GetType().GetProperties().Length, properties.Count);
        }

        [Fact]
        public void GetProperties_ShouldReturnPersonProperties()
        {
            Person person = EntityGenerator.NewPerson();
            IMapperHelper<Person> personMapperHelper = new MapperHelper<Person>();
            var properties = personMapperHelper.GetProperties(person);
            Assert.Equal(person.GetType().GetProperties().Length, properties.Count);
        }
    }
}
