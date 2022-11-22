using System.ComponentModel.DataAnnotations.Schema;


namespace Bank.Ebank.TransactionalAccount.Models;

[Table("CC_Cards")]

    public class CardModel{
        public string? Card_number { get; set; }
        public string? Account { get; set; }
        public int? Brand { get; set; }
        public DateTime? Valid_thru { get; set; }
        public string? Customer_id { get; set; }
        public int? Type { get; set; }
        public int? Kind { get; set; }

    }

    