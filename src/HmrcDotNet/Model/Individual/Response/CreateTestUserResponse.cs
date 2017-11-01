using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmrcDotNet.Model.Individual
{

    public class CreateTestUserResponse
    {
        public string userId { get; set; }
        public string password { get; set; }
        public string userFullName { get; set; }
        public string emailAddress { get; set; }
        public Individualdetails individualDetails { get; set; }
        public string saUtr { get; set; }
        public string nino { get; set; }
        public string mtdItId { get; set; }
    }

    public class Individualdetails
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string dateOfBirth { get; set; }
        public Address address { get; set; }
    }

    public class Address
    {
        public string line1 { get; set; }
        public string line2 { get; set; }
        public string postcode { get; set; }
    }

}
