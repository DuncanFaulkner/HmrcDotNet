using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmrcDotNet.Web.Data.Model
{
    public class Individual
    {
        public Guid IndividualId { get; set; }
        public string IndividualName { get; set; }
        public string SaUTR { get; set; }
        public string Nino { get; set; }
        public string AuthJsonPayLoad { get; set; }
    }
}
