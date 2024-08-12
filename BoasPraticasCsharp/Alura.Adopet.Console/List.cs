using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console
{
    [DocComand(instrucao: "list", documentacao: "adopet list comando que exibe no terminal a lista de pets importados do sistema.")]
    internal class List
    {
        public async Task ListaDadosPetsDaAPIAsync()
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
