using AutoMapper;
using IntegraBrasilApi.Dtos;
using IntegraBrasilApi.Interfaces;

namespace IntegraBrasilApi.Services
{
    public class AddressService : IAddressService
    {
        private readonly IMapper _mapper;
        private readonly IBrasilApi _brasilApi;

        public AddressService(IMapper mapper, IBrasilApi brasilApi)
        {
            _mapper = mapper;
            _brasilApi = brasilApi;
        }

        public async Task<ResponseGeneric<AddressResponse>> SearchAddress(string cep)
        {
            var address = await _brasilApi.SearchAddressByZipCode(cep);
            return _mapper.Map<ResponseGeneric<AddressResponse>>(address);
        }
    }
}