using Microsoft.AspNetCore.Mvc;
using thebest;
using Votacao;
using Vote;

namespace Jogador.Controllers;


[ApiController]
[Route("/api/thebest/")]

public class JogadoresController : ControllerBase
{
    private static int countId = 1;

    private static int[] coutV = {0,1,2};
    private static List<Jogadores> listaJogadores = new List<Jogadores>();
    //private static List<Array> listatje = new List<Array>();
    private static List<Votos> listaPublicoGeral = new List<Votos>();

    private static List<int> listaThemost = new List<int>();
    private static List<Jogadores> listaTheBest = new List<Jogadores>();

    private static List<int> listaMaisVotados = new List<int>();
    private static List<int> listaWinners = new List<int>();
    private static List<Votos> listaTecnicos = new List<Votos>();
    private static List<Votos> listaJornalistas = new List<Votos>();
    private static List<Votos> listaCapitaes = new List<Votos>();

    [HttpPost("jogador/novo")]
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

    [HttpGet("jogador/{idJ}")]
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

    [HttpPut("jogador/atualizar/{idJ}")]
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

    [HttpDelete("jogadores/deletar/{idJ}")]
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

    [HttpGet("jogadores/all")]
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

    [HttpPatch("votar/{id}/{grupo}")]
    public ActionResult<int> Votar(int id, string grupo, int voto1, int voto2, int voto3, Votos votos){
        int PositionPG = listaPublicoGeral.Count;
        int PositionT = listaTecnicos.Count;
        int PositionJ = listaJornalistas.Count;
        int PositionC = listaCapitaes.Count;

        if(grupo == null || grupo == ""){
            return StatusCode(500, "grupo necessario");

        }
        if(votos.Voto1 == votos.Voto2){
            return StatusCode(500, "votos iguais");
        }if(votos.Voto1 == votos.Voto3){
            return StatusCode(500, "votos iguais");
        }if(votos.Voto2 == votos.Voto3){
            return StatusCode(500, "votos iguais");
        }if(votos.Voto2 == votos.Voto1){
            return StatusCode(500, "votos iguais");
        }if(votos.Voto3 == votos.Voto1){
            return StatusCode(500, "votos iguais");
        }if(votos.Voto3 == votos.Voto2){
            return StatusCode(500, "votos iguais");
        }

        if(PositionPG < 10 && grupo == "publicogeral"){
            votos.IdV = id; 
            listaPublicoGeral.Add(votos);
            return PositionPG;

        }if(PositionT < 10 && grupo == "tecnico"){
            listaTecnicos.Add(votos);
            return PositionT;

        }if(PositionJ < 10 && grupo == "jornalista"){
            listaJornalistas.Add(votos);
            return PositionJ;

        }if(PositionC < 10 && grupo == "capitao"){
            listaCapitaes.Add(votos);
            return PositionC;

        }
        else{
            
            return StatusCode(500, "votos dessa categoria foram finalizados");
        }
    }

    [HttpGet("maisvotados/{grupo}")]
    public ActionResult<List<int>> Melhores(string grupo)
    {   
        listaThemost.Clear();
        listaWinners.Clear();
        int CountPosition = 1;
        int selected;
        if(grupo == "publicogeral")
        {
            foreach (Votos votos in listaPublicoGeral)
        {     

            selected = votos.Voto1;
            listaThemost.Add(selected);
            
        }
        foreach (Votos votos in listaPublicoGeral)
        {     

            selected = votos.Voto2;
            listaThemost.Add(selected);
            
        }
        foreach (Votos votos in listaPublicoGeral)
        {     

            selected = votos.Voto3;
            listaThemost.Add(selected);
                     
        }
        

        }
        if(grupo == "jornalistas")
        {
            foreach (Votos votos in listaJornalistas)
        {     

            selected = votos.Voto1;
            listaThemost.Add(selected);
            
        }
        foreach (Votos votos in listaJornalistas)
        {     

            selected = votos.Voto2;
            listaThemost.Add(selected);
            
        }
        foreach (Votos votos in listaJornalistas)
        {     

            selected = votos.Voto3;
            listaThemost.Add(selected);
                     
        }
        

        }
        if(grupo == "tecnicos")
        {
            foreach (Votos votos in listaTecnicos)
        {     

            selected = votos.Voto1;
            listaThemost.Add(selected);
            
        }
        foreach (Votos votos in listaTecnicos)
        {     

            selected = votos.Voto2;
            listaThemost.Add(selected);
            
        }
        foreach (Votos votos in listaTecnicos)
        {     

            selected = votos.Voto3;
            listaThemost.Add(selected);
                     
        }
        

        }
        if(grupo == "capitaes")
        {
            foreach (Votos votos in listaCapitaes)
        {     

            selected = votos.Voto1;
            listaThemost.Add(selected);
            
        }
        foreach (Votos votos in listaCapitaes)
        {     

            selected = votos.Voto2;
            listaThemost.Add(selected);
            
        }
        foreach (Votos votos in listaCapitaes)
        {     

            selected = votos.Voto3;
            listaThemost.Add(selected);
                     
        }
        

        } 
        
        foreach (int y in coutV)
        {
            int most = (from i in listaThemost
            group i by i into grp
            orderby grp.Count() descending
            select grp.Key).First();
            
            if (CountPosition == 1)
                {
                    foreach (Jogadores jogador  in listaJogadores)
                    {
                    
                        if (jogador.IdJ == most)
                        {
                            
                            jogador.QuantidadeDeVotos += listaThemost.Count(item => item == most);
                        }
                    }
                }
            else if (CountPosition == 2)
                {
                    foreach (Jogadores jogador  in listaJogadores)
                    {
                    
                        if (jogador.IdJ == most)
                        {
                            jogador.QuantidadeDeVotos += listaThemost.Count(item => item == most);
                        }
                    }
                }
            else if (CountPosition == 3)
                {
                    foreach (Jogadores jogador  in listaJogadores)
                    {
                    
                        if (jogador.IdJ == most)
                        {
                            jogador.QuantidadeDeVotos += listaThemost.Count(item => item == most);
                        }
                    }
                }
        listaMaisVotados.Add(most);
        listaWinners.Add(most);   
        listaThemost.RemoveAll(item => item == most);
        CountPosition ++;
        }
        return(listaWinners);
        
    }
    [HttpGet("vencedores")]
    public ActionResult<List<Jogadores>> Thebest(){
            foreach (int y in coutV)
        {
            int best = (from i in listaMaisVotados
            group i by i into grp
            orderby grp.Count() descending
            select grp.Key).First();
            
        foreach (Jogadores jogador in listaJogadores)
        {
            Jogadores jogadoresOld = getJogadorById(best);
            if (jogador.IdJ == best)
            {
                listaTheBest.Add(jogadoresOld);
            }
        }

            
         
        listaMaisVotados.RemoveAll(item => item == best);
        
        }
        return(listaTheBest);
    }

}