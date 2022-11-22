
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Bank.Ebank.TransactionalAccount.Models;
using Bank.Ebank.TransactionalAccount.Repositories;
using Bank.Ebank.TransactionalAccount.Services;
using Bank.Ebank.TransactionalAccount.DTO;

namespace Bank.Ebank.TransactionalAccount.Controllers; 



[ApiController]
[Route("Api/[controller]")]



public class AccountController : ControllerBase{
        
         private readonly IAccountService _AccountService;
        
        

        public AccountController(IAccountService accountService){
            _AccountService = accountService;

        }
        

        [Route("api/getAccount")]
        [HttpGet]  

        public async Task<List<CurrentAccountModel>> GetAllAccountAsync(String embg){
            var result = await _AccountService.GetAccountByJMBG(embg);
	        return result;
        }

    
    
        [Route ("getAllByID")]
        [HttpGet]

         public async Task<List<CurrentAccountDTO>> getAll(String jmbg){
      
            var result = await _AccountService.getAll(jmbg);
            return result;
    
         }
        [Route("users-from-directory")]
        [HttpGet]
        public IEnumerable<DirectoryInfoDTO> GetUsers(){
             return  _AccountService.GetUsers();
        }


        [Route("user-info-by{jmbg}")]
        [HttpGet]

         public async Task <List<DirectoryInfoDTO>> getInfoByJmbg(String jmbg){

            var result = await _AccountService.getInfoByJmbg(jmbg);
            return result; 

            }


// EditDirectoryInfo{jmbg}
        [HttpPut("directory-info-editor{jmbg}")]

         public void UpdateUserInfo(string jmbg, [FromBody] DirectoryInfoDTO directoryModel){

            directoryModel.Jmbg = jmbg;
            if(ModelState.IsValid){
                _AccountService.UpdateUserInfo(directoryModel);
            }

         }



        [Route("directory-info-creator")]
        [HttpPost]

        public Task CreateAddressInfo(DirectoryInfoDTO directoryModel){
    
            var result = _AccountService.CreateUserInfo(directoryModel);
            return result;

        }




        [Route("directory-info-eraser{jmbg}")]
        [HttpDelete]

        public void DeleteUserInfo(string jmbg){

            _AccountService.DeleteUserInfo(jmbg);
        }






       


         /*[Route("api/getCards[controller]")]
       [HttpGet]
    
       public  async Task<IActionResult> GetCardsByAccAsync(){

	   var ccc = await _AccountService.GetCards();
       return Ok(ccc);
	
    }*/



        [Route("getActiveCards")]
        [HttpGet]
        public IEnumerable<CardModel> GetCards()              //**
        {
           return _AccountService.GetCards();
         }


    

    /*  public async Task<List<CardModel>> GetCardsByAccAsync()
    {
        var result = await _AccountService.GetCardsByAccAsync();
        return result;
    }
*/


    /* public CurrentAccountModel getFromMb(String embg)
     {
         return _AccountService.GetCurrAccountModel(embg);
     }
     */

}