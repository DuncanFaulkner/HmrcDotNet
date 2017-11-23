using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmrcDotNet.Model.Self.Request
{

    public class CreateSelfEmploymentRequest
    {
        public CreateSelfEmploymentRequest()
        {
            accountingPeriod = new Accountingperiod();
        }
        public Accountingperiod accountingPeriod { get; set; }
        public string accountingType { get; set; }
        public string commencementDate { get; set; }
        public string tradingName { get; set; }
        public string businessDescription { get; set; }
        public string businessAddressLineOne { get; set; }
        public string businessAddressLineTwo { get; set; }
        public string businessAddressLineThree { get; set; }
        public string businessAddressLineFour { get; set; }
        public string businessPostcode { get; set; }
    }

    public class Accountingperiod
    {
        public string start { get; set; }
        public string end { get; set; }
    }


}
