using App.Rifas.Core.Bll.User;
using App.Rifas.Core.Mapping.Exceptions;
using App.Rifas.Core.Mapping.Filters;
using App.Rifas.Core.Mapping.InputModel;
using App.Rifas.Core.Mapping.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace App.Rifas.Core.Api.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        IUserBll userBll;

        public UserController(IUserBll _userBll)
        {
            userBll = _userBll;
        }

        [HttpGet]
        public IActionResult GetPaged(
            [FromQuery] UserPaginationIM iM
            )
        {
            var result = userBll.ListarPaginado(iM);
            return new  OkObjectResult(
                result
                );
        }

        [HttpPost]
        public IActionResult New(
            [FromBody] UserIM user
            )
        {
            try
            {
                var result = userBll.createUser(user);
                return new CreatedResult("", result);
            }
            catch(BadRequestException e)
            {
                return new BadRequestObjectResult(e.Message);
            }
            
        }

        [HttpGet("{Id}")]
        public IActionResult GetOne(
            int Id
            )
        {
            try
            {
                var result = userBll.getUser(Id);
                return new OkObjectResult(result);
             }
            catch(NotFoundException e)
            {
                return new NotFoundObjectResult(e.Message);
            }
            
        }
        [HttpDelete("{Id}")]
        public IActionResult Delete(
            int Id)
        {
            try
            {
                var result = userBll.deleteUser(Id);
                return new NoContentResult();
            }
            catch (NotFoundException e)
            {
                return new NotFoundObjectResult(e.Message);
            }
        }
    }
}
