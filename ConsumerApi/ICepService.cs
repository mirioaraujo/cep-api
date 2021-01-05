using Refit;
using System.Threading.Tasks;

namespace ConsumerApi
{
    public interface ICepService
    {
        [Get("/ws/{cep}/json")]
        Task<CepResponse> GetAddressAsync(string cep);
    }
}
