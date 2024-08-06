using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console
{
    public class LeitorDeArquivo
    {
        public List<Pet> RealizaLeitura(string caminhoDoArquivo)
        {
            var listaDePet = new List<Pet>();

            // args[1] é o caminho do arquivo a ser exibido
            using (var sr = new StreamReader(caminhoDoArquivo))
            {
                System.Console.WriteLine("----- Serão importados os dados abaixo -----");

                while (!sr.EndOfStream)
                {
                    // separa linha usando ponto e vírgula
                    string[] propriedades = sr.ReadLine().Split(';');

                    // cria objeto Pet a partir da separação
                    var pet = new Pet(Guid.Parse(propriedades[0]),
                                      propriedades[1],
                                      int.Parse(propriedades[2]) == 1 ? TipoPet.Gato : TipoPet.Cachorro);

                    listaDePet.Add(pet);
                }
            }

            return listaDePet;
        }
    }
}
