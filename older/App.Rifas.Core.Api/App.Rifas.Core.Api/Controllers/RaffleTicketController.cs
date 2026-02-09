using App.Rifas.Core.Bll.RafflePrize;
using App.Rifas.Core.Bll.RaffleTicket;
using App.Rifas.Core.Mapping.InputModel.RafflePrize;
using App.Rifas.Core.Mapping.InputModel.RaffleTicket;
using Microsoft.AspNetCore.Mvc;

namespace App.Rifas.Core.Api.Controllers
{
    [ApiController]
    [Route("raffle-ticket")]
    public class RaffleTicketController: ControllerBase
    {
        IRaffleTicketBll raffleTicketBll;

        public RaffleTicketController(
            IRaffleTicketBll raffleTicketBll
            )
        {
            this.raffleTicketBll = raffleTicketBll;
        }

        [HttpGet]
        public IActionResult GetPaged(
        [FromQuery] RaffleTicketPaginationIM iM
            )
        {
            var result = raffleTicketBll.ListarPaginado(iM);
            return new OkObjectResult(
                result
                );
        }

        [HttpPost]
        public IActionResult Create(
           [FromBody] CreateRaffleTicketIM createRaffleTicketIM)
        {
            var result = raffleTicketBll.CreateRaffleTicket(createRaffleTicketIM);
            return new CreatedResult("", result);
        }

        [HttpGet("{Id}")]
        public IActionResult GetOne(
            int Id
            )
        {
            var result = raffleTicketBll.get(Id);
            return new OkObjectResult(result);

        }
    }
}
