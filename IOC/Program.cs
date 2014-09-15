using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOC;
using Autofac;

namespace IOC.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = LetThereBeIoC();
            //var clarkson = ClarksonFactory.SpawnOne();
            //var clarkson = (Clarkson)AutomaticFactory.GetMeOne(typeof(Clarkson));
            //var clarkson = AutomaticFactory.GetMeOne<Clarkson>();
            //var clarkson = container.Resolve<Clarkson>();
            using (var scope = container.BeginLifetimeScope())
            {
                var clarkson = scope.Resolve<Clarkson>();
                clarkson.ShoutSomething();
            }

            Console.ReadKey();
        }

        private static IContainer LetThereBeIoC()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(typeof(Program).Assembly)
                .AsImplementedInterfaces()
                .AsSelf()
                .InstancePerLifetimeScope();

            return builder.Build();
        }
    }
}
