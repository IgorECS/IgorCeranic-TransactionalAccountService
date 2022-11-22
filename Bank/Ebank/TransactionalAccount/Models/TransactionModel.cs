

using System.ComponentModel.DataAnnotations.Schema;

namespace Bank.Ebank.TransactionalAccount.Models;

[Table ("PTS")]
    public class TransactionModel{
        public String? Datum { get; set; }
        //public string? Vreme { get; set; }
        public float? Val_Iznos { get; set; }
        public string? Opis { get; set; }
        public string? Alfa1{ get; set; }
        public float? Provizija { get; set; }
        public int? DP { get; set; }          

    }

