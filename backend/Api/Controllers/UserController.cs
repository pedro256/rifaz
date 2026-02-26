using System.Threading.Tasks;
using Api.DTO.InputModel;
using Api.Entities;
using Api.Exceptions;
using Api.Repositories.User;
using Api.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("user")]
public class UserController : ControllerBase
{
    IUserService userService;
    public UserController(IUserService userService)
    {
        this.userService = userService;
    }

    [HttpGet]
    public String Test()
    {
        return "Test";
    }
    
    [HttpPost]
    public async Task<ActionResult> Index(
        [FromBody]UserCreateRequest userCreateRequest)
    {
        await userService.Cadastrar(userCreateRequest);
        return Ok("ww");
    }
}