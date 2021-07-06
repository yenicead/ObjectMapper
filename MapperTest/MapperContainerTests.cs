using MapperConsole.DTOs;
using MapperConsole.Entities;
using MapperLibrary;
using System;
using Xunit;

namespace MapperTest
{
    public class MapperContainerTests
    {
        [Fact]
        public void MapperListCount_ShouldBeEqualToZero()
        {
            var mapperList = MapperContainer.GetMapperList();
            Assert.Equal(0, mapperList.Count);
        }

        [Fact]
        public void MapperListCount_ShouldBeEqualToOne()
        {
            MapperContainer.Assign<Address, AddressDTO>();
            var mapperList = MapperContainer.GetMapperList();
            Assert.Equal(1, mapperList.Count);
        }

        [Fact]
        public void MapperListCount_ShouldBeEqualToTwo()
        {
            MapperContainer.Assign<Address, AddressDTO>();
            MapperContainer.Assign<Employee, EmployeeDTO>();
            var mapperList = MapperContainer.GetMapperList();
            Assert.Equal(2, mapperList.Count);
        }

        [Fact]
        public void MapperListCount_ShouldBeEqualToThree()
        {
            MapperContainer.Assign<Address, AddressDTO>();
            MapperContainer.Assign<Employee, EmployeeDTO>();
            MapperContainer.Assign<Person, PersonDTO>();
            var mapperList = MapperContainer.GetMapperList();
            Assert.Equal(3, mapperList.Count);
        }

        [Fact]
        public void MapperContainer_ShouldThrowException_When_SameTypesAssigned()
        {
            MapperContainer.Assign<Address, AddressDTO>();
            Assert.Throws<Exception>(() => MapperContainer.Assign<Address, AddressDTO>());
        }

        [Fact]
        public void MapperContainer_ShouldThrowException_When_SourceAndDestinationTypesAreSame()
        {
            Assert.Throws<Exception>(() => MapperContainer.Assign<Address, Address>());
        }
    }
}
