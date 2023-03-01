using App.Rifas.Core.Api.Token;
using App.Rifas.Core.Bll.User;
using App.Rifas.Core.Mapping.Exceptions;
using App.Rifas.Core.Mapping.InputModel.Auth;
using App.Rifas.Core.Mapping.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace App.Rifas.Core.Api.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        ITokenGenerator tokenGenerator;
        IUserBll userBll;

        public AuthController(
            ITokenGenerator tokenGenerator,
            IUserBll userBll
            )
        {
            this.tokenGenerator = tokenGenerator;
            this.userBll = userBll;
        }

        [HttpPost]
        public AuthVM Auth([FromBody]AuthIM authIM)
        {
            bool userValid = userBll.validUserAuthentication(authIM);
            if (!userValid)
            {
                throw new ForbiddenException("Auth forbidden .");
            }
            string token = tokenGenerator.GenerateToken(authIM);

            return new AuthVM
            {
                Token = token
            };
        }
    }
}
