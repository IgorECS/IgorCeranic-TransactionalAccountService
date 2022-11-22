using System.Data;
using Bank.Ebank.TransactionalAccount.Models;
using Bank.Ebank.TransactionalAccount.Utils;
using Dapper;

namespace Bank.Ebank.TransactionalAccount.Repositories;

public class TransactionRepository:ITransactionRepository{


    public DapperDbContex _DBc;
    public ILogger<TransactionRepository> _logger;

    public TransactionRepository(DapperDbContex dbContex,ILogger<TransactionRepository> logger){

        this._DBc = dbContex;
        this._logger = logger;
    }

    

    public async Task<List<TransactionModel>> GetTransactions(String account){   

          using (IDbConnection conn = _DBc.CreateConnection)
          {
          
          string query = $"select top 100 DATE1 as Datum,VALIZNOS as Val_Iznos,OPIS as Opis,ALFA1 as Alfa1,PROVIZIJA as Provizija,DP as DP from PTS where partija = '{account}'"; 
          
          List<TransactionModel> transactionModels = (await conn.QueryAsync<TransactionModel>(sql: query)).ToList();
          return transactionModels;

      }
      }


    
}