
using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;

using Bank.Ebank.TransactionalAccount.Utils;
using Bank.Ebank.TransactionalAccount.Models;

namespace Bank.Ebank.TransactionalAccount.Repositories;


public class AccountRepository: IAccountRepository{
    private readonly DapperDbContex _daperUtil;
    private readonly ILogger<AccountRepository> _logger;

    public AccountRepository (DapperDbContex dapperUtil,ILogger<AccountRepository> logger){
        this._daperUtil = dapperUtil;
        this._logger = logger;
    }

    public CurrentAccountModel getAccData(String embg){
        throw new NotImplementedException();
    }


    public async Task<List<CurrentAccountModel>> GetAccountByJMBG(String embg){

        using(IDbConnection conn = _daperUtil.CreateConnection){
            // string query = $" Select dbo.brojracuna (530,partija) as BrojRac, sostojba as Stanje,partija as Partija from ITS where status = 2 and embg = '{embg}'";
               string query = $" Select dbo.brojracuna (530,partija) as BrojRac, sostojba as Stanje,partija as Partija,dotvaranje as DatumOtvaranja,dposuplata as DatumPoslednjeUplate,kamgrupa as Kamata,dposplata as DatumPoslednjePlate,posplata as IznosPoslednjePlate from ITS where status = 2 and embg = '{embg}'";
            List<CurrentAccountModel> currentAccountModels = (await conn.QueryAsync<CurrentAccountModel>(sql: query)).ToList();
            return currentAccountModels;

         }

    }
    






    /*public CurrentAccountModel getAccData(String embg)
        {  
             using (IDbConnection conn = _daperUtil.CreateConnection)
             {
                
                try{
               
                    string sql = $" Select dbo.brojracuna (530,partija) as BrojRac, sostojba as Stanje,partija as Partija from ITS where status = 2 and embg = '{embg}'";

                    conn.Open();

                    return (CurrentAccountModel)conn.Query<CurrentAccountModel>(sql, new { embg = embg }).FirstOrDefault();
                
                }
                
                catch(Exception exc){

                    _logger.LogError("Morate unijeti tacan maticni broj...",exc.Message);
                    return null;
                    
                }
              }        
              }*/

}     



