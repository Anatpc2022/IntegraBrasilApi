// Importa a biblioteca AutoMapper, que é usada para mapear objetos entre diferentes tipos
using AutoMapper;

// Importa os namespaces que contêm as classes DTOs (Data Transfer Objects) usadas na conversão
using IntegraBrasilApi.Dtos;

// Importa os modelos da aplicação, que representam as entidades do banco de dados ou do domínio
using IntegraBrasilApi.Models;

namespace IntegraBrasilApi.Mappings
{
    // Define a classe AddressMapping, que herda de Profile, uma classe do AutoMapper usada para configurar mapeamentos
    public class AddressMapping : Profile
    {
        // Construtor da classe AddressMapping, onde os mapeamentos são configurados
        public AddressMapping()
        {
            // Cria um mapeamento genérico entre objetos do tipo ResponseGeneric<T> para ResponseGeneric<T>
            CreateMap(typeof(ResponseGeneric<>), typeof(ResponseGeneric<>));

            // Cria um mapeamento de AddressResponse para AddressModel
            CreateMap<AddressResponse, AddressModel>();

            // Cria um mapeamento de AddressModel para AddressResponse (mapeamento reverso)
            CreateMap<AddressModel, AddressResponse>();
        }
    }
}
