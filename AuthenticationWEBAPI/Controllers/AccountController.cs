using JwtAuthenticationManager;
using JwtAuthenticationManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationWEBAPI.Controllers
{
    /// <summary>
    /// Controller for Authorize and authenticate the API
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtTokenHandler _jwtTokenHandler;

        /// <summary>
        /// Injected dependecies
        /// </summary>
        /// <param name="jwtTokenHandler"></param>
        public AccountController(JwtTokenHandler jwtTokenHandler)
        {
            _jwtTokenHandler = jwtTokenHandler;
        }

        /// <summary>
        /// Api for Authenticating the API
        /// </summary>
        /// <param name="authenticatonRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<AuthenticationResponse> Authenticatae([FromBody] AuthenticatonRequest authenticatonRequest)
        {
            var authenticationResponse = _jwtTokenHandler.GenerateJwtToken(authenticatonRequest);
            if (authenticationResponse == null) return Unauthorized();
            return authenticationResponse;
        }
    }
}
