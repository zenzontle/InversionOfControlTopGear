using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOC.App;

namespace IOC
{
    public class AutomaticFactory
    {
        public static T GetMeOne<T>()
        {
            return (T)GetMeOne(typeof(T));
        }
        public static object GetMeOne(Type type)
        {
            var typeWeActuallyWanted = FigureOutWhichTypeWeWant(type);

            var constructor = typeWeActuallyWanted.GetConstructors().Single();
            var parameters = constructor.GetParameters();

            if (!parameters.Any()) return Activator.CreateInstance(typeWeActuallyWanted);
            var args = new List<object>();
            foreach (var parameter in parameters)
            {
                var arg = GetMeOne(parameter.ParameterType);
                args.Add(arg);
            }

            var result = Activator.CreateInstance(typeWeActuallyWanted, args.ToArray());
            return result;
        }
        private static Type FigureOutWhichTypeWeWant(Type type)
        {
            return typeof(Program).Assembly.GetExportedTypes()
                .Where(type.IsAssignableFrom)
                .Where(t => !t.IsInterface)
                .Where(t => !t.IsAbstract)
                .First();
        }
    }
}
