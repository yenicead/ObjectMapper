using MapperConsole.DTOs;
using MapperConsole.Entities;
using MapperLibrary.Interfaces;
using System;
using Xunit;

namespace MapperTest
{
    public class MapperTests
    {
        [Fact]
        public void Map_ShouldThrowException_WhenMapperTypeNotExist()
        {
            IMapper mapper = MoqGenerator.GenerateMapper.GetNewMapperHelper();
            Person personObject = MoqGenerator.GenerateEntity.NewPerson();
            Assert.Throws<Exception>(() => mapper.Map(personObject));
        }

        [Fact]
        public void Map_ShouldThrowException_WhenSourceIsNull()
        {
            IMapper mapper = MoqGenerator.GenerateMapper.GetNewMapperHelper();
            Assert.Throws<ArgumentNullException>(() => mapper.Map(null));
        }

        [Fact]
        public void GenericMap_ShouldThrowException_WhenSourceIsNull()
        {
            IMapper mapper = MoqGenerator.GenerateMapper.GetNewMapperHelper();
            Assert.Throws<ArgumentNullException>(() => mapper.Map<AddressDTO>(null));
        }
    }
}
