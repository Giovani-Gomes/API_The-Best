# API_The-Best

## Descrição
<p>Simule, por meio de uma API, a Eleição “The best” da FIFA. A eleição simulada deve ocorrer
atrás de votos divididos em quatro grupos de eleitores (Técnicos, Capitães, Jornalistas e
Publico Geral), considere 10 votantes para cada grupo. Cada votante tem direito a escolher
os três melhores atletas, entre 10, de cada categoria. Ao final da votação ordena-se os
atletas por quantidade de votos recebidos, para cada grupo votante, e atribui-se ao atleta
5 pontos para o primeiro, 3 pontos para o segundo colocado e 1 ponto para o terceiro. Os
três primeiros, melhores votados são os atletas que obtiverem a maior quantidade de pontos
entre os 4 grupos votantes. </p>
<p> A simulação deve conter os endpoints:</p> 
 * CadastroJogador : esse endpoint possibilitará o cadastro de jogador (Id, Nome, Idade,
Clube, Nacionalidade e Quantidade Votos). Sendo o Id gerado pelo simulador e a
quantidade de votos inicialmente com ZERO, limitando em uma lista de 10 jogadores; <br>
 * AtualizarJogador: nesse endpoint será possível atualizar o Nome, Idade, Clube e
Nacionalidade de um jogador por Id;<br>
 * ExcluirJogador: a exclusão do jogador deve ocorrer por esse endpoint, via Id, apenas
se o jogador não ter recebido nenhum voto;
* ListaCandidatos: listar todos os 10 jogados candidatos ao prêmio, apresentando nome,
idade, clube e nacionalidade;<br>
* Votar: através deste serviço, um votante, envia o seu voto, informando qual o grupo
pertence, seu código de identificação e o voto (com os 3 jogadores escolhidos);<br>
* VotosPorGrupo: a considerar os votos, esse endpoint deve retornar os 3 atletas mais
votados pelo grupo informando quantos votos foram recebidos;<br>
* TheBest: Contabilizando os mais votados de cada grupo, esse endpoint retorna os 3
atletas que receberam mais pontos entre os quatro grupos.
