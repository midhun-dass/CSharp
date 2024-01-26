using ConsoleSingletonDI.Interface;
using ConsoleSingletonDI.ServiceLifeTimesRepository;
using ConsoleSingletonDI.Singleton;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        var serviceProvider = ServiceLifeTimes();
        DependencyInjectionExplained(serviceProvider);

        SingletonExplained();

    }

    public static ServiceProvider ServiceLifeTimes()
    {
        // var serviceProvider = new ServiceCollection()
        //     .AddTransient<IGenerator, Generator>()
        //     .AddTransient<IConsumer, Consumer>()
        //     .BuildServiceProvider();

        // var serviceProvider = new ServiceCollection()
        //     .AddScoped<IGenerator, Generator>()
        //     .AddTransient<IConsumer, Consumer>()
        //     .BuildServiceProvider();

        // var serviceProvider = new ServiceCollection()
        //     .AddTransient<IGenerator, Generator>()
        //     .AddScoped<IConsumer, Consumer>()
        //     .BuildServiceProvider();

        // var serviceProvider = new ServiceCollection()
        //     .AddScoped<IGenerator, Generator>()
        //     .AddScoped<IConsumer, Consumer>()
        //     .BuildServiceProvider();

        // var serviceProvider = new ServiceCollection()
        //     .AddTransient<IGenerator, Generator>()
        //     .AddSingleton<IConsumer, Consumer>()
        //     .BuildServiceProvider();
        
        // var serviceProvider = new ServiceCollection()
        //     .AddScoped<IGenerator, Generator>()
        //     .AddSingleton<IConsumer, Consumer>()
        //     .BuildServiceProvider();

        // var serviceProvider = new ServiceCollection()
        //     .AddSingleton<IGenerator, Generator>()
        //     .AddScoped<IConsumer, Consumer>()
        //     .BuildServiceProvider();

        // var serviceProvider = new ServiceCollection()
        //     .AddTransient<IGenerator, Generator>()
        //     .AddSingleton<IConsumer, Consumer>()
        //     .BuildServiceProvider();

        var serviceProvider = new ServiceCollection()
            .AddSingleton<IGenerator, Generator>()
            .AddTransient<IConsumer, Consumer>()
            .BuildServiceProvider();

        return serviceProvider;
    }
    public static void DependencyInjectionExplained(ServiceProvider serviceProvider)
    {
        Console.WriteLine("--------------------consumer------------------------------");
        var consumer = serviceProvider.GetService<IConsumer>();
        consumer?.DisplayNextId();
        consumer?.DisplayNextId();
        consumer?.DisplayNextId();

        Console.WriteLine("--------------------consumer1------------------------------");

        var consumer1 = serviceProvider.GetService<IConsumer>();
        consumer1?.DisplayNextId();

        Console.WriteLine("---------------------generate-----------------------------");

        var generate = serviceProvider.GetService<IGenerator>();
        Console.WriteLine(generate?.GenerateId());
        Console.WriteLine(generate?.GenerateId());

        Console.WriteLine("----------------------generate1----------------------------");

        var generate1 = serviceProvider.GetService<IGenerator>();
        Console.WriteLine(generate1?.GenerateId());

        Console.WriteLine("-----------------------consumer1---------------------------");
        consumer1?.DisplayNextId();
    }

    public static void SingletonExplained()
    {
        Console.WriteLine("----------------------------counterValue1---------------------");

        var counterValue1 = Singleton.Instance.counter;
        Console.WriteLine(counterValue1);

        Console.WriteLine("----------------------------counterValue2---------------------");

        var counterValue2 = Singleton.Instance.counter;
        Console.WriteLine(counterValue2);

        Console.WriteLine("----------------------------counterValue3---------------------");

        var counterValue3 = Singleton.Instance.counter;
        Console.WriteLine(counterValue3);

        Console.WriteLine("----------------------------counterValue4---------------------");
        
        var counterValue4 = Singleton.Instance.counter;
        Console.WriteLine(counterValue4);
    }
}