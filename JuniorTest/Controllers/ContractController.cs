using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JuniorTest.Services.Services;
using JuniorTest.Domain.Models;
using JuniorTest.Services.DTOs;

namespace JuniorTest.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly ContractService contractService;

        public ContractController(ContractService contractService)
        {
            this.contractService = contractService;
        }

        //api/Contract/contracts
        [HttpGet("contracts")]
        public async Task<ActionResult<IEnumerable<Contract>>> GetCars()
        {
            var contracts = await contractService.GetAll();
            if (contracts != null)
                return Ok(contracts);

            return BadRequest(new { message = "Can't find contracts" });
        }

        //api/Contract/contract
        [HttpPost("contract")]
        public async Task<ActionResult<Contract>> PostContract(ContractDto contract)
        {
            var newContract = await contractService.Create(contract);
            if (newContract != null)
                return Created("Contract created successfully", newContract);

            return BadRequest(new { message = "Contract wasn't created" });
        }

    }
}
