using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Football_League.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Football_League.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BaseController : Controller
    {
        protected ResponseDto<BaseModelDto> ModelStateErrors()
        {
            var response = new ResponseDto<BaseModelDto>();

            foreach (var key in ModelState.Keys)
            {
                var value = ViewData.ModelState[key];

                foreach (var error in value.Errors)
                {
                    response.Errors.Add(error.Exception != null ?
                        $"{key}: Nieprawidłowy format danych" 
                        : $"{key}: {error.ErrorMessage}");
                }
            }
            return response;
        }

    }
}
