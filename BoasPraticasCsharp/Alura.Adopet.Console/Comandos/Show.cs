using Alura.Adopet.Console.Util;

namespace Alura.Adopet.Console.Comandos
{
    [DocComand(instrucao: "show",
               documentacao: "adopet show <arquivo> comando que exibe no terminal o conteúdo do arquivo importado.")]
    internal class Show : IComando
    {
        public Task ExecutarAsync(string[] args)
        {
            ExibeConteudoArquivo(args[1]);
            return Task.CompletedTask;
        }

        private void ExibeConteudoArquivo(string caminhoDoArquivo)
        {
            var leitor = new LeitorDeArquivo();
            var listaDePet = leitor.RealizaLeitura(caminhoDoArquivo);

            foreach (var pet in listaDePet)
                System.Console.WriteLine(pet);
        }
    }
}
