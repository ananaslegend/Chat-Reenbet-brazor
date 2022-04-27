using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Chat_Reenbet_brazor.DB;
using System.Threading.Tasks;
using Chat_Reenbet_brazor.Models;

namespace Chat_Reenbet_brazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class LoginController : ControllerBase
    {
        private readonly IDbUnit _dbUnit;
        private readonly UserRepository _context;

        public LoginController(IDbUnit dbUnit)
        {
           _dbUnit = dbUnit;
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            if (_dbUnit.Users.LoginUser(user))
            {
                return Ok();
            }
            
            return NotFound();
        }
        
    }
    
}