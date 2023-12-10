using Dapper;
using DbExecutor.Models;
using Microsoft.Data.SqlClient;

internal class Program
{
    private static void Main(string[] args)
    {
        var connectionStr = @"Data Source=DESKTOP\SQLEXPRESS;Initial Catalog=AdventureWorks2022;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";


        using (var connection = new SqlConnection(connectionStr))
        {
            DynamicParameters masterByIdParams = new DynamicParameters();
            masterByIdParams.Add("Id", 2);
            IEnumerable<Master> masterById = connection.Query<Master>("Zorin.GetMasterById", param: masterByIdParams, commandType:System.Data.CommandType.StoredProcedure);

            DynamicParameters createMasterParams = new DynamicParameters();
            createMasterParams.Add("id", 3);
            createMasterParams.Add("FirstName", "Anton");
            createMasterParams.Add("lastName", "Ptushkin");
            createMasterParams.Add("Email", "email");
            createMasterParams.Add("PhoneNumber", "12234");
            createMasterParams.Add("MasterTypeId", "1");
            connection.Query("Zorin.CreateMaster", param: createMasterParams, commandType: System.Data.CommandType.StoredProcedure);

            IEnumerable<Master> allMasters = connection.Query<Master>("Zorin.GetAllMasters", commandType:System.Data.CommandType.StoredProcedure);
            
            DynamicParameters deleteMasterByIdParams = new DynamicParameters();
            deleteMasterByIdParams.Add("Id", 2);
            connection.Query("Zorin.DeleteMasterById", param: deleteMasterByIdParams, commandType:System.Data.CommandType.StoredProcedure);

            var allMastersWithAInNameSql = "Select * from Masters where Name like '%a%'";
            IEnumerable<Master> allMastersWithAInNameS = connection.Query<Master>(allMastersWithAInNameSql);
        }
    }
}