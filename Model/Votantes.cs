using System.Text.Json;
using System.Text.Json.Serialization;

namespace Votacao;

public class Votantes
{
    public Votantes(int id, string grupo){
        Id = id;
        Grupo = grupo;
       
    }

    public int Id { get; set; }

    public string? Grupo { get; set; }
 
}



