using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAYE.API.Calculators
{
    public interface ICalculator
    {
        double Calculate(double TaxInput);
    }
}
