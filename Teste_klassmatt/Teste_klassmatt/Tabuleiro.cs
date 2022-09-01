using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_klassmatt
{
    public class Tabuleiro
    {
        private Dictionary<int, EstadoCampo> casas { get; set; }

        public Tabuleiro()
        {
            ZerarTabuleiro();
        }

        public void ZerarTabuleiro()
        {
            Dictionary<int, EstadoCampo> temp = new Dictionary<int, EstadoCampo>();
            for (int i = 0; i < 9; i++)
            {
                temp.Add(i, EstadoCampo.Vazio);
            }
            casas = temp;
        }

        public bool AddJogada(Jogador jogador, int posicao)
        {
            if (casas.ContainsKey(posicao) && casas[posicao] == EstadoCampo.Vazio)
            {
                casas[posicao] = jogador.Simbolo;
                return true;
            }
            else
                return false;
        }

        public Dictionary<int, EstadoCampo> GetTabuleiro()
        {
            return casas;
        }

        public EstadoCampo CheckCondicaoVitoria()
        {
            return (CheckCondicaoTransversao() != EstadoCampo.Vazio) ? CheckCondicaoTransversao() : (CheckCondicaoVertical() != EstadoCampo.Vazio) ? CheckCondicaoVertical() : (CheckCondicaoHorizontal() != EstadoCampo.Vazio) ? CheckCondicaoHorizontal() : EstadoCampo.Vazio;
        }

        public bool CheckEmpate()
        {
            return !casas.ContainsValue(EstadoCampo.Vazio);
        }

        private EstadoCampo CheckCondicaoTransversao()
        {
            try
            {
                if (casas[4] != EstadoCampo.Vazio && casas[0] == casas[4] && casas[4] == casas[8])
                    return casas[4];
                if (casas[4] != EstadoCampo.Vazio && casas[2] == casas[4] && casas[4] == casas[6])
                    return casas[4];

                return EstadoCampo.Vazio;
            }
            catch (Exception) { return EstadoCampo.Vazio; }
        }

        private EstadoCampo CheckCondicaoVertical()
        {
            try
            {
                if (casas[0] != EstadoCampo.Vazio && casas[0] == casas[3] && casas[3] == casas[6])
                    return casas[0];
                if (casas[1] != EstadoCampo.Vazio && casas[1] == casas[4] && casas[4] == casas[7])
                    return casas[1];
                if (casas[2] != EstadoCampo.Vazio && casas[2] == casas[5] && casas[5] == casas[8])
                    return casas[2];
                else
                    return EstadoCampo.Vazio;
            }
            catch (Exception) { return EstadoCampo.Vazio; }
        }

        private EstadoCampo CheckCondicaoHorizontal()
        {
            try
            {
                if (casas[0] != EstadoCampo.Vazio && casas[0] == casas[1] && casas[1] == casas[2])
                    return casas[0];
                if (casas[3] != EstadoCampo.Vazio && casas[3] == casas[4] && casas[4] == casas[5])
                    return casas[3];
                if (casas[6] != EstadoCampo.Vazio && casas[6] == casas[7] && casas[7] == casas[8])
                    return casas[6];
                else
                    return EstadoCampo.Vazio;
            }
            catch (Exception) { return EstadoCampo.Vazio; }
        }
    }
}
