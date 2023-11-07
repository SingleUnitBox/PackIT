using Microsoft.Extensions.DependencyInjection;
using PackIt.Shared.Abstractions.Queries;
using PackIT.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Shared.Queries
{
    public static class Extensions
    {
        public static IServiceCollection AddQueries(this IServiceCollection servies)
        {
            var assembly = Assembly.GetCallingAssembly();

            servies.AddSingleton<IQueryDispatcher, InMemoryQueryDispatcher>();
            servies.Scan(s => s.FromAssemblies(assembly)
                .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            return servies;
        }
    }
}
