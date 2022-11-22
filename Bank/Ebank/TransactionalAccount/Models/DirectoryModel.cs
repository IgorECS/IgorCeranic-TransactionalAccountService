


using System.ComponentModel.DataAnnotations.Schema;

namespace Bank.Ebank.TransactionalAccount.Models;


[Table("ADRESAR")]


public class DirectoryModel{

    public string? Ime {get;set;}
    public string? Prezime {get;set;}
    public string? Jmbg {get;set;}
    public string? LK {get;set;}
    public string? Adresa {get;set;}
    public string? Mjesto {get;set;}
    public string? Drzava {get;set;}
    public string? BrTelefona {get;set;}
    public string? DatumRodjenja{get;set;}
    public string? MjestoRodjenja{get;set;}
    public int Rezident {get;set;}
    //public int Customer_Kind {get;set;}


}


