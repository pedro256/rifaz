using App.Rifas.Core.Bll.RaffleCategory;
using App.Rifas.Core.Bll.User;
using App.Rifas.Core.Mapping.Exceptions;
using App.Rifas.Core.Mapping.InputModel;
using App.Rifas.Core.Mapping.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace App.Rifas.Core.Api.Controllers
{
    [ApiController]
    [Route("raffle-category")]
    public class RaffleCategoryController
    {
        IRaffleCategoryBll raffleCategoryBll;
        public RaffleCategoryController(
            IRaffleCategoryBll rafCatBll
            )
        {
            raffleCategoryBll = rafCatBll;
        }

        [HttpGet]
        public IActionResult GetPaged(
        [FromQuery] RaffleCategoryPaginationQueryVM query
           )
        {
            var result = raffleCategoryBll.ListarPaginado(query);
            return new OkObjectResult(
                result
                );
        }

        [HttpPost]
        public IActionResult Create(
        [FromBody] RaffleCategoryVM vm
           )
        {
            var result = raffleCategoryBll.create(vm);
            return new CreatedResult("",result);
        }

        [HttpPut("{Id}")]
        public IActionResult Update(
        [FromBody] RaffleCategoryVM vm,
        int Id
           )
        {
            vm.Id = Id;
            var result = raffleCategoryBll.update(vm);
            return new NoContentResult();
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(
            int Id)
        {
            var result = raffleCategoryBll.delete(Id);
            return new NoContentResult();
        }
    }
}
