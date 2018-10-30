using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Football_League.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Football_League.Api.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class BaseController : Controller
    {     

    }
}
