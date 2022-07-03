using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using teacher_api.Application.Account.Commands.OrganizationAccountRegister;
using teacher_api.Application.Account.Commands.PersonalAccountRegister;
using teacher_api.Application.Account.Services;
using teacher_api.Application.Base.Controllers;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace teacher_api.Application.Account.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ApiBaseController
    {
        private readonly AuthChallengeService _authChallengeService;

        public AccountController(AuthChallengeService authChallengeService)
        {
            this._authChallengeService = authChallengeService;
        }

        [HttpPost]
        [Route("token")]
        public async Task<IActionResult> Token()
        {
            var context = HttpContext;
                
            return await _authChallengeService.Challenge(context);
        }

        [HttpPost]
        [Route("register/personal")]
        public async Task<IActionResult> PersonalRegister([FromBody] PersonalAccountRegisterCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost]
        [Route("register/organization")]
        public async Task<IActionResult> OrganizationRegister([FromBody] OrganizationAccountRegisterCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}

