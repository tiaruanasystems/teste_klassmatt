using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_klassmatt.Ferramentas
{
    public static class Util
    {
        /// <summary>
        /// Transforma uma String em um Inteiro
        /// </summary>
        /// <returns></returns>
        public static int GetInteiro(this string texto)
        {
            if (texto.IndexOf(',') >= 0)
            {
                var spl = texto.Split(',');
                texto = spl[0];
            }

            if (texto.IndexOf('.') >= 0)
            {
                texto = texto.Replace(".", "");
            }

            int inteiro = 0;
            int.TryParse(texto, out inteiro);

            return inteiro;
        }
    }
}
