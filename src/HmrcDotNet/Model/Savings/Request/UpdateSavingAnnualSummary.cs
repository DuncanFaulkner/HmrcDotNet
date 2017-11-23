using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmrcDotNet.Model.Savings.Request
{
    public class UpdateSavingAnnualSummary
    {
        public float taxedUkInterest { get; set; }
        public float untaxedUkInterest { get; set; }
    }
}
