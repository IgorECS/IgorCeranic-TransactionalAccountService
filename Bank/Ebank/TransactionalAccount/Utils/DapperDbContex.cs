


using System.Data;
using Microsoft.Data.SqlClient;


namespace Bank.Ebank.TransactionalAccount.Utils{


public class DapperDbContex{

private readonly IConfiguration _configuration;
private readonly String _connectionString;

public DapperDbContex(IConfiguration configuration){
    this._configuration = configuration;
    this._connectionString = _configuration.GetConnectionString("DefaultConnection");
}

public IDbConnection CreateConnection{
            get
            {
                return new SqlConnection(this._connectionString);
            }
        }

}
}