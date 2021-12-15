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
    public class PayDetailsController : ControllerBase
    {

        [HttpGet("getPaySlip/{PhoneNumber}/{PayMonth}/{PayYear}")]
        public async Task<ActionResult<PayDetails>> GetPayDetailsAsync(string PhoneNumber, string PayMonth, int PayYear)
        {
            await Task.Delay(0);

            var payDetailsRepo = new PayDetailsRepository();
            var payDetails = payDetailsRepo.GetByPayMonth(PhoneNumber, PayMonth, PayYear);

            if (payDetails != null)
                return Ok(payDetails);

            return NotFound();
        }

        [HttpGet("getP9/{PhoneNumber}/{PayYear}")]
        public async Task<ActionResult<List<PayDetails>>> GetPayDetailsAsync(string PhoneNumber, int PayYear)
        {
            await Task.Delay(0);

            var payDetailsRepo = new PayDetailsRepository();
            var payDetails = payDetailsRepo.GetByPayYear(PhoneNumber, PayYear);

            if (payDetails != null)
                return Ok(payDetails);

            return NotFound();
        }

        [HttpPost("save")]
        public async Task<ActionResult<PayDetails>> SavePayDetailsAsync()
        {
            await Task.Delay(0);
            string payDetailsString = Http.GetRequestBody(Request.Body);

            if (!string.IsNullOrEmpty(payDetailsString))
            {
                var payDetails = Json.ParseApiData<PayDetails>(payDetailsString);

                if (payDetails != null)
                {
                    var payDetailsRepo = new PayDetailsRepository();

                    var result = payDetailsRepo.Add(payDetails);

                    return Ok(result);
                }
            }

            return NotFound();
        }
    }
}
