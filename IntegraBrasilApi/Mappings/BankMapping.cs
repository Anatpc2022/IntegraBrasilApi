using AutoMapper;
using IntegraBrasilApi.Dtos;
using IntegraBrasilApi.Models;

namespace IntegraBrasilApi.Mappings
{
    public class BankMapping : Profile
    {
        public BankMapping()
        {
            // Cria um mapeamento genérico entre objetos do tipo ResponseGeneric<T> para ResponseGeneric<T>
            CreateMap(typeof(ResponseGeneric<>), typeof(ResponseGeneric<>));

            // Cria um mapeamento de BankResponse para BankModel
            CreateMap<BankResponse, BankModel>();

            // Cria um mapeamento de BankModel para BankResponse (mapeamento reverso)
            CreateMap<BankModel, BankResponse>();
        }
    }
}