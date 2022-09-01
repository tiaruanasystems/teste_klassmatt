using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_klassmatt
{
    public class Jogador
    {
        public string Nome { get; set; }
        public EstadoCampo Simbolo { get; set; }
        public Jogador Next { get; set; }

        public Jogador()
        {
        }
    }
}
