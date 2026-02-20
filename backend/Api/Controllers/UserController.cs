using Api.DTO.InputModel;
using Api.Entities;
using Api.Exceptions;
using Api.Repositories.User;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("user")]
public class UserController : ControllerBase
{
    IUserRepository userRepository;
    public UserController(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
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

        if (this.userRepository.ExistsEmail(userCreateRequest.Email))
        {
            throw new NotFoundException("Email já existe");
        }
        UserEntity user = new UserEntity();
        user.Name = userCreateRequest.FullName;
        user.Email = userCreateRequest.Email;
        user.CreatedAt = DateTime.UtcNow;
        user.KcId = Guid.NewGuid();
        user = this.userRepository.Create(user);

        return Created();
    }
}