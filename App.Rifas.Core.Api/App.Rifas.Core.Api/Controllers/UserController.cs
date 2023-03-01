using App.Rifas.Core.Bll.User;
using App.Rifas.Core.Mapping.Exceptions;
using App.Rifas.Core.Mapping.Filters;
using App.Rifas.Core.Mapping.InputModel.User;
using App.Rifas.Core.Mapping.ViewModel;
using Microsoft.AspNetCore.Authorization;
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
            var result = userBll.createUser(user);
            return new CreatedResult("", result);
            
        }

        [HttpGet("{Id}")]
        [Authorize]
        public IActionResult GetOne(
            int Id
            )
        {
            var result = userBll.getUser(Id);
            /*
            if(result.Email != User.Identity.Name)
            {
                throw new ForbiddenException("User is not valid !");
            }
            */
            return new OkObjectResult(result);

        }
        [HttpDelete("{Id}")]
        public IActionResult Delete(
            int Id)
        {
            var result = userBll.deleteUser(Id);
            return new NoContentResult();
        }
    }
}
