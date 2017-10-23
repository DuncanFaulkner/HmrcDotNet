﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmrcDotNet.Model
{

    public class IndividualTax
    {
        public IndividualTax()
        {
            PensionsAnnuitiesAndOtherStateBenefits = new Pensionsannuitiesandotherstatebenefits();
            Refunds = new IndividualTaxRefunds();
            Employments = new List<Employment>();
        }

        public Pensionsannuitiesandotherstatebenefits PensionsAnnuitiesAndOtherStateBenefits { get; set; }
        public IndividualTaxRefunds Refunds { get; set; }
        public List<Employment> Employments { get; set; }

        public class Pensionsannuitiesandotherstatebenefits
        {
            public float OtherPensionsAndRetirementAnnuities { get; set; }
            public float IncapacityBenefit { get; set; }
        }

        public class IndividualTaxRefunds
        {
            public float TaxRefundedOrSetOff { get; set; }
        }

        public class Employment
        {
            public string EmployerPayeReference { get; set; }
            public float TaxTakenOffPay { get; set; }
        }
    }

    

    

}
