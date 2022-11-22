


using System.Data;

using Bank.Ebank.TransactionalAccount.Models;
using Bank.Ebank.TransactionalAccount.Repositories;
using Microsoft.AspNetCore.Mvc;
using Bank.Ebank.TransactionalAccount.DTO;

namespace Bank.Ebank.TransactionalAccount.Services;


public class AccountService : IAccountService
{   

    private readonly ILogger<AccountRepository> _logger;
    private readonly IAccountRepository _AccountRepository;
    private readonly ICardRepository _CardRepo;
    private readonly ITransactionRepository _TransactionRepo;
    private readonly IReservationRepository _ReservationRepo;
    private readonly IInfoDirectoryRepository _InfoDirectoryRepository;

    private readonly ILogger _cardLogger;
    readonly CurrentAccountModel curModel;


    
    

    
        public AccountService(ILogger <AccountRepository> logger ,IInfoDirectoryRepository infoDirectoryRepository, IReservationRepository reservationRepo,ICardRepository cardRepository,ITransactionRepository transactionRepo,IAccountRepository accountRepository){
      
        this._logger = logger;
        this._CardRepo = cardRepository;
        this._AccountRepository = accountRepository;
        this._ReservationRepo = reservationRepo;
        this._TransactionRepo = transactionRepo;
        this._InfoDirectoryRepository = infoDirectoryRepository;

        }




        public async Task<List<CurrentAccountDTO>> getAll(String jmbg){

            
            var accounts  = await _AccountRepository.GetAccountByJMBG(jmbg);
            List<CurrentAccountDTO> result = new List<CurrentAccountDTO>();

            foreach(CurrentAccountModel account in accounts) {
                var currentAccountDTOTest = new CurrentAccountDTO();

            
                currentAccountDTOTest.BrojRac = account.BrojRac;
                currentAccountDTOTest.Stanje = account.Stanje;
                currentAccountDTOTest.Cards = await _CardRepo.GetCards(account.Partija);
                currentAccountDTOTest.Transactions = await _TransactionRepo.GetTransactions(account.Partija);
                currentAccountDTOTest.Reservations = await _ReservationRepo.GetReservations(account.Partija);
               
                result.Add(currentAccountDTOTest);
            }   
            return result;
        }


        public async Task<List<CurrentAccountModel>> GetAccountByJMBG(String embg){
          var result = await _AccountRepository.GetAccountByJMBG(embg);
           return result;
        }


        public IEnumerable<DirectoryInfoDTO> GetUsers(){
           return _InfoDirectoryRepository.GetUsers();
        }






        public async Task <List<DirectoryInfoDTO>> getInfoByJmbg(String embg){
          var result = await _InfoDirectoryRepository.GetInfoByJmbg(embg);
           return result;     
        }



        public Task CreateUserInfo(DirectoryInfoDTO directoryModel){
          var result = _InfoDirectoryRepository.CreateUserInfo(directoryModel);
           return result;
        }



        public void UpdateUserInfo(DirectoryInfoDTO directoryDTO){

           _InfoDirectoryRepository.UpdateUserInfo(directoryDTO);
           
        }


        public Task DeleteUserInfo(string jmbg){

            var result = _InfoDirectoryRepository.DeleteUserInfo(jmbg);
            return result;
       
        }



        






        






   /* public async Task<List<CardModel>> GetCards(){

        var result = await _CardRepo.GetCards();
        return result;
    }*/



    public Task<List<ReservationModel>> GetReservations()
    {
        throw new NotImplementedException();
    }

    public Task<List<TransactionModel>> GetTransactions()
    {
        throw new NotImplementedException();
    }






    /* public CurrentAccountModel GetCurrAccountModel(String embg){

         return _AccountRepository.getAccData(embg);

     }
     */

    /*public CurrentAccountModel GetCurrAccountModel(String embg){
        
        
        CurrentAccountModel cam = _AccountRepository.getAccData(embg);
        CardModel km = _CardRepo.getCards(cam.brojRac);

        return cam;

    }*/






    public IEnumerable<CardModel> GetCards()                      //**
       {
           return _CardRepo.GetCards();
       }

    
}



