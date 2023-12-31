using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleAPI.Model.Contatos;

public class Contato {
  
    public int Id { get; set; }
    public String Valor { get; set; }
    public int ClienteId { get; set; } 
    public Cliente Cliente{ get; set; }
    
}

public enum EContato {
    Email = 1,
    Telefone = 2,
    RedeSocial = 3,
}