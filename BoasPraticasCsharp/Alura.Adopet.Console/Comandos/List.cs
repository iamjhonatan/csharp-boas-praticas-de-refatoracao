using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos;

namespace Alura.Adopet.Console.Comandos
{
    [DocComand(instrucao: "list", documentacao: "adopet list comando que exibe no terminal a lista de pets importados do sistema.")]
    internal class List : IComando
    {
        public async Task ExecutarAsync(string[] args)
        {
            await ListaDadosPetsDaAPIAsync();
        }

        private async Task ListaDadosPetsDaAPIAsync()
        {
            var httpListPet = new HttpClientPet();
            IEnumerable<Pet> pets = await httpListPet.ListPetsAsync();
            System.Console.WriteLine("----- Lista de Pets importados do sistema ----");

            foreach (var pet in pets)
            {
                System.Console.WriteLine(pet);
            }
        }
    }
}
