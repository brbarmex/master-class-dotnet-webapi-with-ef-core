namespace SampleAPI.Model;

public class Endereco {

    public int Id { get; set; }
    public string Numero { get; set; }
    public string Logradouro {get; set;}
    public string Cidade {get; set;}
    public string Cep {get; set;}
    public string Estado {get; set;}

    public int ClienteId {get; set;}
    public Cliente Cliente {get; set;}  

}