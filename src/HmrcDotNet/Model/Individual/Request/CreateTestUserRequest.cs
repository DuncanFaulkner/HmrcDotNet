using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmrcDotNet.Model.Individual
{

    public class CreateTestUserRequest
    {
        public CreateTestUserRequest()
        {
            serviceNames = new List<string>();
        }
        public List<String> serviceNames { get; set; }
    }

}
