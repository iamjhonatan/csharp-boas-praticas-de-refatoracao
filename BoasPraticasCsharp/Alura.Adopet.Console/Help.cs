using System.Reflection;

namespace Alura.Adopet.Console
{
    [DocComand(instrucao: "help", documentacao: "adopet help comando que exibe informações de ajuda. \n" +
        "adopet help <NOME_COMANDO> para acessar a ajuda de um comando específico.")]

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

                foreach (var doc in docs.Values)
                    System.Console.WriteLine($" {doc.Instrucao} - {doc.Documentacao}");
            }
            // exibe o help daquele comando específico
            else if (parametros.Length == 2)
            {
                string comandoASerExibido = parametros[1];

                if (!docs.ContainsKey(comandoASerExibido))
                {
                    System.Console.WriteLine($"Comando '{comandoASerExibido}' não encontrado.");
                    return;
                }

                var comando = docs[comandoASerExibido];

                System.Console.WriteLine($" {comando.Instrucao} - {comando.Documentacao}");
            }
        }
    }
}
