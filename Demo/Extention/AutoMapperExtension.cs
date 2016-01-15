using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Demo.Extention
{
    public static class AutoMapperExtension
    {
        public static TResult MapPropertiesToInstance<TResult>(this IMappingEngine mapper, object self, TResult value)
        {
            if (self == null)
            {
                throw new ArgumentNullException();
            }

            return (TResult)mapper.Map(self, value, self.GetType(), typeof(TResult));
        }
    }
}
