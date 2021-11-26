using PAYE.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAYE.API.Calculators
{
    public class NSSFCalculator : ICalculator
    {
        public double Calculate(double TaxInput)
        {
            double tier1Amount = 0;
            double tier2Amount = 0;

            if(TaxInput <= Constants.TIER_I_MAX_PENSIONABLE_PAY)
            {
                tier1Amount = Math.Round(TaxInput * (Constants.EMPLOYEE_PENSION_RATE / 100));
            }
            if(TaxInput > Constants.TIER_I_MAX_PENSIONABLE_PAY)
            {
                double tier1PayBalance = TaxInput - Constants.TIER_I_MAX_PENSIONABLE_PAY;

                tier1Amount = Math.Round(Constants.TIER_I_MAX_PENSIONABLE_PAY * (Constants.EMPLOYEE_PENSION_RATE / 100));

                if(tier1PayBalance <= Constants.TIER_II_MAX_PENSIONABLE_PAY)
                {
                    tier2Amount = Math.Round(tier1PayBalance * (Constants.EMPLOYEE_PENSION_RATE / 100));
                }
                if(tier1PayBalance > Constants.TIER_II_MAX_PENSIONABLE_PAY)
                {
                    tier2Amount = Math.Round(Constants.TIER_II_MAX_PENSIONABLE_PAY * (Constants.EMPLOYEE_PENSION_RATE / 100));
                }
            }
            return tier1Amount + tier2Amount;
        }
    }
}
