using System;
using System.Collections.Generic;
using System.Reflection;
using MapperConsole.DTOs;
using MapperLibrary;
using Xunit;

namespace MapperTest
{
    public class MapperHelperTests
    {
        [Fact]
        public void BindProperties_ShouldThrowArgumentNullException_ForSourcePropertiesParameter()
        {
            Assert.Throws<ArgumentNullException>(() => MapperHelper.BindProperties(null, null, null, null));
        }

        [Fact]
        public void BindProperties_ShouldThrowArgumentNullException_ForDestinationPropertiesParameter()
        {
            IDictionary<string, PropertyInfo> sourceProperties = new Dictionary<string, PropertyInfo>();
            Assert.Throws<ArgumentNullException>(() => MapperHelper.BindProperties(sourceProperties, null, null, null));
        }

        [Fact]
        public void BindProperties_ShouldThrowArgumentNullException_ForSourceParameter()
        {
            IDictionary<string, PropertyInfo> properties = new Dictionary<string, PropertyInfo>();
            Assert.Throws<ArgumentNullException>(() => MapperHelper.BindProperties(properties, properties, null, null));
        }

        [Fact]
        public void BindProperties_ShouldThrowArgumentNullException_ForDestinationParameter()
        {
            IDictionary<string, PropertyInfo> properties = new Dictionary<string, PropertyInfo>();
            object source = new object();
            Assert.Throws<ArgumentNullException>(() => MapperHelper.BindProperties(properties, properties, source, null));
        }
    }
}
