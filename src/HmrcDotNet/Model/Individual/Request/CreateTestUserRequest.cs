using System;
using System.Collections.Generic;

namespace HmrcDotNet.Model.Individual.Request
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
