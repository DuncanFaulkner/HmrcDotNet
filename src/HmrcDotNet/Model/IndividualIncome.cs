using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmrcDotNet.Model
{

    public class IndividualIncome
    {
        public IndividualIncome()
        {
            PensionsAnnuitiesAndOtherStateBenefits = new Pensionsannuitiesandotherstatebenefits();
            Employments = new List<Employment>();
        }
        public Pensionsannuitiesandotherstatebenefits PensionsAnnuitiesAndOtherStateBenefits { get; set; }
        public List<Employment> Employments { get; set; }
        public class Pensionsannuitiesandotherstatebenefits
        {
            public float otherPensionsAndRetirementAnnuities { get; set; }
            public float incapacityBenefit { get; set; }
            public float jobseekersAllowance { get; set; }
        }

        public class Employment
        {
            public string employerPayeReference { get; set; }
            public float payFromEmployment { get; set; }
        }
    }

    

   

}
