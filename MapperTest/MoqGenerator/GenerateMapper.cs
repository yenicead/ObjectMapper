using MapperLibrary;
using MapperLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperTest.MoqGenerator
{
    public class GenerateMapper
    {
        public IMapper GetNewMapperHelper()
        {
            return new Mapper();
        }
    }
}
