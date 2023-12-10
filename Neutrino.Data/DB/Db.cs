using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neutrino.Data.Db;
public class Db
{
    private readonly DbContext _dbContext;

    public Db(DbContext dbContext) => _dbContext = dbContext;

    public void CreateIfNotExist()
    {
        string queryIsDbExist = "select * from sys.databases where name = @dbName";
        DynamicParameters parameters = new();
        parameters.Add("dbName", _dbContext.DbName);

        using IDbConnection masterConnection = _dbContext.CreateMasterDbConnection();
        IEnumerable<dynamic> records = masterConnection.Query(queryIsDbExist, parameters);
        if(!records.Any())
            _ = masterConnection.Execute($"create database {_dbContext.DbName}");
    }

    public void DropIfExist()
    {
        string queryIsDbExist = "select * from sys.databases where name = @dbName";
        DynamicParameters parameters = new();
        parameters.Add("dbName", _dbContext.DbName);

        using IDbConnection masterConnection = _dbContext.CreateMasterDbConnection();
        IEnumerable<dynamic> records = masterConnection.Query(queryIsDbExist, parameters);
        if(!records.Any())
            _ = masterConnection.Execute($"Drop database {_dbContext.DbName}");
    }

    public SupportTicket SupportTicketGet(int id)
    {
        DynamicParameters dynamicParameters = new ();
        dynamicParameters.Add("@Id", id);

        using IDbConnection connection = _dbContext.CreateMainDbConnection();
        SupportTicket? result = connection.Query<SupportTicket>("Zorin.SupportTicket_GetById", commandType: CommandType.StoredProcedure, param: dynamicParameters).FirstOrDefault();
        return result;
    }

    public SupportTicket SupportTicketUpdate(SupportTicket supportTicket)
    {
        DynamicParameters dynamicParameters = new ();
        dynamicParameters.Add("@Id", supportTicket.Id);
        dynamicParameters.Add("@title", supportTicket.Title);
        dynamicParameters.Add("@actuality", supportTicket.Actuality);
        dynamicParameters.Add("@authorEmail", supportTicket.AuthorEmail);
        dynamicParameters.Add("@text", supportTicket.Text);
        dynamicParameters.Add("@state", supportTicket.State);

        using IDbConnection connection = _dbContext.CreateMainDbConnection();
        connection.Query<SupportTicket>("Zorin.SupportTicket_Update", commandType: CommandType.StoredProcedure, param: dynamicParameters);
        return SupportTicketGet(supportTicket.Id);
    }
}
