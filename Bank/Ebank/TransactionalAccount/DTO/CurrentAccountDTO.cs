
using Bank.Ebank.TransactionalAccount.Models;


namespace Bank.Ebank.TransactionalAccount.DTO;


public class CurrentAccountDTO{

    public string? BrojRac { get; set; }
    public double Stanje { get; set; }

    //public List<CurrentAccountModel>? Accounts{get;set;}
    public List<TransactionModel>? Transactions{get;set;}
    public List<CardModel>? Cards{get;set;}
    public List<ReservationModel>? Reservations{get;set;}


   


}