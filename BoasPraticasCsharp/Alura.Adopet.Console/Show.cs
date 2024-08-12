using System;

namespace Alura.Adopet.Console
{
    [DocComand(instrucao:"show", 
               documentacao: "adopet show <arquivo> comando que exibe no terminal o conteúdo do arquivo importado.")]
    internal class Show
    {
        public void ExibeConteudoArquivo(string caminhoDoArquivo)
        {
            var leitor = new LeitorDeArquivo();
            var listaDePet = leitor.RealizaLeitura(caminhoDoArquivo);

            foreach (var pet in listaDePet)
                System.Console.WriteLine(pet);
        }
    }
}
