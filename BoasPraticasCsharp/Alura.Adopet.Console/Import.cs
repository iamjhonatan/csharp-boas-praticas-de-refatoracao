using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Alura.Adopet.Console
{
    public class Import
    {
        HttpClient client;

        public Import()
        {
            client = ConfiguraHttpClient("http://localhost:5057");
        }

        public async Task ImportacaoArquivoPetAsync(string caminhoDoArquivoDeImportacao)
        {
            var leitor = new LeitorDeArquivo();
            var listaDePet = leitor.RealizaLeitura(caminhoDoArquivoDeImportacao);

            foreach (var pet in listaDePet)
            {
                System.Console.WriteLine(pet);

                try
                {
                    var resposta = await CreatePetAsync(pet);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }

            System.Console.WriteLine("Importação concluída!");
        }

        private Task<HttpResponseMessage> CreatePetAsync(Pet pet)
        {
            HttpResponseMessage? response = null;
            using (response = new HttpResponseMessage())
            {
                return client.PostAsJsonAsync("pet/add", pet);
            }
        }

        private HttpClient ConfiguraHttpClient(string url)
        {
            var _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.BaseAddress = new Uri(url);

            return _client;
        }
    }
}
