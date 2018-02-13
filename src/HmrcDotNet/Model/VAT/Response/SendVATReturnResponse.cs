using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmrcDotNet.Model.VAT.Response
{
    public class SendVATReturnResponse
    {
        public DateTime processingDate { get; set; }
        public string paymentIndicator { get; set; }
        public string formBundleNumber { get; set; }
        public string chargeRefNumber { get; set; }
    }


}
