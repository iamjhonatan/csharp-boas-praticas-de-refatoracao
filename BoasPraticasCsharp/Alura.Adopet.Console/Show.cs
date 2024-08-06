using System;

namespace Alura.Adopet.Console
{
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
