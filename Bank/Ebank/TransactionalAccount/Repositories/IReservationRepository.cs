

using Bank.Ebank.TransactionalAccount.Models;

namespace Bank.Ebank.TransactionalAccount.Repositories;

public interface IReservationRepository{
  public Task<List<ReservationModel>> GetReservations(String account);
   
}