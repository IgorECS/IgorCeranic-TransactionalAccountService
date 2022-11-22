
using Bank.Ebank.TransactionalAccount.Models;

namespace Bank.Ebank.TransactionalAccount.Repositories;

public interface ITransactionRepository{

public  Task<List<TransactionModel>> GetTransactions(String account);

}