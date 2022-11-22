using Bank.Ebank.TransactionalAccount.Utils;
using Bank.Ebank.TransactionalAccount.Models;
using System.Data;
using Dapper;
using Bank.Ebank.TransactionalAccount.DTO;

namespace Bank.Ebank.TransactionalAccount.Repositories;

public class InfoDirectoryRepository : IInfoDirectoryRepository{

public DapperDbContex _DBc;
private readonly ILogger<InfoDirectoryRepository> _logger;

   public InfoDirectoryRepository(DapperDbContex DbContex, ILogger<InfoDirectoryRepository> logger){

      this._DBc = DbContex;
       this._logger = logger;

    }



      public IEnumerable<DirectoryInfoDTO> GetUsers(){                          //GET TOP 30

        using(IDbConnection conn = _DBc.CreateConnection)
            {
                string sql = @"select top 30 ime as Ime, prezime as Prezime, embg as Jmbg, lk as LK, adresa as Adresa, MESTO as Mjesto, DRZAVA as Drzava,TELEFON as BrTelefona,datarag as DatumRodjenja, mestorag as MjestoRodjenja, rezident as Rezident from ADRESAR order by ime asc"; 
                conn.Open();
                return conn.Query<DirectoryInfoDTO>(sql);
            }
       }




      public async Task<List<DirectoryInfoDTO>> GetInfoByJmbg(String jmbg) {              //GETTING BY

          using (IDbConnection conn = _DBc.CreateConnection)
          {
          string query = $"select  ime as Ime, prezime as Prezime, embg as Jmbg, lk as LK, adresa as Adresa, MESTO as Mjesto, DRZAVA as Drzava,TELEFON as BrTelefona,datarag as DatumRodjenja, mestorag as MjestoRodjenja, rezident as Rezident from ADRESAR where ADRESAR.EMBG = '{jmbg}'"; 
        
          List<DirectoryInfoDTO> addressModel = (await conn.QueryAsync<DirectoryInfoDTO>(sql: query)).ToList();
          return addressModel;

         }
      }



      public void UpdateUserInfo(DirectoryInfoDTO addressDTO){          //UPDATE

         using (IDbConnection conn  = _DBc.CreateConnection){

            var query = "Update Adresar SET IME = @Ime, PREZIME = @Prezime, EMBG = @Jmbg, lk = @LK, ADRESA = @Adresa, MESTO = @Mjesto, Drzava = @Drzava, TELEFON = @BrTelefona, DATARAG = @DatumRodjenja WHERE EMBG =@Jmbg";
            conn.Open();
            var asd =  conn.Query(query,addressDTO);
           
         }
      }




   //     public async Task UpdateUserInfo(string jmbg, AddressInfoUpdateDTO addressModel)            //UPDATE vr2.
   //  {
   //      var query = "Update Adresar SET IME = @Ime, PREZIME = @Prezime, EMBG = @Jmbg', ADRESA = @Adresa,MESTO = @Mjesto, Drzava = @Drzava, TELEFON = @BrTelefona, DATARAG = @DatumRodjenja WHERE EMBG =@Jmbg";
        
   //      var parameters = new DynamicParameters();
   //      parameters.Add("Jmbg", jmbg, DbType.String);
   //      parameters.Add("Ime", addressModel.Ime, DbType.String);
   //      parameters.Add("Prezime", addressModel.Prezime, DbType.String);
   //      parameters.Add("Jmbg", addressModel.Jmbg, DbType.String);
   //      parameters.Add("Adresa", addressModel.Adresa, DbType.String);
   //      parameters.Add("Mjesto", addressModel.Mjesto, DbType.String);
   //      parameters.Add("Drzava", addressModel.Drzava, DbType.String);
   //      parameters.Add("BrTelefona", addressModel.BrTelefona, DbType.String);
   //      parameters.Add("DatumRodjenja", addressModel.DatumRodjenja, DbType.String);

   //      using (IDbConnection conn = _DBc.CreateConnection){

   //      await conn.ExecuteAsync(query,parameters);
            
   //  }
   //  }



      public async Task DeleteUserInfo(string jmbg)                    //DELETE BY
         {
        var query = "DELETE FROM Adresar WHERE embg = @Jmbg";

         using(IDbConnection conn = _DBc.CreateConnection){

         await conn.ExecuteAsync(query, new {jmbg });

         }
       }





      public async Task  CreateUserInfo(DirectoryInfoDTO model){                     //CREATEING NEW

        
        var query = "INSERT into ADRESAR (IME,PREZIME,EMBG,LK,ADRESA,MESTO,DRZAVA,TELEFON,DATARAG,MESTORAG,REZIDENT) values (@Ime,@Prezime,@Jmbg,@LK,@Adresa,@Mjesto,@Drzava,@BrTelefona,@DatumRodjenja,@MjestoRodjenja,@Rezident)"
        +"SELECT CAST(SCOPE_IDENTITY() as int)";
       
        var parameters = new DynamicParameters();
       
        parameters.Add("Ime",model.Ime, DbType.String);
        parameters.Add("Prezime",model.Prezime, DbType.String);
        parameters.Add("Jmbg",model.Jmbg, DbType.String);
        parameters.Add("LK",model.LK, DbType.String);
        parameters.Add("Adresa",model.Adresa, DbType.String);
        parameters.Add("Mjesto",model.Mjesto, DbType.String);
        parameters.Add("Drzava",model.Drzava, DbType.String);
        parameters.Add("BrTelefona",model.BrTelefona, DbType.String);
        parameters.Add("DatumRodjenja",model.DatumRodjenja, DbType.String);
        parameters.Add("MjestoRodjenja",model.MjestoRodjenja, DbType.String);
        parameters.Add("Rezident",model.Rezident, DbType.String);

        using (IDbConnection conn = _DBc.CreateConnection){

        await conn.ExecuteAsync(query,parameters);
      //      var customer_kind = await conn.QuerySingleAsync<string>(query,parameters);

      //      var CreatedAddressInfo = new AddressModel{
      //       //Customer_Kind = customer_kind,
      //       Ime = model.Ime,
      //       Prezime = model.Prezime,
      //       Jmbg = model.Prezime,
      //       LK = model.LK,
      //       Adresa = model.Adresa,
      //       Mjesto = model.Mjesto,
      //       Drzava = model.Drzava,
      //       BrTelefona = model.BrTelefona,
      //       DatumRodjenja = model.DatumRodjenja,
      //       MjestoRodjenja = model.MjestoRodjenja,
      //       Rezident = model.Rezident

      //      };

      //      return CreatedAddressInfo;

      //   }

        }
      }

   
}



      






