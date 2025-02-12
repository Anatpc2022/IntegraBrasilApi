using IntegraBrasilApi.Dtos;

namespace IntegraBrasilApi.Interfaces
{
    public interface IAddressService
    {
        Task<ResponseGeneric<AddressResponse>> SearchAddress(string cep);
    }
}