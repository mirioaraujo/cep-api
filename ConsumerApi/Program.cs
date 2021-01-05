using Refit;
using System;
using System.Threading.Tasks;

namespace ConsumerApi
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try 
            {
                var cepClient = RestService.For<ICepService>("http://viacep.com.br");
                Console.WriteLine("Informe o cep desejado para consulta:");

                string CepInformado = Console.ReadLine().ToString();
                Console.WriteLine("Cep digitado:" + CepInformado);

                var address = await cepClient.GetAddressAsync(CepInformado);
                Console.Write($"\nLogradouro:{address.Logradouro},\nBairro:{address.Bairro},\nCidade:{address.Localidade},\nDDD:{address.Ddd},\nIBGE:{address.Ibge}");
                Console.ReadKey();
        }
            catch (Exception e)
            {
                Console.WriteLine("Opa, Algo deu errado na consulta do CEP:" + e.Message);
            }
        }
    }
}
