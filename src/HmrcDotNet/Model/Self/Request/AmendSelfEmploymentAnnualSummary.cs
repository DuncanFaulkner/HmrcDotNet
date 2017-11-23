using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmrcDotNet.Model.Self.Request
{
    public class AmendSelfEmploymentAnnualSummary
    {
        public AmendSelfEmploymentAnnualSummary()
        {
            adjustments = new Adjustments();
            allowances = new Allowances();
            nonFinancials = new Nonfinancials();
        }

        public Adjustments adjustments { get; set; }
        public Allowances allowances { get; set; }
        public Nonfinancials nonFinancials { get; set; }

        public class Adjustments
        {
            public float includedNonTaxableProfits { get; set; }
            public float basisAdjustment { get; set; }
            public float overlapReliefUsed { get; set; }
            public float accountingAdjustment { get; set; }
            public float averagingAdjustment { get; set; }
            public float lossBroughtForward { get; set; }
            public float outstandingBusinessIncome { get; set; }
            public float balancingChargeBPRA { get; set; }
            public float balancingChargeOther { get; set; }
            public float goodsAndServicesOwnUse { get; set; }
        }

        public class Allowances
        {
            public float annualInvestmentAllowance { get; set; }
            public float capitalAllowanceMainPool { get; set; }
            public float capitalAllowanceSpecialRatePool { get; set; }
            public float zeroEmissionGoodsVehicleAllowance { get; set; }
            public float businessPremisesRenovationAllowance { get; set; }
            public float enhancedCapitalAllowance { get; set; }
            public float allowanceOnSales { get; set; }
        }

        public class Nonfinancials
        {
            public Nonfinancials()
            {
                class4NicInfo = new Class4nicinfo();
            }
            public Class4nicinfo class4NicInfo { get; set; }
            public bool payVoluntaryClass2Nic { get; set; }
        }

        public class Class4nicinfo
        {
            public bool isExempt { get; set; }
            public string exemptionCode { get; set; }
        }

    }

}
