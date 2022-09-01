using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Teste_klassmatt.Ferramentas;

namespace Teste_klassmatt
{
    public class Partida
    {
        private Tabuleiro tabuleiro;
        private HistoricoVitoria historicoVitoria;
        private List<Jogador> listaJogadores;
        private Jogador JogadorAtual;

        public Partida()
        {
            tabuleiro = new Tabuleiro();
            historicoVitoria = new HistoricoVitoria();
            listaJogadores = new List<Jogador>();
        }

        internal void IniciarJogo()
        {
            MenuInicial();
            IncluirUsuarios();

            while (true)
            {
                try
                {
                    Console.Clear();
                    ExibePlacar();
                    ExibeTabuleiro();

                    Console.Write("É a sua vez " + JogadorAtual.Nome + ": ");
                    string console = Console.ReadLine();

                    #region Validacoes

                    if (console == null || console.Trim() == "")
                        throw new Exception(Mensagens.CasaForaTabuleiro());

                    int jogada = console.Trim().GetInteiro();
                    if (jogada < 1 || jogada > 9)
                        throw new Exception(Mensagens.CasaForaTabuleiro());

                    if (!tabuleiro.AddJogada(JogadorAtual, jogada - 1))
                        throw new Exception(Mensagens.CasaOcupada());

                    #endregion Validacoes

                    EstadoCampo EstadoVencedor = tabuleiro.CheckCondicaoVitoria();
                    if (EstadoVencedor != EstadoCampo.Vazio)
                    {
                        Jogador jogadorVitorioso = listaJogadores.FirstOrDefault(x => x.Simbolo == EstadoVencedor);
                        if (jogadorVitorioso != null)
                        {
                            historicoVitoria.AddVitoria(jogadorVitorioso);
                            ComemoraVitoria(jogadorVitorioso);
                            tabuleiro.ZerarTabuleiro();
                            JogadorAtual = listaJogadores[0];
                        }
                    }
                    else
                    {
                        JogadorAtual = JogadorAtual.Next;
                    }

                    if (tabuleiro.CheckEmpate())
                    {
                        historicoVitoria.AddEmpate();
                        ComemoraEmpate();
                        tabuleiro.ZerarTabuleiro();
                        JogadorAtual = listaJogadores[0];
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível realizar o procedimento\n\n" + ex.Message);
                }
            }
        }

        private void ExibePlacar()
        {
            Console.SetCursorPosition((90 - 10), 0);
            Console.Write("PLACAR");

            for (int i = 0; i < listaJogadores.Count; i++)
            {
                var jog = listaJogadores[i];
                Console.SetCursorPosition((90 - jog.Nome.Length - 6), (i + 2));
                Console.Write(jog.Nome + " - " + historicoVitoria.getNumeroVitorias(jog).ToString().PadLeft(2, '0'));
            }
            Console.SetCursorPosition((90 - 6 - 6), (listaJogadores.Count + 2));
            Console.Write("EMPATE" + " - " + historicoVitoria.getNumeroEmpates().ToString().PadLeft(2, '0'));
        }

        private void ExibeTabuleiro()
        {
            var dictTabuleiro = tabuleiro.GetTabuleiro();

            for (int i = 2; i < 13; i++)
            {
                Console.SetCursorPosition((90 - 75), i);
                Console.Write("|");
                Console.SetCursorPosition((90 - 65), i);
                Console.Write("|");
            }

            for (int i = 2; i < 12; i++)
            {
                Console.SetCursorPosition((90 - 81), 5);
                Console.Write("-----------------------");
                Console.SetCursorPosition((90 - 81), 9);
                Console.Write("-----------------------");
            }

            Console.SetCursorPosition((90 - 81), 2);
            if (dictTabuleiro[0] != EstadoCampo.Vazio)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(dictTabuleiro[0].ToString());
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
                Console.Write("1");

            Console.SetCursorPosition((90 - 81), 6);
            if (dictTabuleiro[3] != EstadoCampo.Vazio)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.Write(dictTabuleiro[3].ToString());
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
                Console.Write("4");
            Console.SetCursorPosition((90 - 81), 10);
            if (dictTabuleiro[6] != EstadoCampo.Vazio)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(dictTabuleiro[6].ToString());
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
                Console.Write("7");
            Console.SetCursorPosition((90 - 74), 2);
            if (dictTabuleiro[1] != EstadoCampo.Vazio)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(dictTabuleiro[1].ToString());
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
                Console.Write("2");
            Console.SetCursorPosition((90 - 74), 6);
            if (dictTabuleiro[4] != EstadoCampo.Vazio)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(dictTabuleiro[4].ToString());
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
                Console.Write("5");
            Console.SetCursorPosition((90 - 74), 10);
            if (dictTabuleiro[7] != EstadoCampo.Vazio)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(dictTabuleiro[7].ToString());
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
                Console.Write("8");
            Console.SetCursorPosition((90 - 64), 2);
            if (dictTabuleiro[2] != EstadoCampo.Vazio)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(dictTabuleiro[2].ToString());
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
                Console.Write("3");
            Console.SetCursorPosition((90 - 64), 6);
            if (dictTabuleiro[5] != EstadoCampo.Vazio)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(dictTabuleiro[5].ToString());
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
                Console.Write("6");
            Console.SetCursorPosition((90 - 64), 10);
            if (dictTabuleiro[8] != EstadoCampo.Vazio)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(dictTabuleiro[8].ToString());
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
                Console.Write("9");

            Console.SetCursorPosition((0), 16);
        }

        private void ComemoraEmpate()
        {
            Console.Clear();
            Console.WriteLine("Uhuuu.......EMPATE");
            Console.ReadKey();
        }

        private void ComemoraVitoria(Jogador jogadorVitorioso)
        {
            Console.Clear();
            Console.WriteLine("Uhuuu.......PARABÉNS " + jogadorVitorioso.Nome);
            Console.ReadKey();
        }

        private void MenuInicial()
        {
            #region banner

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("|/////////////////////////////////////////////////////|");

            Console.Write("|///////////////////////");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("BEM VINDO");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("/////////////////////|");

            Console.Write("|//////////////////////////");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("AO");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("/////////////////////////|");

            Console.Write("|/////////////////////");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("JOGO DA VELHA");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("///////////////////|");

            Console.WriteLine("|/////////////////////////////////////////////////////|");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;

            #endregion banner

            Console.WriteLine("Gostaria de ver as Instruções antes de jogar?(S/N)");
            bool valida = false;
            while (!valida)
            {
                string opcao = Console.ReadLine();

                if (opcao != null)
                {
                    
                    switch (opcao.Trim().ToUpper())
                    {
                        case "S":
                            valida = true;
                            Console.Clear();
                            IniciarTutorial();
                            break;

                        case "N":
                            valida = true;
                            Console.Clear();
                            break;

                        default:
                            Console.WriteLine("Por favor, insira 'S' ou 'N' para a opção desejada");

                            break;
                    }
                }
            }

            //  IniciarTutorial();
        }

        private void IniciarTutorial()
        {
            Console.WriteLine("");
            Console.WriteLine("º Ao Iniciar o Jogo você deverá informar o nome dos participantes;");
            Console.WriteLine("");
            Console.WriteLine("º O primeiro participante é o X e o segundo é o O;");
            Console.WriteLine("");
            Console.WriteLine("º O computador Informa qual participante deve jogar;");
            Console.WriteLine("");
            Console.WriteLine("º Escolha o quadrante a ser jogado pelo número no tabuleiro;");
            Console.ReadKey();

            IniciaJogoFalso();


            Console.Clear();
        }

        private void IncluirUsuarios()
        {
            try
            {
                listaJogadores = new List<Jogador>();
                while (listaJogadores.Count < 2)
                {
                    Jogador novoJogador = new Jogador();

                    Console.WriteLine("Por favor, insira o nome do participante nº " + (listaJogadores.Count + 1) + ":");
                    string nome = Console.ReadLine();

                    if (nome == null || nome.Trim() == "")
                    {
                        Console.WriteLine("Por favor, insira um nome válido!");
                        Console.WriteLine("");
                    }
                    else
                    {
                        novoJogador.Nome = nome;
                        novoJogador.Simbolo = (EstadoCampo)listaJogadores.Count;
                        listaJogadores.Add(novoJogador);
                    }
                }

                if (listaJogadores.Count > 1)
                {
                    Jogador aux = new Jogador();
                    listaJogadores.ForEach(x => { x.Next = aux; aux = x; });
                    JogadorAtual = listaJogadores[0];
                    JogadorAtual.Next = aux;
                }
            }
            catch (Exception ex)

            {
                MessageBox.Show("Não foi possível realizar o procedimento\n\n" + ex.Message);

                listaJogadores = new List<Jogador>();
                Console.Clear();

                IncluirUsuarios();
            }
        }


        private void IniciaJogoFalso()
        {
            IniciaJogadoresFalsos();
            ExibeTabuleiroFalso();
        }

        //private void IniciaJogadoresFalsos()
        //{
        //    listaJogadores = new List<Jogador>();
        //    while (listaJogadores.Count < 2)
        //    {
        //        Jogador novoJogador = new Jogador();

        //        Console.WriteLine("Por favor, insira o nome do participante nº " + (listaJogadores.Count + 1) + ":");
        //        string nome = Console.ReadLine();

        //        if (nome == null || nome.Trim() == "")
        //        {
        //            Console.WriteLine("Por favor, insira um nome válido!");
        //            Console.WriteLine("");
        //        }
        //        else
        //        {
        //            novoJogador.Nome = nome;
        //            novoJogador.Simbolo = (EstadoCampo)listaJogadores.Count;
        //            listaJogadores.Add(novoJogador);
        //        }
        //    }

        //    if (listaJogadores.Count > 1)
        //    {
        //        Jogador aux = new Jogador();
        //        listaJogadores.ForEach(x => { x.Next = aux; aux = x; });
        //        JogadorAtual = listaJogadores[0];
        //        JogadorAtual.Next = aux;
        //    }
        //}


        //private void ExibeTabuleiroFalso()
        //{
        //    var dictTabuleiro = tabuleiro.GetTabuleiro();

        //    for (int i = 2; i < 13; i++)
        //    {
        //        Console.SetCursorPosition((90 - 75), i);
        //        Console.Write("|");
        //        Console.SetCursorPosition((90 - 65), i);
        //        Console.Write("|");
        //    }

        //    for (int i = 2; i < 12; i++)
        //    {
        //        Console.SetCursorPosition((90 - 81), 5);
        //        Console.Write("-----------------------");
        //        Console.SetCursorPosition((90 - 81), 9);
        //        Console.Write("-----------------------");
        //    }

        //    Console.SetCursorPosition((90 - 81), 2);
        //    if (dictTabuleiro[0] != EstadoCampo.Vazio)
        //    {
        //        Console.ForegroundColor = ConsoleColor.Yellow;
        //        Console.Write(dictTabuleiro[0].ToString());
        //        Console.ForegroundColor = ConsoleColor.White;
        //    }
        //    else
        //        Console.Write("1");

        //    Console.SetCursorPosition((90 - 81), 6);
        //    if (dictTabuleiro[3] != EstadoCampo.Vazio)
        //    {
        //        Console.ForegroundColor = ConsoleColor.Yellow;

        //        Console.Write(dictTabuleiro[3].ToString());
        //        Console.ForegroundColor = ConsoleColor.White;
        //    }
        //    else
        //        Console.Write("4");
        //    Console.SetCursorPosition((90 - 81), 10);
        //    if (dictTabuleiro[6] != EstadoCampo.Vazio)
        //    {
        //        Console.ForegroundColor = ConsoleColor.Yellow;
        //        Console.Write(dictTabuleiro[6].ToString());
        //        Console.ForegroundColor = ConsoleColor.White;
        //    }
        //    else
        //        Console.Write("7");
        //    Console.SetCursorPosition((90 - 74), 2);
        //    if (dictTabuleiro[1] != EstadoCampo.Vazio)
        //    {
        //        Console.ForegroundColor = ConsoleColor.Yellow;
        //        Console.Write(dictTabuleiro[1].ToString());
        //        Console.ForegroundColor = ConsoleColor.White;
        //    }
        //    else
        //        Console.Write("2");
        //    Console.SetCursorPosition((90 - 74), 6);
        //    if (dictTabuleiro[4] != EstadoCampo.Vazio)
        //    {
        //        Console.ForegroundColor = ConsoleColor.Yellow;
        //        Console.Write(dictTabuleiro[4].ToString());
        //        Console.ForegroundColor = ConsoleColor.White;
        //    }
        //    else
        //        Console.Write("5");
        //    Console.SetCursorPosition((90 - 74), 10);
        //    if (dictTabuleiro[7] != EstadoCampo.Vazio)
        //    {
        //        Console.ForegroundColor = ConsoleColor.Yellow;
        //        Console.Write(dictTabuleiro[7].ToString());
        //        Console.ForegroundColor = ConsoleColor.White;
        //    }
        //    else
        //        Console.Write("8");
        //    Console.SetCursorPosition((90 - 64), 2);
        //    if (dictTabuleiro[2] != EstadoCampo.Vazio)
        //    {
        //        Console.ForegroundColor = ConsoleColor.Yellow;
        //        Console.Write(dictTabuleiro[2].ToString());
        //        Console.ForegroundColor = ConsoleColor.White;
        //    }
        //    else
        //        Console.Write("3");
        //    Console.SetCursorPosition((90 - 64), 6);
        //    if (dictTabuleiro[5] != EstadoCampo.Vazio)
        //    {
        //        Console.ForegroundColor = ConsoleColor.Yellow;
        //        Console.Write(dictTabuleiro[5].ToString());
        //        Console.ForegroundColor = ConsoleColor.White;
        //    }
        //    else
        //        Console.Write("6");
        //    Console.SetCursorPosition((90 - 64), 10);
        //    if (dictTabuleiro[8] != EstadoCampo.Vazio)
        //    {
        //        Console.ForegroundColor = ConsoleColor.Yellow;
        //        Console.Write(dictTabuleiro[8].ToString());
        //        Console.ForegroundColor = ConsoleColor.White;
        //    }
        //    else
        //        Console.Write("9");

        //    Console.SetCursorPosition((0), 16);
        //}


    }
}
