using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmrcDotNet.Model.Self.Request
{
    public class CreateSelfEmploymentConPeriodUpdateRequest
    {
        public CreateSelfEmploymentConPeriodUpdateRequest()
        {
            incomes = new Incomes();
        }

        public string from { get; set; }
        public string to { get; set; }
        public Incomes incomes { get; set; }
        public float consolidatedExpenses { get; set; }


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
    }

}
