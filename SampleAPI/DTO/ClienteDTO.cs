
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SampleAPI.Model;

namespace SampleAPI.DTO;

public class ClienteDTO {

    public string Name { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public bool Status {get; set;}
    public EStatus TestField {get; set;}

}

public class StatusDto {
    public EStatus Status { get; set; }
}



