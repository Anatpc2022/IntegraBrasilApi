// Importa o namespace necessário para usar objetos dinâmicos
using System.Dynamic;

// Importa a biblioteca para manipulação de JSON
using System.Text.Json;

// Importa os DTOs (Data Transfer Objects) usados na aplicação
using IntegraBrasilApi.Dtos;

// Importa a interface que define os métodos implementados por esta classe
using IntegraBrasilApi.Interfaces;

// Importa os modelos de dados usados na aplicação
using IntegraBrasilApi.Models;

// Define o namespace onde a classe está localizada
namespace IntegraBrasilApi.Rest
{
    // Implementa a interface IBrasilApi, que define os métodos para buscar informações na API
    public class BrasilApiRest : IBrasilApi
    {
        // Declara um cliente HTTP para fazer requisições a serviços externos
        private readonly HttpClient _client;

        // Construtor da classe, recebe um HttpClient via injeção de dependência
        public BrasilApiRest(HttpClient client)
        {
            _client = client; // Inicializa o cliente HTTP
        }

        // Método assíncrono que busca um endereço pelo CEP na API externa
        public async Task<ResponseGeneric<AddressModel>> SearchAddressByZipCode(string cep)
        {
            // Cria a requisição HTTP do tipo GET com a URL da API de CEP
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://brasilapi.com.br/api/cep/v1/{cep}");

            // Cria um objeto do tipo ResponseGeneric<AddressModel> para armazenar a resposta
            var response = new ResponseGeneric<AddressModel>();

            // Envia a requisição para a API externa e aguarda a resposta
            var responseBrasilApi = await _client.SendAsync(request);

            // Lê o conteúdo da resposta como uma string
            var contentResp = await responseBrasilApi.Content.ReadAsStringAsync();

            // Desserializa a string JSON recebida para um objeto do tipo AddressModel
            var objResponse = JsonSerializer.Deserialize<AddressModel>(contentResp);

            // Verifica se a requisição foi bem-sucedida (código HTTP 2xx)
            if (responseBrasilApi.IsSuccessStatusCode)
            {
                // Armazena o código de status HTTP na resposta genérica
                response.HttpCode = responseBrasilApi.StatusCode;

                // Armazena o objeto desserializado na resposta
                response.DataReturn = objResponse;
            }
            else
            {
                // Se houve erro, armazena o código de status HTTP
                response.HttpCode = responseBrasilApi.StatusCode;

                // Desserializa a resposta de erro para um objeto dinâmico (ExpandoObject)
                response.ErrorReturn = JsonSerializer.Deserialize<ExpandoObject>(contentResp);
            }

            // Retorna o objeto de resposta genérica contendo os dados ou o erro
            return response;
        }

        // Método que deveria buscar todos os bancos, mas ainda não foi implementado
        public Task<ResponseGeneric<List<BankModel>>> SearchAllBanks()
        {
            throw new NotImplementedException();
        }

        // Método que deveria buscar um banco específico pelo código, mas ainda não foi implementado
        public Task<ResponseGeneric<BankModel>> SearchBank(string bankCode)
        {
            throw new NotImplementedException();
        }
    }
}
