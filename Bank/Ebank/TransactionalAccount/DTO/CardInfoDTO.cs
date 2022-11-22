

namespace Bank.Ebank.TransactionalAccount.DTO;

public class CardInfoDTO{
    public string? Card_number { get; set; }
    public string? Account { get; set; }
    public DateTime? Valid_thru { get; set; }
    public string? Customer_id { get; set; }
    public int? Type { get; set; }


}