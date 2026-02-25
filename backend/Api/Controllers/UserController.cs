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
    public ActionResult Index(
        [FromBody]UserCreateRequest userCreateRequest)
    {
        this.userService.Cadastrar(userCreateRequest);
        return Created();
    }
}