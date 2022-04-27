using Microsoft.AspNetCore.Mvc;

namespace TheBest.Controllers;

[ApiController]
[Route("[controller]")]

public class JogadoresController : ControllerBase
{
    private static List<Jogadores> listaJogadores = new List<Jogadores>();

    private static int jogadorcountid = 1;

    [HttpGet]
    public ActionResult<String> Get()
    {
        return NotFound("Sucesso");
    }

    [HttpPost]
    public ActionResult<bool> createJogador(Jogadores jogadores)
    {
        listaJogadores.Add(jogadores);
        return true;
    }

    [HttpGet("add")]
    public ActionResult<string> getTop()
    {   
        if(jogadorcountid == 1){
            addJogadores();
            return ("Jogadores adicionados");
        }
        else{
            return("Lista Cheia");
        }
        
    }

    [HttpGet("{id}")]
    public ActionResult<Jogadores> getJogadores(int id)
    {
        Jogadores aux = getJogadorById(id);

        try
        {
            aux = getJogadorById(id);
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

    [HttpPut("{id}")]
    public bool atualizarJogador(int id, Jogadores jogadores)
    {
        Jogadores jogadorOld = getJogadorById(id);

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

    [HttpDelete("{id}")]
    public ActionResult<bool> excluirJogador(int id)
    {
        Jogadores aux = null;

        foreach(Jogadores j in listaJogadores)
        {
            if(j.Id == id)
            {
                aux = j;
                break;
            }
        }

        if(aux != null)
        {
            listaJogadores.Remove(aux);
            return true;
        }

        return false;
    }

    [HttpGet("all")]
    public ActionResult<List<Jogadores>> getAll()
    {
        return listaJogadores;
    }

    private void addJogadores()
    {
        if(jogadorcountid == 1){
            listaJogadores.Add(new Jogadores(jogadorcountid++, "Kevin De Bruyne", 30,"Manchester City","Belga"));
            listaJogadores.Add(new Jogadores(jogadorcountid++, "Neymar", 30, "Paris Saint-Germain", "Brasileiro"));
            listaJogadores.Add(new Jogadores(jogadorcountid++, " Cristiano Ronaldo", 37,"Manchester United","Português"));
            listaJogadores.Add(new Jogadores(jogadorcountid++, " Jorginho", 30,"Chelsea","Brasileiro"));
            listaJogadores.Add(new Jogadores(jogadorcountid++, " Kerim Benzema", 34,"Real Madrid","Francês"));
            listaJogadores.Add(new Jogadores(jogadorcountid++, " Kylian Mbappé", 23,"Paris Saint-Germain","Francês"));
            listaJogadores.Add(new Jogadores(jogadorcountid++, " Lionel Messi", 34,"Paris Saint-Germain","Argentino"));
            listaJogadores.Add(new Jogadores(jogadorcountid++, " Mohamed Salah", 29,"Liverpool","Egípcio"));
            listaJogadores.Add(new Jogadores(jogadorcountid++, " N'Golo Kanté", 31,"Chelsea","Francês"));
            listaJogadores.Add(new Jogadores(jogadorcountid++, " Robert Lewandowski", 33,"Bayern de Munique","Polonês"));
        }
        
            
       
    }

    private Jogadores getJogadorById(int id)
    {
        foreach(Jogadores j in listaJogadores)
        {
            if(j.Id == id)
            {
                return j;
            }
        }

        return null;
    }


}