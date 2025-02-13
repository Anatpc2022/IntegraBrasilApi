using AutoMapper;
using IntegraBrasilApi.Dtos;
using IntegraBrasilApi.Interfaces;

namespace IntegraBrasilApi.Services
{
    public class BankService : IBankService
    {
        private readonly IMapper _mapper;
        private readonly IBrasilApi _brasilApi;

        public BankService(IMapper mapper, IBrasilApi brasilApi)
        {
            _mapper = mapper;
            _brasilApi = brasilApi;
        }

        public async Task<ResponseGeneric<List<BankResponse>>> SearchAll()
        {
            var banks = await _brasilApi.SearchAllBanks();
            return _mapper.Map<ResponseGeneric<List<BankResponse>>>(banks);
        }

        public async Task<ResponseGeneric<BankResponse>> SearchBank(string codeBank)
        {
            var bank = await _brasilApi.SearchBank(codeBank);
            return _mapper.Map<ResponseGeneric<BankResponse>>(bank);
        }
    }
}