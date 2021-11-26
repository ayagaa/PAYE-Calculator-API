using PAYE.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAYE.API.Calculators
{
    public static class TaxCalculator
    {
        public static async Task<PayDetails> CalculateTaxAsync(PayDetails payDetails)
        {
            await Task.Delay(0);

            var NSSFCalculator = new NSSFCalculator();
            var NSSFAmount = NSSFCalculator.Calculate(payDetails.GrossPay);

            var taxableIncome = payDetails.GrossPay - NSSFAmount;

            var PAYECalculator = new PAYECalculator();
            var taxBeforeRelief = PAYECalculator.Calculate(taxableIncome);

            var PAYEAmount = taxBeforeRelief > 0? taxBeforeRelief - Constants.PERSONAL_RELIEF_AMOUNT: 0;

            var NHIFCalculator = new NHIFCalculator();
            var NHIFAmount = NHIFCalculator.Calculate(taxableIncome);

            var netPay = taxableIncome - PAYEAmount - NHIFAmount;

            var resultPayDetails = new PayDetails()
            {
                TaxableIncome = taxableIncome,
                PAYE = PAYEAmount,
                NHIF = NHIFAmount,
                NSSF = NSSFAmount,
                NetPay = netPay,
                PersonalRelief = taxBeforeRelief > 0? Constants.PERSONAL_RELIEF_AMOUNT : 0,
                TaxBeforeRelief = taxBeforeRelief,
                GrossPay = payDetails.GrossPay,
                PayMonth = payDetails.PayMonth,
                PayYear = payDetails.PayYear,
                PhoneNumber = payDetails.PhoneNumber
            };


            return resultPayDetails;
        }
    }
}
