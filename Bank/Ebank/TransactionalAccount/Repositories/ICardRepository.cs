using Bank.Ebank.TransactionalAccount.Models;

namespace Bank.Ebank.TransactionalAccount.Repositories;

public interface ICardRepository{
  //public CardModel getCards(String tekuciRacun);
  public IEnumerable <CardModel> GetCards();
  public Task<List<CardModel>> GetCards(string account);
 
   
}