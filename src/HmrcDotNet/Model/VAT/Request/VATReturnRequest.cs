using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmrcDotNet.Model.VAT.Request
{

    public class VATReturnRequest
    {
        public string periodKey { get; set; }
        public decimal vatDueSales { get; set; }
        public decimal vatDueAcquisitions { get; set; }
        public decimal totalVatDue { get; set; }
        public decimal vatReclaimedCurrPeriod { get; set; }
        public decimal netVatDue { get; set; }
        public int totalValueSalesExVAT { get; set; }
        public int totalValuePurchasesExVAT { get; set; }
        public int totalValueGoodsSuppliedExVAT { get; set; }
        public int totalAcquisitionsExVAT { get; set; }
        public bool finalised { get; set; }
    }

}
