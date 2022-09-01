using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_klassmatt.Dominio
{
    public class JogoDaVelha
    {
           
        public bool fimDeJogo  { get; set; }
        public char[] posicoes { get; set; }
        public char vez { get; set; }
        public int quantidadePreenchida { get; set; }

        public JogoDaVelha()
        {
            fimDeJogo = false;
            posicoes = new[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            vez = 'X';
            quantidadePreenchida = 0;
        }



    }
}
