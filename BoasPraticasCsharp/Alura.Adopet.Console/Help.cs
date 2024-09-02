using System.Reflection;

namespace Alura.Adopet.Console
{
    [DocComand(instrucao: "help", documentacao: "adopet help comando que exibe informações de ajuda.")]
    internal class Help
    {
        private Dictionary<string, DocComand> docs;

        public Help()
        {
            docs = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.GetCustomAttributes<DocComand>().Any())
                .Select(t => t.GetCustomAttribute<DocComand>()!)
                .ToDictionary(d => d.Instrucao);
        }

        public void ExibeDocumentacao(string[] parametros)
        {
            // se não passou um argumento mostra help de todos os comandos
            if (parametros.Length == 1)
            {
                System.Console.WriteLine($"Adopet (1.0)- Aplicativo de linha de comando (CLI).");
                System.Console.WriteLine("Realiza a importação em lote de um arquivo de pets.");
                System.Console.WriteLine("Comandos possíveis: ");
                System.Console.WriteLine($" adopet help comando que exibe informações de ajuda.");
                System.Console.WriteLine($" adopet help <NOME_COMANDO>  para acessar a ajuda de um .");
                System.Console.WriteLine($" adopet import <ARQUIVO> comando que realiza a importação.");
                System.Console.WriteLine($" adopet show <ARQUIVO> comando que exibe no terminal o conteúdo.");
                System.Console.WriteLine($" adopet list comando que exibe a lista de pets.");
            }
            // exibe o help daquele comando específico
            else if (parametros.Length == 2)
            {
                string comandoASerExibido = parametros[1];

                if (comandoASerExibido.Equals("import"))
                {
                    System.Console.WriteLine(" adopet import <arquivo> " +
                        "comando que realiza a importação do arquivo de pets.");
                }
                else if (comandoASerExibido.Equals("show"))
                {
                    System.Console.WriteLine($" adopet show <arquivo>  comando que " +
                        "exibe no terminal o conteúdo do arquivo importado.");
                }
                else if (comandoASerExibido.Equals("list"))
                {
                    System.Console.WriteLine($" adopet list comando que " +
                        "exibe no terminal a lista de pets importados do sistema.");
                }
            }
        }
    }
}
