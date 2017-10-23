using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmrcDotNet.Model
{
   

        public class IndividualBenefits
        {
            public IndividualBenefits()
            {
                Employments = new List<Employment>();
            }
            public List<IndividualBenefits.Employment> Employments { get; set; }

            public class Employment
            {
                public string EmployerPayeReference { get; set; }
                public int CompanyCarsAndVansBenefit { get; set; }
                public int FuelForCompanyCarsAndVansBenefit { get; set; }
                public int PrivateMedicalDentalInsurance { get; set; }
                public int VouchersCreditCardsExcessMileageAllowance { get; set; }
                public int GoodsEtcProvidedByEmployer { get; set; }
                public int AccommodationProvidedByEmployer { get; set; }
                public int OtherBenefits { get; set; }
                public int ExpensesPaymentsReceived { get; set; }
            }
    }

      

   
}
