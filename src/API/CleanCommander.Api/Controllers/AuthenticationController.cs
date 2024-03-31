using CleanCommander.Application.Contracts.Authentication;
using CleanCommander.Application.Models.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanCommander.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }


        [HttpPost, Route("authenticate")]
        public ActionResult<AuthenticationResponse> Authenticate(AuthenticationRequest request)
        {
            var response = authenticationService.Authenticate(request);
            if (response.Token == null)
                return Unauthorized(response);
            return Ok(response);
        }
    }
}
