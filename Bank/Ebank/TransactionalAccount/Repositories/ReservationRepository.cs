
using System.Data;
using Bank.Ebank.TransactionalAccount.Models;
using Bank.Ebank.TransactionalAccount.Utils;
using Dapper;

namespace Bank.Ebank.TransactionalAccount.Repositories;

public class ReservationRepository:IReservationRepository{

public DapperDbContex _DBc;
 private readonly ILogger<ReservationRepository> _logger;

 public ReservationRepository(DapperDbContex DbContex, ILogger<ReservationRepository> logger){

    this._DBc = DbContex;
    this._logger = logger;

 }

public async Task<List<ReservationModel>> GetReservations(String account){   

          using (IDbConnection conn = _DBc.CreateConnection)
          {
          string query = $"select top 10 partija as Partija,pan as Pan,iznos as Iznos,datum_aktiviranja as Datum_Aktiviranja from OTHA_Rezervacije where OTHA_Rezervacije.status = 1 and partija = '{account}'"; 
          
          List<ReservationModel> reservationModels = (await conn.QueryAsync<ReservationModel>(sql: query)).ToList();
          return reservationModels;

      }
      }




}