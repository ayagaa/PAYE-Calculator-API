using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAYE.API.Models
{
    public class TaxRange
    {
        public int RangeId { get; set; }
        public float StartRange { get; set; }
        public float EndRange { get; set; }
        public float TaxRate { get; set; }
        public RateType RateType { get; set; }

    }

    public enum RateType
    {
        Percent = 0,
        Value = 1
    }
}
