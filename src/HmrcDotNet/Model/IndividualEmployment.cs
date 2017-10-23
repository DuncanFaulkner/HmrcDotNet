using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmrcDotNet.Model
{
    //https://developer.service.hmrc.gov.uk/api-documentation/docs/api/service/individual-employment/1.0
    public class IndividualEmployments
    {
        public IndividualEmployments()
        {
            Employments = new List<Employment>();
        }
        public List<Employment> Employments { get; set; }

        public class Employment
        {
            public string EmployerPayeReference { get; set; }
            public string EmployerName { get; set; }
        }
    }

   

}
