using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmrcDotNet.Model.Savings.Response
{
    public class SavingsAccountAnnualSummaryResponse
    {
        public float taxedUkInterest { get; set; }
        public float untaxedUkInterest { get; set; }
    }
}
