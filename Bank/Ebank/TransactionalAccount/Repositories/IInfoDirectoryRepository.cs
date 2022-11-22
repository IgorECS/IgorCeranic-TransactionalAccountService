using Bank.Ebank.TransactionalAccount.Models;
using Bank.Ebank.TransactionalAccount.DTO;


namespace Bank.Ebank.TransactionalAccount.Repositories;


public interface IInfoDirectoryRepository{
public IEnumerable<DirectoryInfoDTO> GetUsers();
public Task<List<DirectoryInfoDTO>>GetInfoByJmbg(String jmbg);
public Task CreateUserInfo(DirectoryInfoDTO directoryModel);
public void UpdateUserInfo(DirectoryInfoDTO directoryDTO);
//public Task UpdateAddressInfo(string jmbg, AddressInfoUpdateDTO addressModel);
public Task DeleteUserInfo(string jmbg);

    
}