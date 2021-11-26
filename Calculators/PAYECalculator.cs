using PAYE.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAYE.API.Calculators
{
    public class PAYECalculator : ICalculator
    {
        public double Calculate(double TaxInput)
        {
            if(TaxInput >= Constants.MINIMUM_TAXABLE_AMOUNT)
            {
                double rangePAYE = 0;
                double outRangePAYE = 0;
                for(int i = 0; i < Constants.PAYETaxRanges.Count; i++)
                {
                    if(TaxInput >= Constants.PAYETaxRanges[i].StartRange &&
                        TaxInput >= Constants.PAYETaxRanges[i].EndRange)
                    {
                        rangePAYE += Math.Round(((Constants.PAYETaxRanges[i].TaxRate / 100) *
                            (Constants.PAYETaxRanges[i].EndRange - Constants.PAYETaxRanges[i].StartRange)));
                    }
                    if(TaxInput >= Constants.PAYETaxRanges[i].StartRange &&
                        TaxInput < Constants.PAYETaxRanges[i].EndRange)
                    {
                        outRangePAYE += Math.Round(((Constants.PAYETaxRanges[i].TaxRate / 100) * 
                            (TaxInput - Constants.PAYETaxRanges[i].StartRange)));
                    }
                }

                return rangePAYE + outRangePAYE;
            }
            return 0;
        }
    }
}
