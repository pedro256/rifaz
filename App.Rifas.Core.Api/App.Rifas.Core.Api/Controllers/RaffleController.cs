using App.Rifas.Core.Bll.Raffle;
using App.Rifas.Core.Mapping.Exceptions;
using App.Rifas.Core.Mapping.InputModel.Raffle;
using Microsoft.AspNetCore.Mvc;

namespace App.Rifas.Core.Api.Controllers
{
    [ApiController]
    [Route("raffle")]
    public class RaffleController
    {
        IRaffleBll raffleBll;

        public RaffleController(IRaffleBll raffleBll)
        {
            this.raffleBll = raffleBll;
        }
        [HttpGet]
        public IActionResult GetPaged(
            [FromQuery] RafflePaginationIM filter
            )
        {
            var result = raffleBll.ListarPaginado(filter);
            return new OkObjectResult(result);
        }
        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            var result = raffleBll.get(Id);
            return new OkObjectResult(result);
        }

        [HttpPost]
        public IActionResult Create(CreateRaffleIM createRaffle)
        {
            var r = raffleBll.create(createRaffle);
            return new CreatedResult("/raffle/" + r.Id, r);

        }
    }
}
