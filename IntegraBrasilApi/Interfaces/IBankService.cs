using IntegraBrasilApi.Dtos;
using IntegraBrasilApi.Models;

namespace IntegraBrasilApi.Interfaces
{
    public interface IBankService
    {
        Task<ResponseGeneric<List<BankResponse>>> SearchAll();
        Task<ResponseGeneric<BankResponse>> SearchBank(string codeBank);
    }
}