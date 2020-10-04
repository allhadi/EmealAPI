using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Emeal.Model;
using Emeal.Model.ViewModel;
using Emeal.Service.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Emeal.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccessController : ControllerBase
    {
        private readonly IUserService _userService;

        public AccessController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginViewModel user)
        {
           var found = _userService.Login(user);
            if (found == null)
            {
                return Unauthorized();
            }
            return Ok();
        }

        [HttpGet]
        public IActionResult Test()
        {
            return Ok("Test passed!!");
        }

        [HttpPost("registration")]

        public IActionResult Registration(RegistrationViewModel registrationViewModel)
        {
            _userService.Registration(registrationViewModel);
            return Ok();
        }


    }
}
