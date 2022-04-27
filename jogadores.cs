namespace TheBest;

public class Jogadores
{
    public Jogadores(int id, string nome, int idade, string clube, string nacionalidade)
    {
        Id = id;
        Nome = nome;
        Idade = idade;
        Clube = clube;
        Nacionalidade = nacionalidade;
      //  QuantidadeVotos = 0;
    }

    public Jogadores()
    {
    }

    public int Id { get; set; }

    public string? Nome { get; set; }

    public int Idade { get; set; }

    public string? Clube { get; set; }

    public string? Nacionalidade { get; set; }

    public int QuantidadeVotos { get; set; }
}

/* public class Tecnicos
{
    public Tecnicos(int id, string nome, string grupo)
    {

    }
} */