using System;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;

internal class Program
{
    private static IConfigurationRoot configuration;

   
    public static void Main(string[] args)
    {
        InitConfig();
        CreateCompany();
        //UpdateCompany();
        //DeleteCompany();
        ReadCompany();
       
    }

    private static void InitConfig()
    {
        var builder = new ConfigurationBuilder();
        builder
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        configuration = builder.Build();

        var a = configuration.GetConnectionString("DefaultConnection");
    }

    private static void CreateCompany()
    {
        Console.WriteLine("Input ID:");
        int.TryParse(Console.ReadLine(), out int id);
        Console.WriteLine("Input name of company:");
        string nameOfCompany = Console.ReadLine();
        Console.WriteLine("Input description:");
        string description = Console.ReadLine();
        Console.WriteLine("Input Owner:");
        string owner = Console.ReadLine();

        string connectionString = configuration.GetConnectionString("DefaultConnection");
        using(SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            connection.Execute("Moroz.Create_Company", new
            {
                id,
                nameOfCompany,
                description,
                owner
            }, commandType: CommandType.StoredProcedure);
            connection.Close();
        }
    }
    private static void ReadCompany()
    {
        string connectionString = configuration.GetConnectionString("DefaultConnection");
        using(SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using(SqlCommand cmd = new SqlCommand("Moroz.GetAllItems_Company", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        int id = (int)reader["id"];
                        string nameOfCompany = (string)reader["nameOfCompany"];
                        string description = (string)reader["description"];
                        string owner = (string)reader["owner"];
                        Console.WriteLine($"ID: {id}, Name: {nameOfCompany}, Description: {description}, Owner: {owner}");
                    }
                }
            }
            connection.Close();
        }
    }
    private static void UpdateCompany()
    {
        Console.WriteLine("Input which ID you want to Update:");
        int.TryParse(Console.ReadLine(), out int id);
        Console.WriteLine("Input new name of company:");
        string nameOfCompany = Console.ReadLine();
        Console.WriteLine("Input new description:");
        string description = Console.ReadLine();
        Console.WriteLine("Input new Owner:");
        string owner = Console.ReadLine();

        string connectionString = configuration.GetConnectionString("DefaultConnection");
        using(SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            connection.Execute("Moroz.UpdateById_Company", new
            {
                id,
                nameOfCompany,
                description,
                owner
            }, commandType: CommandType.StoredProcedure);
            connection.Close();
        }
    }

    private static void DeleteCompany()
    {
        Console.WriteLine("Input which ID you want to Delete:");
        int.TryParse(Console.ReadLine(), out int id);
        string connectionString = configuration.GetConnectionString("DefaultConnection");
        using(SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            connection.Execute("Moroz.DeleteById_Company", new {id});
            connection.Close();
        }
    }
}