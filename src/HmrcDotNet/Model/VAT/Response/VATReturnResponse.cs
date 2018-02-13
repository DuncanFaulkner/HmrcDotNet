using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmrcDotNet.Model.VAT.Response
{
    public class VATReturnResponse
    {
        public string periodKey { get; set; }
        public decimal vatDueSales { get; set; }
        public decimal vatDueAcquisitions { get; set; }
        public int totalVatDue { get; set; }
        public decimal vatReclaimedCurrPeriod { get; set; }
        public int netVatDue { get; set; }
        public int totalValueSalesExVAT { get; set; }
        public int totalValuePurchasesExVAT { get; set; }
        public int totalValueGoodsSuppliedExVAT { get; set; }
        public int totalAcquisitionsExVAT { get; set; }

    }
}
