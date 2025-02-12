// Importa a biblioteca para manipulação de códigos de status HTTP
using System.Net;

// Importa a interface do serviço de endereço
using IntegraBrasilApi.Interfaces;

// Importa os componentes necessários para criar um controlador no ASP.NET Core
using Microsoft.AspNetCore.Mvc;

namespace IntegraBrasilApi.Controllers
{
    // Define que esta classe é um controlador de API
    [ApiController]

    // Define a rota base do controlador como "api/v1/address"
    [Route("api/v1/[controller]")]
    public class AddressController : ControllerBase
    {
        // Declara uma dependência do serviço de endereço
        private readonly IAddressService _addressService;

        // Construtor que recebe uma implementação de IAddressService via injeção de dependência
        public AddressController(IAddressService addressService)
        {
            _addressService = addressService; // Inicializa o serviço de endereço
        }

        // Define um endpoint GET para buscar um endereço pelo CEP
        [HttpGet("search/{cep}")]

        // Define os possíveis códigos de resposta HTTP retornados pelo endpoint
        [ProducesResponseType(StatusCodes.Status200OK)] // Resposta bem-sucedida
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // Requisição inválida
        [ProducesResponseType(StatusCodes.Status404NotFound)] // Recurso não encontrado
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] // Erro interno do servidor
        public async Task<IActionResult> GetAddress([FromRoute] string cep)
        {
            // Chama o serviço de endereço para buscar o CEP informado
            var response = await _addressService.SearchAddress(cep);

            // Verifica se a requisição foi bem-sucedida (código HTTP 200 OK)
            if (response.HttpCode == HttpStatusCode.OK)
            {
                // Retorna os dados encontrados com código 200 OK
                return Ok(response.DataReturn);
            }
            else
            {
                // Retorna o erro com o código HTTP correspondente
                return StatusCode((int)response.HttpCode, response.ErrorReturn);
            }
        }
    }
}
