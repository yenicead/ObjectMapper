using MapperConsole.DTOs;
using System;
using Xunit;

namespace MapperTest
{
    public class MapperTests
    {
        [Fact]
        public void Mapper_ShouldThrowException_When_MapperTypeNotExist()
        {
            var mapper = MoqGenerator.GenerateMapper.GetNewMapperHelper();
            var personObject = MoqGenerator.GenerateEntity.NewPerson();
            Assert.Throws<Exception>(() => mapper.Map(personObject));
        }

        [Fact]
        public void Mapper_ShouldThrowException_When_SourceIsNull()
        {
            var mapper = MoqGenerator.GenerateMapper.GetNewMapperHelper();
            Assert.Throws<ArgumentNullException>(() => mapper.Map(null));
        }

        [Fact]
        public void Mapper_ShouldThrowException_When_SourceIsNull_WithDestinationType()
        {
            var mapper = MoqGenerator.GenerateMapper.GetNewMapperHelper();
            Assert.Throws<ArgumentNullException>(() => mapper.Map<AddressDTO>(null));
        }
    }
}
