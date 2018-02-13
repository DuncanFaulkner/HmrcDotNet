using System;
using System.Collections.Generic;

namespace HmrcDotNet.Model.VAT.Response
{

    public class VATObligationsResponse
    {
        public VATObligationsResponse()
        {
            obligations = new List<VATObligation>();
        }

        public string CorrelationId { get; set; }
        public List<VATObligation> obligations { get; set; }
    }

    public class VATObligation
    {
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public DateTime due { get; set; }
        public string status { get; set; }
        public DateTime received { get; set; }
        public string periodKey { get; set; }
    }

    

}
