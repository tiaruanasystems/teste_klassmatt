using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_klassmatt.Dominio;

namespace Teste_klassmatt
{
    class Jogo
    {

        private JogoDaVelha jogoDaVelha = new JogoDaVelha();

        private bool fimDeJogo = false;

        public void Iniciar()
        {
            while (!fimDeJogo)
            {
                RenderizarTabela();
                LerEscolhaDoUsuario();
                RenderizarTabela();
                VerficarFimDeJogo();
                MudarVez();
            }
        }


        private void MudarVez()
        {
            jogoDaVelha.vez = jogoDaVelha.vez == 'X' ? 'O' : 'X';
        }

        private void VerficarFimDeJogo()
        {
            if (jogoDaVelha.quantidadePreenchida < 5)
                return;

            if (ExisteVitoriaHorizontal() || ExisteVitoriaVertical() || ExisteVitoriaDiagonal())
            {
                fimDeJogo = true;
                Console.WriteLine($"Fim de jogo!!! Vitória de {jogoDaVelha.vez}");
                return;
            }

            if (jogoDaVelha.quantidadePreenchida is 9)
            {
                fimDeJogo = true;
                Console.WriteLine("Fim de jogo!!! EMPATE");
            }
        }

        private bool ExisteVitoriaHorizontal()
        {
            var posicoes = jogoDaVelha.posicoes;


            bool vitoriaLinha1 = posicoes[0] == posicoes[1] && posicoes[0] == posicoes[2];
            bool vitoriaLinha2 = posicoes[3] == posicoes[4] && posicoes[3] == posicoes[5];
            bool vitoriaLinha3 = posicoes[6] == posicoes[7] && posicoes[6] == posicoes[8];

            return vitoriaLinha1 || vitoriaLinha2 || vitoriaLinha3;
        }

        private bool ExisteVitoriaVertical()
        {
            var posicoes = jogoDaVelha.posicoes;

            bool vitoriaLinha1 = posicoes[0] == posicoes[3] && posicoes[0] == posicoes[6];
            bool vitoriaLinha2 = posicoes[1] == posicoes[4] && posicoes[1] == posicoes[7];
            bool vitoriaLinha3 = posicoes[2] == posicoes[5] && posicoes[2] == posicoes[8];

            return vitoriaLinha1 || vitoriaLinha2 || vitoriaLinha3;
        }

        private bool ExisteVitoriaDiagonal()
        {
            var posicoes = jogoDaVelha.posicoes;

            bool vitoriaLinha1 = posicoes[2] == posicoes[4] && posicoes[2] == posicoes[6];
            bool vitoriaLinha2 = posicoes[0] == posicoes[4] && posicoes[0] == posicoes[8];

            return vitoriaLinha1 || vitoriaLinha2;
        }

        private void LerEscolhaDoUsuario()
        {
            Console.WriteLine($"Agora é a vez de {jogoDaVelha.vez}, entre uma posição de 1 a 9 que esteja disponível na tabela");

            bool conversao = int.TryParse(Console.ReadLine(), out int posicaoEscolhida);


            while (!conversao || !ValidarEscolhaUsuario(posicaoEscolhida))
            {
                Console.WriteLine("O campo escolhido é inválido, por favor digite um número entre 1 e 9 que esteja disponível na tabela.");
                conversao = int.TryParse(Console.ReadLine(), out posicaoEscolhida);
            }

            PreencherEscolha(posicaoEscolhida);
        }

        private void PreencherEscolha(int posicaoEscolhida)
        {
            int indice = posicaoEscolhida - 1;

            jogoDaVelha.posicoes[indice] = jogoDaVelha.vez;
            jogoDaVelha.quantidadePreenchida++;
        }

        private bool ValidarEscolhaUsuario(int posicaoEscolhida)
        {
            var posicoes = jogoDaVelha.posicoes;
            int indice = posicaoEscolhida - 1;


            return posicoes[indice] != 'O' && posicoes[indice] != 'X';



        }

        private void RenderizarTabela()
        {
            Console.Clear();
            Console.WriteLine(ObterTabela());
        }

        private string ObterTabela()
        {
            var posicoes = jogoDaVelha.posicoes;

            return $"__{posicoes[0]}__|__{posicoes[1]}__|__{posicoes[2]}__\n" +
                   $"__{posicoes[3]}__|__{posicoes[4]}__|__{posicoes[5]}__\n" +
                   $"  {posicoes[6]}  |  {posicoes[7]}  |  {posicoes[8]}  \n\n";
        }
    }
}
