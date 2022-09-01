using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_klassmatt
{
    public static class Mensagens
    {
        public static string CasaOcupada()
        {
            return "Esta casa já está ocupada.\nPor favor tente novamente.";
        }

        public static string CasaForaTabuleiro()
        {
            return "O tabuleiro só possui as casas de 1 ao 9\nPor favor tente novamente";
        }

        public static string ExcessoErro()
        {
            return "Notei que Você está tendo bantante problema.\nGostaria de visitar o tutorial?";
        }
    }
}
