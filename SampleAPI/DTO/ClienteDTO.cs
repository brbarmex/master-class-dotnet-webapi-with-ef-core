
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace SampleAPI.DTO;

public class ClienteDTO {

    public string Name { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public bool Status {get; set;}

    public EStatus TestField {get; set;}

    
}

[JsonConverter(typeof(StringEnumConverter))]
public enum EStatus {
    Ativo,
    Desativado
}
