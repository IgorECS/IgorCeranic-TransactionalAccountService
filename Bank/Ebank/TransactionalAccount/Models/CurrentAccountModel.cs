

using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Bank.Ebank.TransactionalAccount.Models;
    
    [Table("ITS")]
   
    public class CurrentAccountModel{
             public String? BrojRac { get; set; }
             public double Stanje { get; set; }
             public String? Partija{get; set;}

        
    }
