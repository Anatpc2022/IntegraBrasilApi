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
    // Implementa a interface IBrasilApi
    public class BrasilApiRest : IBrasilApi
    {
        private readonly HttpClient _client;

        public BrasilApiRest(HttpClient client)
        {
            _client = client;
        }

        public async Task<ResponseGeneric<AddressModel>> SearchAddressByZipCode(string cep)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://brasilapi.com.br/api/cep/v1/{cep}");
            var response = new ResponseGeneric<AddressModel>();

            var responseBrasilApi = await _client.SendAsync(request);
            var contentResp = await responseBrasilApi.Content.ReadAsStringAsync();
            var objResponse = JsonSerializer.Deserialize<AddressModel>(contentResp);

            if (responseBrasilApi.IsSuccessStatusCode)
            {
                response.HttpCode = responseBrasilApi.StatusCode;
                response.DataReturn = objResponse;
            }
            else
            {
                response.HttpCode = responseBrasilApi.StatusCode;
                response.ErrorReturn = JsonSerializer.Deserialize<ExpandoObject>(contentResp);
            }

            return response;
        }

        public Task<ResponseGeneric<List<BankModel>>> SearchAllBanks()
        {
            throw new NotImplementedException();
        }
        public Task<ResponseGeneric<BankModel>> SearchBank(string bankCode)
        {
            throw new NotImplementedException();
        }
    }
}
