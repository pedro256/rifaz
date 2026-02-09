using App.Rifas.Core.Bll.RafflePrize;
using App.Rifas.Core.Bll.User;
using App.Rifas.Core.Mapping.InputModel.Raffle;
using App.Rifas.Core.Mapping.InputModel.RafflePrize;
using App.Rifas.Core.Mapping.InputModel.User;
using Microsoft.AspNetCore.Mvc;

namespace App.Rifas.Core.Api.Controllers
{
    [ApiController]
    [Route("raffle-prize")]
    public class RafflePrizeController : ControllerBase
    {
        IRafflePrizeBll rafflePrizeBll;

        public RafflePrizeController(
            IRafflePrizeBll rafflePrizeBll
            )
        {
            this.rafflePrizeBll = rafflePrizeBll;
        }

        [HttpGet]
        public IActionResult GetPaged(
        [FromQuery] RafflePrizePaginationIM iM
            )
        {
            var result = rafflePrizeBll.ListarPaginado(iM);
            return new OkObjectResult(
                result
                );
        }

        [HttpPost]
        public IActionResult Create(
            [FromBody] CreateRafflePrizeIM createRafflePrizeIM)
        {
            var result = rafflePrizeBll.CreateRafflePrize(createRafflePrizeIM);
            return new CreatedResult("", result);
        }

        [HttpGet("{Id}")]
        public IActionResult GetOne(
            int Id
            )
        {
            var result = rafflePrizeBll.get(Id);
            return new OkObjectResult(result);

        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(
            int Id)
        {
            var result = rafflePrizeBll.delete(Id);
            return new NoContentResult();
        }
    }
}
