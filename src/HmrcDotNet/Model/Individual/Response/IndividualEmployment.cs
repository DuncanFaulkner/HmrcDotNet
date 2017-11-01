using System.Collections.Generic;

namespace HmrcDotNet.Model.Individual.Response
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
