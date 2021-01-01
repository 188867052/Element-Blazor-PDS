using AutoMapper;
using System.Collections.Generic;

namespace IssueManage.Pages.Extension
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
