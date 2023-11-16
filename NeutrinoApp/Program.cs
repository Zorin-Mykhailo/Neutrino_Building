using Dapper;
using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Neutrino.Data;
using Neutrino.Data.Db;
using System.Data;
using System.Reflection;

namespace NeutrinoApp;

internal class Program
{
    private static IConfigurationRoot Config;

    static void Main(string[] args)
    {
        InitConfig();
        DbContext dbContext = new(Config);
        Db db = new(dbContext);
        db.CreateIfNotExist();

        IServiceProvider serviceProvider = CreateServices();
        using IServiceScope scope = serviceProvider.CreateScope();
        RunMigration(scope.ServiceProvider);

        Console.WriteLine("DB object:");
        SupportTicket supportTicket = db.SupportTicketGet(1);
        Console.WriteLine($"{supportTicket}");

        Console.WriteLine("Updated DB object:");
        supportTicket.Text = "Перестала працювати мишка. Можливо забігалась...";
        supportTicket = db.SupportTicketUpdate(supportTicket);
        Console.WriteLine($"{supportTicket}");
    }


    private static void InitConfig()
    {
        ConfigurationBuilder builder = new();
        string? launchSettinsEnv = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        _ = builder
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{launchSettinsEnv}.json", optional: false, reloadOnChange: true);

        Config = builder.Build();
    }

    public static IServiceProvider CreateServices()
    {
        return new ServiceCollection()
            .AddLogging(c => c.AddFluentMigratorConsole())
            .AddFluentMigratorCore()
            .ConfigureRunner(c => c.AddSqlServer2016()
                .WithGlobalConnectionString(Config.GetConnectionString("AppDbConnectionString"))
                .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations())
            .BuildServiceProvider(false);
    }

    private static void RunMigration(IServiceProvider serviceProvider)
    {
        IMigrationRunner migrationService = serviceProvider.GetRequiredService<IMigrationRunner>();
        migrationService.ListMigrations();
        migrationService.MigrateUp();
        //migrationService.MigrateDown(202311160001);
    }
}
