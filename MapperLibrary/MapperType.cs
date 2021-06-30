using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MapperLibrary.Interfaces;

namespace MapperLibrary
{
    public class MapperType<TSource, TDestination> : IMapperType<TSource, TDestination>
        where TSource: class
        where TDestination : class, new()
    {
        public TDestination Map(TSource TSource)
        {
            try
            {
                TDestination destination = new TDestination();
                return destination;
            }
            catch (Exception exception)
            {
                throw new Exception($"An exception has occurred, details: { exception }");
            }
        }
    }
}
