using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Element.Admin.Extension
{
    public static class AutoMapperExtension
    {
        public static IEnumerable<TDestination> Map<TSource, TDestination>(this IMapper mapper, IEnumerable<TSource> sources)
        {
            foreach (var source in sources)
            {
                yield return mapper.Map<TSource, TDestination>(source);
            }
        }
    }
}
