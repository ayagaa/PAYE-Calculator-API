using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PAYE.API.Models;
using PAYE.API.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAYE.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public UsersController()
        {

        }

        [HttpGet()]
        public async Task<ActionResult<User>> GetUserAsync([FromQuery]
                                                    string PhoneNumber)
        {
            return Ok(default(User));
        }


        [HttpPost("add")]
        public async Task<ActionResult<User>> AddUserAsync()
        {
            string userString = Http.GetRequestBody(Request.Body);

            if(!string.IsNullOrEmpty(userString))
            {
                var user = Json.ParseApiData<User>(userString);

                if(user != null)
                {
                    var isSaved = await user.SaveAsync();

                    if (isSaved)
                        return Ok(user);
                }
            }

            return NotFound();
        }
    }
}
