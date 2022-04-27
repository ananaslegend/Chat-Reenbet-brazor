using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Chat_Reenbet_brazor.DB;
using Chat_Reenbet_brazor.Models;
using System.Threading.Tasks;

namespace Chat_Reenbet_brazor.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationController : ControllerBase
    {
        private readonly IDbUnit _dbUnit;

        public RegistrationController(IDbUnit dbUnit)
        {
            _dbUnit = dbUnit;
        }

        
        [HttpPost]
        public async Task<ActionResult> Post(User user)
        {
            _dbUnit.Users.Add(user);
            await _dbUnit.CompleteAsync();

            return Ok();
        }
    }
    
}