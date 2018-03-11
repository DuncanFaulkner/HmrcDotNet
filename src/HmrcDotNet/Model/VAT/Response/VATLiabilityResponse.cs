using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmrcDotNet.Model.VAT.Response
{
    

        public class VATLiabilityResponse
        {
            public VATLiabilityResponse()
            {
                liabilities = new List<Liability>();
            }
            public List<Liability> liabilities { get; set; }
        }

        public class Liability
        {
            public Liability()
            {
                taxPeriod = new Taxperiod();
            }

            public Taxperiod taxPeriod { get; set; }
            public string type { get; set; }
            public float originalAmount { get; set; }
            public float outstandingAmount { get; set; }
            public string due { get; set; }
        }

        public class Taxperiod
        {
            public string from { get; set; }
            public string to { get; set; }
        }

    
}
