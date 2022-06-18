using System.Text.Json;
using System.Text.Json.Serialization;

namespace thebest;

public class Jogadores
{
    public Jogadores(int idJ, String nome, int idade, String clube, String nacionalidade, int quantidadeDeVotos){
        IdJ = idJ;
        Nome = nome;
        Idade = idade;
        Clube = clube;
        Nacionalidade = nacionalidade;
        QuantidadeDeVotos = quantidadeDeVotos;
    }

    public int IdJ { get; set; }

    public string? Nome { get; set; }

    public int Idade { get; set; }
      
    public string? Clube { get; set; }

    public string? Nacionalidade { get; set; }

    public int QuantidadeDeVotos { get; set;}
}

