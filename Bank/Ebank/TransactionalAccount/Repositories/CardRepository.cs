using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;

using Bank.Ebank.TransactionalAccount.Utils;
using Bank.Ebank.TransactionalAccount.Models;


namespace Bank.Ebank.TransactionalAccount.Repositories;


public class CardRepository : ICardRepository{
   

    private readonly DapperDbContex _daperUtil;
    private readonly ILogger<CardRepository> _logger;
    
    private readonly CurrentAccountModel _CurrentAccountModel;

    public CardRepository (DapperDbContex dapperUtil,ILogger<CardRepository> logger){
        this._daperUtil = dapperUtil;
        this._logger = logger;
    }

   
     public async Task<List<CardModel>> GetCards(String account) {   

          using (IDbConnection conn = _daperUtil.CreateConnection)
          {
          string query = $"select card_number as Card_number,account as Account,brand as Brand, type as Type, kind as Kind,valid_thru as Valid_thru, customer_id as Customer_id from CC_Cards join cc_Partije_Eksterne on CC_Cards.account = cc_Partije_Eksterne.ccPartija join ITS on ITS.PARTIJA = cc_Partije_Eksterne.exPartija where CC_Cards.card_status = 1 and cc_Partije_Eksterne.exPartija = '{account}'"; 
        
          List<CardModel> cardModels = (await conn.QueryAsync<CardModel>(sql: query)).ToList();
          return cardModels;

      }
      }




    public IEnumerable<CardModel> GetCards()
    {
        using(IDbConnection conn = _daperUtil.CreateConnection)
            {
                string sql = @"select top 10 card_number as card_number,account as account,brand as brend, type as type, kind as kind,valid_thru as valid_thru, customer_id as customer_id from CC_Cards where card_status = 1"; 
                conn.Open();
                return conn.Query<CardModel>(sql);
            }
    }



}