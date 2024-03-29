﻿#define ZorinM__HW10_ExceptionsHandling

using Building.DataModel.Master;
using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Text;

namespace Building;

internal class Program
{
    private static IConfigurationRoot Config;

    static void Main(string[] args)
    {
        Console.InputEncoding = Encoding.Unicode;
        Console.OutputEncoding = Encoding.Unicode;

        AppStartup();

        return;

        MainMenu mainMenu = new()
        {
            Articles = GetMenuItemsSet_Articles(),
            Companies = GetMenuItemsSet_Companies(),
            SupportTickets = GetMenuItemsSet_Support(),
            Prices = GetMenuItemsSet_Prices(),
            Masters = GetMenuItemsSet_Masters()
        };

        mainMenu.ShowMenu();
    }

    private static void AppStartup()
    {
        string? lauchSettingsEnv = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        $"Current environment: {lauchSettingsEnv}".OutLine(ConsoleColor.Magenta);
        ConfigurationBuilder builder = new ();
        _ = builder
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("App/Settings/appsettings.json", false, true)
            .AddJsonFile($"App/Settings/appsettings.{lauchSettingsEnv}.json", false, true);
        Config = builder.Build();

        IServiceProvider serviceProvider = CreateServices();
        using IServiceScope scope = serviceProvider.CreateScope();
        RunMigration(scope.ServiceProvider);
    }

    private static IServiceProvider CreateServices()
    {
        return new ServiceCollection()
            .AddLogging(x => x.AddFluentMigratorConsole())
            .AddFluentMigratorCore()
            .ConfigureRunner(c => c.AddSqlServer2016()
                .WithGlobalConnectionString(Config.GetConnectionString(""))
                .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations())
            .BuildServiceProvider(false);
    }

    private static void RunMigration(IServiceProvider serviceProvider)
    {
        var mirationService = serviceProvider.GetRequiredService<IMigrationRunner>();
        mirationService.ListMigrations();
        mirationService.MigrateUp();
    }


    private static SetOfArticles GetMenuItemsSet_Articles()
    {
        SetOfArticles articles = new(1, "Статті")
        {
            new (1) { Title = "Стаття 1", Actuality = Actuality.Deprecated },
            new (34) { Title = "Стаття 2" }
        };
        return articles;
    }

    private static SetOfSupportTickets GetMenuItemsSet_Support()
    {
        SetOfSupportTickets supportTickets = new (2, "Технічна підтримка")
        {
            new (1)
            {
                Title = "Не працює мишка",
                Actuality = Actuality.Actual,
                AutorEmail = "v.pupkin@mail.com",
                Text = "Перестала працювати мишка. Можливо ...",
                State = SupportTicketState.New
            },
            new (2)
            {
                Title = "Збій роботи програми MyApp",
                Actuality = Actuality.Actual,
                AutorEmail = "m.romaskina@mail.com",
                Text = "Мій додаток перестав працювати в зв'язку із ...",
                State = SupportTicketState.InProgres
            },
            new (3)
            {
                Title = "Не коректна робота API",
                Actuality = Actuality.Deprecated,
                AutorEmail = "r.ivanov@mail.com",
                Text = "Мій додаток перестав працювати в зв'язку із змінами у вашому API, що були...",
                State = SupportTicketState.Closed
            }
        };

        return supportTickets;
    }

    

    private static SetOfCompany GetMenuItemsSet_Companies()
    {
        SetOfCompany companies = new(2, "Компанії")
        {
            new(1)
            {
                NameOfCompany = "OBID",
                Owner = "George",
                Actuality = Actuality.Actual,
                Description = "Big and greate company",
                State = CompanyState.InProgres
            },
            new(2)
            {
                NameOfCompany = "Stroyka",
                Owner = "Vasya",
                Actuality = Actuality.Deprecated,
                Description = "Bad company",
                State = CompanyState.Closed
            },
            new(3)
            {
                NameOfCompany = "Shittovoz",
                Owner = "Oleg",
                Actuality = Actuality.Actual,
                Description = "We are work with poop",
                State = CompanyState.New
            }
        };
        return companies;
    }

    private static SetOfPrices GetMenuItemsSet_Prices()
    {
        SetOfPrices prices = new (3, "Ціни")
        {
            new (1, 168.25m, true, "3")
            {
               Name = "Мішок цементу",
               Type = PricesType.Material,
            },
            new (2, 126.0m, false, "5")
            {
               Name = "Мішок штукатурки",
               Type = PricesType.Material,
            },
            new (3, 450.0m, false, "4")
            {
               Name = "Мішок шпаклівки",
               Type = PricesType.Material,
            },
            new (4, 2250.0m, true, "2")
            {
               Name = "Ларезний рівень",
               Type = PricesType.Instrument,
            },
            new (5, 3100.0m, false, "1")
            {
               Name = "Перфоратор",
               Type = PricesType.Instrument,
            },
            new (6, 899.0m, false, "4")
            {
               Name = "Набір викруток",
               Type = PricesType.Instrument,
            },
            new (7, 880.0m, true, "5" )
            {
               Name = "Ремонт даху будівлі, метр квадратний",
               Type = PricesType.Service,
            },
            new (8, 1100.0m, true, "1")
            {
               Name = "Автоперевезення, ціна за 100 кг",
               Type = PricesType.Service,
            },
            new (9, 500.0m, true, "99999999")
            {
               Name = "Консультація електрика",
               Type = PricesType.Service,
            }
        };

        return prices;
    }

    private static SetOfMasters GetMenuItemsSet_Masters()
    {
        SetOfMasters masters = new (4, "Майстри")
        {
            new (1)
            {
               FirstName = "Anton",
               LastName = "Anosov",
               Email = "aan@gmail.com" ,
               MasterType = MasterType.PoolMaster
            },
            new (2)
            {
               FirstName = "Borys",
               LastName = "Bobrov",
               Email = "bbo@gmail.com" ,
               MasterType = MasterType.Cleaner
            },
            new (3)
            {
               FirstName = "Clement",
               LastName = "Citrusenko",
               Email = "ccu@gmail.com" ,
               MasterType = MasterType.Gardener
            },
            new (4)
            {
               FirstName = "Denis",
               LastName = "Davydov",
               Email = "dde@gmail.com" ,
               MasterType = MasterType.General
            },
            new (5)
            {
               FirstName = "Egor",
               LastName = "Efremov",
               Email = "eef@gmail.com" ,
               MasterType = MasterType.Electrician
            },
            new (6)
            {
               FirstName = "Gennadiy",
               LastName = "Goroshovskii",
               Email = "ggo@gmail.com" ,
               MasterType = MasterType.Foreman
            },
            new (7)
            {
               FirstName = "Faina",
               LastName = "Fusenko",
               Email = "ffu@gmail.com" ,
               MasterType = MasterType.Repairer
            },
            new (8)
            {
               FirstName = "Havrylo",
               LastName = "Holosenko",
               Email = "hho@gmail.com" ,
               MasterType = MasterType.Plumber
            },
        };

        return masters;
    }
}