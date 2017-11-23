using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmrcDotNet.Model.Self.Response
{
        public class SelfEmploymentObligationsResponse
        {
            public SelfEmploymentObligationsResponse()
            {
                obligations = new List<Obligation>();
            }
            public List<Obligation> obligations { get; set; }
        }

        public class Obligation
        {
            public string start { get; set; }
            public string end { get; set; }
            public string due { get; set; }
            public bool met { get; set; }
        }

    
}
