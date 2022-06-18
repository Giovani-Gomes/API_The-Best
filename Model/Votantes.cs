using System.Text.Json;
using System.Text.Json.Serialization;

namespace Votacao;

public class Votantes
{
    public Votantes(int idVo, string grupo){
        Idvo = idVo;
        Grupo = grupo;
       
    }

    public int Idvo { get; set; }

    public string? Grupo { get; set; }
 
}



