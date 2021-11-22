using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAYE.API.Models
{
    public static class Constants
    {
        public static readonly float MINIMUM_TAXABLE_AMOUNT = 0;
        public static readonly float PERSONAL_RELIEF_AMOUNT = 0;
        public static readonly List<TaxRange> PAYETaxRanges = new List<TaxRange>()
        {
            new TaxRange(){RangeId = 0, StartRange = 0, EndRange = 12298, TaxRate = 10, RateType = RateType.Percent },
            new TaxRange(){RangeId = 1, StartRange = 12299, EndRange = 23885, TaxRate = 15, RateType = RateType.Percent },
            new TaxRange(){RangeId = 2, StartRange = 23886, EndRange = 35472, TaxRate = 20, RateType = RateType.Percent },
            new TaxRange(){RangeId = 3, StartRange = 35473, EndRange = 47059, TaxRate = 25, RateType = RateType.Percent },
            new TaxRange(){RangeId = 4, StartRange = 47060, EndRange = 999999999.99f, TaxRate = 30, RateType = RateType.Percent },
        };

        public static readonly List<TaxRange> NHIFTaxRanges = new List<TaxRange>()
        {
            new TaxRange(){RangeId = 0, StartRange = 0, EndRange = 5999.99f, TaxRate = 150, RateType = RateType.Value },
            new TaxRange(){RangeId = 1, StartRange = 6000, EndRange = 7999.99f, TaxRate = 300, RateType = RateType.Value },
            new TaxRange(){RangeId = 2, StartRange = 8000, EndRange = 11999.99f, TaxRate = 400, RateType = RateType.Value },
            new TaxRange(){RangeId = 3, StartRange = 12000, EndRange = 14999.99f, TaxRate = 500, RateType = RateType.Value },
            new TaxRange(){RangeId = 4, StartRange = 15000, EndRange = 19999.99f, TaxRate = 600, RateType = RateType.Value },
            new TaxRange(){RangeId = 5, StartRange = 20000, EndRange = 24999.99f, TaxRate = 750, RateType = RateType.Value },
            new TaxRange(){RangeId = 6, StartRange = 25000, EndRange = 29999.99f, TaxRate = 850, RateType = RateType.Value },
            new TaxRange(){RangeId = 7, StartRange = 30000, EndRange = 34999.99f, TaxRate = 900, RateType = RateType.Value },
            new TaxRange(){RangeId = 8, StartRange = 35000, EndRange = 39999.99f, TaxRate = 950, RateType = RateType.Value },
            new TaxRange(){RangeId = 9, StartRange = 40000, EndRange = 44999.99f, TaxRate = 1000, RateType = RateType.Value },
            new TaxRange(){RangeId = 10, StartRange = 45000, EndRange = 49999.99f, TaxRate = 1100, RateType = RateType.Value },
            new TaxRange(){RangeId = 11, StartRange = 50000, EndRange = 59999.99f, TaxRate = 1200, RateType = RateType.Value },
            new TaxRange(){RangeId = 12, StartRange = 60000, EndRange = 69999.99f, TaxRate = 1300, RateType = RateType.Value },
            new TaxRange(){RangeId = 13, StartRange = 70000, EndRange = 79999.99f, TaxRate = 1400, RateType = RateType.Value },
            new TaxRange(){RangeId = 14, StartRange = 80000, EndRange = 89999.99f, TaxRate = 1500, RateType = RateType.Value },
            new TaxRange(){RangeId = 15, StartRange = 90000, EndRange = 99999.99f, TaxRate = 1600, RateType = RateType.Value },
            new TaxRange(){RangeId = 16, StartRange = 100000, EndRange = 1000000000, TaxRate = 1700, RateType = RateType.Value },
        };

        public static readonly float EMPLOYEE_RATE = 5;
        public static readonly float EMPLOYER_RATE = 5;
        public static readonly float MAXIMUM_RATE = 200;
        public static readonly float MINIMUM_RATE = 200;
        public static readonly float EMPLOYEE_PENSION_RATE = 6;
        public static readonly float EMPLOYER_PENSION_RATE = 6;
        public static readonly float TIER_I_EMPLOYEE_LIMIT = 360;
        public static readonly float TIER_I_EMPLOYER_LIMIT = 360;
        public static readonly float TIER_II_EMPLOYEE_LIMIT = 720;
        public static readonly float TIER_II_EMPLOYER_LIMIT = 720;
        public static readonly float TIER_I_MAX_PENSIONABLE_PAY = 6000;
        public static readonly float TIER_II_MAX_PENSIONABLE_PAY = 12000;

    }
}
