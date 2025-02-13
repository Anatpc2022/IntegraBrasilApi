using System.ComponentModel.DataAnnotations;
using System.Net;
using IntegraBrasilApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IntegraBrasilApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BankController : ControllerBase
    {
        public readonly IBankService _bankService;

        public BankController(IBankService bankService)
        {
            _bankService = bankService;
        }

        [HttpGet("search/all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> GetAll()
        {
            var response = await _bankService.SearchAll();

            if (response.HttpCode == HttpStatusCode.OK)
            {
                return Ok(response.DataReturn);
            }
            else
            {
                return StatusCode((int)response.HttpCode, response.ErrorReturn);
            }
        }

        [HttpGet("search/{codeBank}")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetBank([RegularExpression("[0-9]*$")] string codeBank)
        {
            var response = await _bankService.SearchBank(codeBank);

            if (response.HttpCode == HttpStatusCode.OK)
            {
                return Ok(response.DataReturn);
            }
            else
            {
                return StatusCode((int)response.HttpCode, response.ErrorReturn);
            }
        }

    }
}