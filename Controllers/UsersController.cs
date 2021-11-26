using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PAYE.API.DataAccess;
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

        [HttpGet("getuser/{PhoneNumber}")]
        public async Task<ActionResult<User>> GetUserAsync(string PhoneNumber)
        {
            await Task.Delay(0);
            var userRepo = new UserRespository();

            var users = userRepo.GetAll();
            var user = users.First(u => u.PhoneNumber.ToLower() == PhoneNumber);
            if (user != null)
                return Ok(user);

            return NotFound();
        }

        [HttpGet("getusers")]
        public async Task<ActionResult<List<User>>> GetAllUsersAsync()
        {
            await Task.Delay(0);
            var userRepo = new UserRespository();

            var users = userRepo.GetAll();
            if (users?.Count > 0)
                return Ok(users);

            return NotFound();
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
