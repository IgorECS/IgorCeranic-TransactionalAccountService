
using Bank.Ebank.TransactionalAccount.Models;

namespace Bank.Ebank.TransactionalAccount.Repositories;

public interface IAccountRepository{
  //public CurrentAccountModel getAccData(String embg);
  public Task<List<CurrentAccountModel>> GetAccountByJMBG(String embg);
   
      }
