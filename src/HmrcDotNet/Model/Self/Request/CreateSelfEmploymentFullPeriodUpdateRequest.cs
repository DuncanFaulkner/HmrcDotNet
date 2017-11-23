using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmrcDotNet.Model.Self.Request
{
    public class CreateSelfEmploymentFullPeriodUpdateRequest
    {
        public CreateSelfEmploymentFullPeriodUpdateRequest()
        {
            incomes = new Incomes();
            expenses = new Expenses();
        }

        public string from { get; set; }
        public string to { get; set; }
        public Incomes incomes { get; set; }
        public Expenses expenses { get; set; }


        public class Incomes
        {
            public Incomes()
            {
                turnover = new Turnover();
                other = new Other();
            }

            public Turnover turnover { get; set; }
            public Other other { get; set; }
        }

        public class Turnover
        {
            public float amount { get; set; }
        }

        public class Other
        {
            public float amount { get; set; }
        }

        public class Expenses
        {
            public Expenses()
            {
                costOfGoodsBought = new Costofgoodsbought();
                cisPaymentsToSubcontractors = new Cispaymentstosubcontractors();
                staffCosts = new Staffcosts();
                travelCosts = new Travelcosts();
                premisesRunningCosts = new Premisesrunningcosts();
                maintenanceCosts = new Maintenancecosts();
                adminCosts = new Admincosts();
                advertisingCosts = new Advertisingcosts();
                interest = new Interest();
                financialCharges = new Financialcharges();
                badDebt = new Baddebt();
                professionalFees = new Professionalfees();
                depreciation = new Depreciation();
                other = new Other1();
            }

            public Costofgoodsbought costOfGoodsBought { get; set; }
            public Cispaymentstosubcontractors cisPaymentsToSubcontractors { get; set; }
            public Staffcosts staffCosts { get; set; }
            public Travelcosts travelCosts { get; set; }
            public Premisesrunningcosts premisesRunningCosts { get; set; }
            public Maintenancecosts maintenanceCosts { get; set; }
            public Admincosts adminCosts { get; set; }
            public Advertisingcosts advertisingCosts { get; set; }
            public Interest interest { get; set; }
            public Financialcharges financialCharges { get; set; }
            public Baddebt badDebt { get; set; }
            public Professionalfees professionalFees { get; set; }
            public Depreciation depreciation { get; set; }
            public Other1 other { get; set; }
        }

        public class Costofgoodsbought
        {
            public float amount { get; set; }
            public float disallowableAmount { get; set; }
        }

        public class Cispaymentstosubcontractors
        {
            public float amount { get; set; }
            public float disallowableAmount { get; set; }
        }

        public class Staffcosts
        {
            public float amount { get; set; }
            public float disallowableAmount { get; set; }
        }

        public class Travelcosts
        {
            public float amount { get; set; }
            public float disallowableAmount { get; set; }
        }

        public class Premisesrunningcosts
        {
            public float amount { get; set; }
            public float disallowableAmount { get; set; }
        }

        public class Maintenancecosts
        {
            public float amount { get; set; }
            public float disallowableAmount { get; set; }
        }

        public class Admincosts
        {
            public float amount { get; set; }
            public float disallowableAmount { get; set; }
        }

        public class Advertisingcosts
        {
            public float amount { get; set; }
            public float disallowableAmount { get; set; }
        }

        public class Interest
        {
            public float amount { get; set; }
            public float disallowableAmount { get; set; }
        }

        public class Financialcharges
        {
            public float amount { get; set; }
            public float disallowableAmount { get; set; }
        }

        public class Baddebt
        {
            public float amount { get; set; }
            public float disallowableAmount { get; set; }
        }

        public class Professionalfees
        {
            public float amount { get; set; }
            public float disallowableAmount { get; set; }
        }

        public class Depreciation
        {
            public float amount { get; set; }
            public float disallowableAmount { get; set; }
        }

        public class Other1
        {
            public float amount { get; set; }
            public float disallowableAmount { get; set; }
        }

    }
}
