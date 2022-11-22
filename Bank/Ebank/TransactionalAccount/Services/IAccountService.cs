
using Bank.Ebank.TransactionalAccount.DTO;
using Bank.Ebank.TransactionalAccount.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Ebank.TransactionalAccount.Services;

public interface IAccountService{
    //public CurrentAccountModel GetCurrAccountModel(String embg);
    // public CardModel getCardsModel(String tekuciRacun);
   
    //Task<List<CardModel>> GetCards();
    IEnumerable <CardModel> GetCards();      //izlistava sve kartice

    //  public Task<List<CurrentAccountDTO>> getAll(String jmbg);

    Task<List<CurrentAccountModel>> GetAccountByJMBG(String embg);
    Task<List<CurrentAccountDTO>> getAll(String jmbg);
    Task<List<TransactionModel>> GetTransactions();
    Task<List<ReservationModel>> GetReservations();
    IEnumerable<DirectoryInfoDTO> GetUsers();
    Task <List<DirectoryInfoDTO>> getInfoByJmbg(String jmbg);
    Task CreateUserInfo(DirectoryInfoDTO addressDTO);
    //Task UpdateUserInfo(string jmbg, AddressInfoUpdateDTO addressModel);
    void UpdateUserInfo(DirectoryInfoDTO addressDTO);
    Task DeleteUserInfo(string jmbg);

           

       


    }
