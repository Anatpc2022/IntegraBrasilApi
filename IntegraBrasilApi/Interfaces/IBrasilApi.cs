using IntegraBrasilApi.Dtos;
using IntegraBrasilApi.Models;

namespace IntegraBrasilApi.Interfaces
{
    public interface IBrasilApi
    {
        Task<ResponseGeneric<AddressModel>> SearchAddressByZipCode(string cep);
        Task<ResponseGeneric<List<BankModel>>> SearchAllBanks();
        Task<ResponseGeneric<BankModel>> SearchBank(string bankCode);
    }
}