using AutoMapper;
using IntegraBrasilApi.Dtos;
using IntegraBrasilApi.Models;

namespace IntegraBrasilApi.Mappings
{
    public class AddressMapping : Profile
    {
        public AddressMapping()
        {
            CreateMap(typeof(ResponseGeneric<>), typeof(ResponseGeneric<>));
            CreateMap<AddressResponse, AddressModel>();
            CreateMap<AddressModel, AddressResponse>();
        }
    }
}