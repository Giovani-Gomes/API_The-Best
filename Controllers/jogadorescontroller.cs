using Microsoft.AspNetCore.Mvc;

namespace TheBest.Controllers;

[ApiController]
[Route("[controller]")]

public class JogadoresController : ControllerBase
{   
    
    private static List<Jogadores> listaJogadores = new List<Jogadores>();

    [HttpGet]
    public ActionResult<bool> Get(){
        if(listaJogadores.Count == 0){
            addJogadores();
            return Ok(true);
        }
        else{
            return NotFound(false);
        }
            
    } 

    [HttpPost]
    public ActionResult<bool> createJogador(Jogadores jogadores){
         if(jogadores== null){
            return StatusCode(204," Valores inválidos! ");
        }
        else if(jogadores.Nome == null || jogadores.Nome == "" || jogadores.Clube == null || jogadores.Clube == ""|| jogadores.Nacionalidade == null || jogadores.Nacionalidade == ""|| jogadores.Idade == null ||jogadores.Idade <= 18 ){
            return StatusCode(204, "É necessário informar Todos os campos corretamente");
        }
    for (int i = 1; i == 10; i++){
        if (listaJogadores[i] == null || i != 10){
            jogadores.IdJ = i;
            listaJogadores.Add(jogadores);   
        }else{
            return StatusCode(204,"Lista de jogadores cheia");
        }
    }
        
        return Ok(true);
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
            return NotFound("Jogador não existente");
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

        if(jogadores.Idade != null)
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

    private void addJogadores()
    {
        
            listaJogadores.Add(new Jogadores(1, "Kevin De Bruyne", 30,"Manchester City","Belga"));
            listaJogadores.Add(new Jogadores(2, "Neymar", 30, "Paris Saint-Germain", "Brasileiro"));
            listaJogadores.Add(new Jogadores(3, " Cristiano Ronaldo", 37,"Manchester United","Português"));
            listaJogadores.Add(new Jogadores(4, " Jorginho", 30,"Chelsea","Brasileiro"));
            listaJogadores.Add(new Jogadores(5, " Kerim Benzema", 34,"Real Madrid","Francês"));
            listaJogadores.Add(new Jogadores(6, " Kylian Mbappé", 23,"Paris Saint-Germain","Francês"));
            listaJogadores.Add(new Jogadores(7, " Lionel Messi", 34,"Paris Saint-Germain","Argentino"));
            listaJogadores.Add(new Jogadores(8, " Mohamed Salah", 29,"Liverpool","Egípcio"));
            listaJogadores.Add(new Jogadores(9, " N'Golo Kanté", 31,"Chelsea","Francês"));
            listaJogadores.Add(new Jogadores(10, " Robert Lewandowski", 33,"Bayern de Munique","Polonês"));

    }

    private Jogadores getJogadorById(int idJ)
    {
        foreach(Jogadores j in listaJogadores)
        {
            if(j.IdJ == idJ)
            {
                return j;
            }
        }

        return null;
    }


}