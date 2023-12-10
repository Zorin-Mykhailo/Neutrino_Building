using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neutrino.Data.Db;
public class DbContext
{
    private readonly IConfiguration _configuration;

    public string? DbName => _configuration["DBName"];

    public DbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IDbConnection CreateMainDbConnection()
        => new SqlConnection(_configuration.GetConnectionString("AppDbConnectionString"));

    public IDbConnection CreateMasterDbConnection()
        => new SqlConnection(_configuration.GetConnectionString("MasterDbConnectionString"));
}
