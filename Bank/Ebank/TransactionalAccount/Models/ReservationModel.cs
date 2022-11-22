
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank.Ebank.TransactionalAccount.Models;

[Table("OTHA_Rezervacije")]
    public class ReservationModel{
        public string? Partija { get; set; }
        public string? Pan {get;set;}
        public float? Iznos { get; set; }
        public string? Datum_Akriviranja { get; set; }


    }





