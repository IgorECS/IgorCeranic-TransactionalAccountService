

using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Bank.Ebank.TransactionalAccount.Models;
    
    [Table("ITS")]
   
    public class CurrentAccountModel{
             public String? BrojRac { get; set; }
             public double Stanje { get; set; }
             public String? Partija {get; set;}
             public String? DatumOtvaranja{get;set;}
             public String? DatumPolsednjeUplate{get;set;}
             public String? Kamata{get;set;}
             public double IznosPoslednjePlate{get;set;}
             public String? DatumPoslednjePlate{get;set;}

        
    }
