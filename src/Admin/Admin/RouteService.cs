using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Element.Admin
{
    public class RouteService
    {
        private readonly Dictionary<string, Type> routeMap = new Dictionary<string, Type>();

        public RouteService()
        {
            var pageTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.DefinedTypes)
                .Where(x => typeof(ComponentBase).IsAssignableFrom(x))
                .ToList();
            var pageTemplates = pageTypes.Select(x => new
            {
                Routes = x.GetCustomAttributes(typeof(RouteAttribute), true).Cast<RouteAttribute>().Select(y => y.Template).ToArray(),
                Component = x
            }).ToArray();
            foreach (var pageTemplate in pageTemplates)
            {
                foreach (var route in pageTemplate.Routes)
                {
                    routeMap.Add(route, pageTemplate.Component);
                }
            }
        }

        public Type GetComponent(string path)
        {
            routeMap.TryGetValue(path, out var component);
            return component;
        }
    }
}
