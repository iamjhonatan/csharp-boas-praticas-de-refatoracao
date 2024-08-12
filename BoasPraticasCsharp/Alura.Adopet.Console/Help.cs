using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console
{
    [DocComand(instrucao: "help", documentacao: "adopet help comando que exibe informações de ajuda.")]
    internal class Help
    {
        public void ExibeDocumentacao(string[] parametros)
        {
            if (parametros.Length == 1)
            {

            }
            else if (parametros.Length == 2)
            {
            }
        }
    }
}
