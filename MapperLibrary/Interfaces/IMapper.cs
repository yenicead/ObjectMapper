using System.Collections.Generic;
using System.Reflection;

namespace MapperLibrary.Interfaces
{
    public interface IMapper
    {
        /// <summary>
        /// Returns a new object.
        /// </summary>
        /// <param name="source">Source object which will be mapped.</param>
        /// <returns></returns>
        object Map(object source);

        /// <summary>
        /// Returns a new object with type T.
        /// </summary>
        /// <typeparam name="T">Type of new object.</typeparam>
        /// <param name="source">Source object which will be mapped to new object with type T. </param>
        /// <returns></returns>
        T Map<T>(object source);
    }
}
