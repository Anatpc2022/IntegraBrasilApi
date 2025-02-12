// Importa a biblioteca AutoMapper, que permite o mapeamento entre objetos
using AutoMapper;

// Importa os DTOs (Data Transfer Objects) utilizados na aplicação
using IntegraBrasilApi.Dtos;

// Importa as interfaces necessárias para a implementação do serviço
using IntegraBrasilApi.Interfaces;

namespace IntegraBrasilApi.Services
{
    // Implementa a interface IAddressService
    public class AddressService : IAddressService
    {
        // Declara um objeto para o AutoMapper
        private readonly IMapper _mapper;

        // Declara uma dependência da API externa que fornece informações de endereço
        private readonly IBrasilApi _brasilApi;

        // Construtor que recebe as dependências via injeção de dependência
        public AddressService(IMapper mapper, IBrasilApi brasilApi)
        {
            _mapper = mapper; // Inicializa o AutoMapper
            _brasilApi = brasilApi; // Inicializa a API externa
        }

        // Método assíncrono que busca um endereço pelo CEP
        public async Task<ResponseGeneric<AddressResponse>> SearchAddress(string cep)
        {
            // Chama a API externa para obter os dados do endereço
            var address = await _brasilApi.SearchAddressByZipCode(cep);

            // Usa o AutoMapper para converter os dados recebidos no formato esperado e retorna a resposta
            return _mapper.Map<ResponseGeneric<AddressResponse>>(address);
        }
    }
}
