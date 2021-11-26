using PAYE.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAYE.API.Calculators
{
    public class NHIFCalculator : ICalculator
    {
        public double Calculate(double TaxInput)
        {
            for(int i = 0; i < Constants.NHIFTaxRanges.Count; i++)
            {
                if(TaxInput >= Constants.NHIFTaxRanges[i].StartRange && 
                    TaxInput <= Constants.NHIFTaxRanges[i].EndRange)
                {
                    return Constants.NHIFTaxRanges[i].TaxRate;
                }
            }
            return 0;
        }
    }
}
