
using Bank.Ebank.TransactionalAccount.Models;


namespace Bank.Ebank.TransactionalAccount.DTO;


public class CurrentAccountDTO{

    public string? BrojRac { get; set; }
    public double Stanje { get; set; }
    public String? DatumOtvaranja{get;set;}
    public String? DatumPolsednjeUplate{get;set;}
    public String? Kamata{get;set;}
    public double IznosPoslednjePlate{get;set;}
    public String? DatumPoslednjePlate{get;set;}


    //public List<CurrentAccountModel>? Accounts{get;set;}
    public List<TransactionModel>? Transactions{get;set;}
    public List<CardModel>? Cards{get;set;}
    public List<ReservationModel>? Reservations{get;set;}


   


}