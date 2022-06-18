using Microsoft.AspNetCore.Mvc;
using thebest;
using Votacao;
using Vote;

namespace thebest.Controllers;


[ApiController]
[Route("/api/thebest/")]

public class JogadoresController : ControllerBase
{
    private static int countId = 1;
    private static List<Jogadores> listaJogadores = new List<Jogadores>();
    //private static List<Votos> listaVotos = new List<Votos>();
    private static List<Votos> listaPublicoGeral = new List<Votos>();
    private static List<Votos> listaTecnicos = new List<Votos>();
    private static List<Votos> listaJornalistas = new List<Votos>();
    private static List<Votos> listaCapitaes = new List<Votos>();

    [HttpPost]
    public ActionResult<int> createJogador(Jogadores jogadores){
        int Size = listaJogadores.Count;
    if(Size >= 10){

        return StatusCode(500, "Lista Cheia");

        }else if(jogadores.Nome == "" || jogadores.Idade < 18 || jogadores.Nacionalidade == "" || jogadores.Clube == ""){
            return StatusCode(500, "valores invalidos");
    }else{

        jogadores.IdJ = countId++;
        jogadores.QuantidadeDeVotos = 0;
        listaJogadores.Add(jogadores);
        
        return jogadores.IdJ;
    }
    }

    [HttpGet("{idJ}")]
    public ActionResult<Jogadores> getJogadores(int idJ){
        Jogadores aux = getJogadorById(idJ);

        try
        {
            aux = getJogadorById(idJ);
        }

        catch(System.Exception)
        {
            return StatusCode(500, "Plataforma incompativel");
        }
        
        if(aux == null)
        {
            return StatusCode(500, "Jogador não existente");
        }

        return Ok(aux);
    }

    [HttpPut("{idJ}")]
    public bool atualizarJogador(int idJ, Jogadores jogadores){
        Jogadores jogadorOld = getJogadorById(idJ);

        if(jogadorOld == null)
        {
            return false;
        }

        if(jogadores.Nome != null)
        {
            jogadorOld.Nome = jogadores.Nome;
        }

        if(jogadores.Idade >= 18)
        {
            jogadorOld.Idade = jogadores.Idade;
        }

        if (jogadores.Clube != null)
        {
            jogadorOld.Clube = jogadores.Clube;
        }

        if (jogadores.Nacionalidade != null)
        {
            jogadorOld.Nacionalidade = jogadores.Nacionalidade;
        }

        return true;
    }

    [HttpDelete("{idJ}")]
    public ActionResult<bool> excluirJogador(int idJ)
    {
        Jogadores aux = null;

        Jogadores jogadoresOld = getJogadorById(idJ);

        if(jogadoresOld == null){
            return NotFound(false);
        }
        else{
            aux = jogadoresOld;                          
        }        
        if(aux != null){
            listaJogadores.Remove(aux);
            return Ok(true);
        }        
        return NotFound(false);

    }

    [HttpGet("all")]
    public ActionResult<List<Jogadores>> getAll()
    {
        return listaJogadores;
    }


    

    private Jogadores getJogadorById(int idJ)
    {
        foreach(Jogadores jogador in listaJogadores)
        {
            if(jogador.IdJ == idJ)
            {
                return jogador;
            }
        }

        return null;
    }

    [HttpPatch("{idVo}/{grupo}")]
    public ActionResult<int> Votar(Votos votos, Votantes votantes, int voto1, int voto2, int voto3, int idVo, int id, string grupo){
        int PositionPG = listaPublicoGeral.Count;
        int PositionT = listaTecnicos.Count;
        int PositionJ = listaJornalistas.Count;
        int PositionC = listaCapitaes.Count;
        

        if(votantes.Grupo == null || votantes.Grupo == ""){
            return 96;

        }

        if(PositionPG < 10 && votantes.Grupo == "publicogeral"){
            idV = votantes.Id; 
            listaPublicoGeral.Add(votos);
            return PositionPG;

        }if(PositionT < 10 && votantes.Grupo == "tecnico"){
            listaTecnicos.Add(votos);
            return PositionT;

        }if(PositionJ < 10 && votantes.Grupo == "jornalista"){
            listaJornalistas.Add(votos);
            return PositionJ;

        }if(PositionC < 10 && votantes.Grupo == "capitao"){
            listaCapitaes.Add(votos);
            return PositionC;

        }
        else{
            
            return 69;
        }
    }

    [HttpGet("LP")]
    public ActionResult<List<Votos>> getLP()
    {
        return listaPublicoGeral;
    }


}