using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VacinneRegister.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacinneRegisterController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetRegistersVacinnes()
        {
            return Ok(null);
        }
    }
}
