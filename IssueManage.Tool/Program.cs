using CommandLine;
using CommandLine.Text;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace IssueManage.Tool
{
    class Program
    {
        private static readonly ServiceCollection _services = new ServiceCollection();
        private static readonly IEnumerable<Type> _commandTypes = Assembly.GetCallingAssembly().GetTypes().Where(o => o.GetInterfaces().Any(o => o.Name == typeof(ICommand<>).Name)).ToList();
        private static ServiceProvider _serviceProvider;

        static void Main(string[] args)
        {
#if DEBUG
            args = new string[] { nameof(Cmd), "-c", "1" };

#endif
            ConfigEnvironment();
            ConfigServices();
            ExecuteCommand(args);
        }

        private static void ConfigServices()
        {
            _services.AddMemoryCache();
            foreach (var t in _commandTypes)
            {
                _services.AddTransient(t);
            }
            _serviceProvider = _services.BuildServiceProvider();
        }

        private static void ExecuteCommand(string[] args)
        {
            var attrs = Assembly.GetCallingAssembly().GetTypes().Where(o => o.GetCustomAttribute(typeof(VerbAttribute)) != null).ToArray();
            var parseResult = Parser.Default.ParseArguments(args, attrs);
            if (parseResult.Tag == ParserResultType.Parsed)
            {
                string line = new string('-', 30);
                var pr = parseResult as Parsed<object>;
                var commandType = _commandTypes.FirstOrDefault(o => o.Name.Equals(pr.Value.GetType().CustomAttributes.First().ConstructorArguments.First().Value));

                var command = _serviceProvider.GetService(commandType);

                Execute(commandType, command, new object[] { pr.Value });
            }
            else if (parseResult.Tag == ParserResultType.NotParsed)
            {
                HelpText.AutoBuild(parseResult);
            }
        }

        public static void Execute(Type commandType, object command, object?[]? parameters)
        {
            var onExecutingMethod = commandType.GetMethod(nameof(ICommand<object>.OnExecuting));
            if (onExecutingMethod != null)
                onExecutingMethod.Invoke(command, parameters);

            var method = commandType.GetMethod(nameof(ICommand<object>.Execute));
            method.Invoke(command, parameters);

            var executedMethod = commandType.GetMethod(nameof(ICommand<object>.OnExecuted));
            if (executedMethod != null)
                executedMethod.Invoke(command, parameters);
        }

        private static void ConfigEnvironment()
        {
        }
    }
}
