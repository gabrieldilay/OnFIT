using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Models {

public class Usuario
    {
    public  int Id { get; set; }
    public string Login {get; set;}
    [JsonIgnore]
    public  string Senha { get; set; }
    
    
    }
}