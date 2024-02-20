using Microsoft.Extensions.DependencyInjection;

namespace DI
{
    public class Program
    {
        public static void Main()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddSingleton<ITest, Test>();

            // Register class for constructor injection
            services.AddSingleton<Tester>();

            // Register class for property injection
            services.AddSingleton(t => new TesterPropertyInjection() { Test = t.GetRequiredService<ITest>()});

            // Register class for method injection
            services.AddSingleton<TesterMethodInjection>();

            var app = services.BuildServiceProvider();

            // Use constructor injection
            Tester t = app.GetRequiredService<Tester>();
            t.WriteToConsole();

            // Use property injection
            TesterPropertyInjection t2 = app.GetRequiredService<TesterPropertyInjection>();
            t2.WriteToConsole();

            // Use method injection
            TesterMethodInjection t3 = app.GetRequiredService<TesterMethodInjection>();
            t3.WriteToConsole(app.GetRequiredService<ITest>());
        }
    }

    public interface ITest
    {
        string GetString();
    }

    public class Test : ITest
    {
        public string GetString()
        {
            return "teststring";
        }
    }

    public class Tester
    {
        private readonly ITest _Test;

        public Tester(ITest test)
        {
            _Test = test;
        }

        public void WriteToConsole()
        {
            Console.WriteLine(_Test.GetString());
        }
    }

    public class TesterPropertyInjection
    {
        private ITest? _Test;

        public ITest Test { init { _Test = value;} }

        public void WriteToConsole()
        {
            Console.WriteLine(_Test?.GetString());
        }
    }

    public class TesterMethodInjection
    {
        public void WriteToConsole(ITest test)
        {
            Console.WriteLine(test.GetString());
        }
    }
}
