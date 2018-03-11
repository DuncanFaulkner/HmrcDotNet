using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmrcDotNet.Model.VAT.Response
{
   
        public class VATPaymentResponse
        {
            public VATPaymentResponse()
            {
                payments = new List<Payment>();
            }
            public List<Payment> payments { get; set; }
        }

        public class Payment
        {
            public float amount { get; set; }
            public string received { get; set; }
        }

    
}
