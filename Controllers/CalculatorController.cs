using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PAYE.API.Calculators;
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
    public class CalculatorController : ControllerBase
    {
        public CalculatorController()
        {

        }

        public async Task<ActionResult<PayDetails>> CalculateAsync()
        {
            string payDetailsString = Http.GetRequestBody(Request.Body);

            if(!string.IsNullOrEmpty(payDetailsString))
            {
                var payDetails = Json.ParseApiData<PayDetails>(payDetailsString);

                if(payDetails != null)
                {
                    var result = await TaxCalculator.CalculateTaxAsync(payDetails);

                    return Ok(result);
                }
            }

            return NotFound();
        }
    }
}
