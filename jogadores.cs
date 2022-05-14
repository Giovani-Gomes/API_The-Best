namespace TheBest;

public class Jogadores
{
    public Jogadores(int idJ, string nome, int idade, string clube, string nacionalidade)
    {
        IdJ = idJ;
        Nome = nome;
        Idade = idade;
        Clube = clube;
        Nacionalidade = nacionalidade;
      //  QuantidadeVotos = 0;
    }

    public Jogadores()
    {
    }

    public int IdJ { get; set; }

    public string? Nome { get; set; }

    public int Idade { get; set; }

    public string? Clube { get; set; }

    public string? Nacionalidade { get; set; }

    public int QuantidadeVotos { get; set; }
}

public class Tecnicos{
    public Tecnicos(int id, string nome, string grupo)
    {
        
    }
} 

public class Capitaes{
    public Capitaes(int id, string nome, string grupo)
    {
        
    }
} 

public class Jornalistas{
    public Jornalistas(int id, string nome, string grupo)
    {
        
    }
} 

public class publicoGeral{
    public publicoGeral(int id, string nome, string grupo)
    {
        
    }
} 