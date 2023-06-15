using System.ComponentModel.DataAnnotations;
using SampleAPI.Model.Contatos;

namespace SampleAPI.Model;

public class Cliente{
    public int Id {get; set;}
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public string Email { get; set; }
    public bool Status {get; set;}

    //Exemplo de relacionamento 1:1 
    //(O cliente tem 1 apenas 1 endereco <> O Endreco pertence a 1 apenas 1 Cliente)
    public Endereco Endereco{ get; set; }

    // Exemplo de relacionamento 1:N
    // O cliente possuí 1 ou muitos contatos
    public ICollection<Contato> Contatos { get; set; }
}