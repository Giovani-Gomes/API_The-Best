using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vote;

public class Votos
{
    public Votos(int voto1, int voto2, int voto3, int idV){
        IdV = idV;
        Voto1 = voto1;
        Voto2 = voto2;
        Voto3 = voto3;
    }

    public int IdV {get; set;   }

    public int Voto1 { get; set; }
    
    public int Voto2 { get; set; }
    
    public int Voto3 { get; set; }


}

