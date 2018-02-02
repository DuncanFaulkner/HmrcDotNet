using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmrcDotNet.Model.Generic
{
    public class Error
    {
        public string code { get; set; }
        public string message { get; set; }
        public string path { get; set; }
    }

    public class ErrorResponseModel
    {
        public string code { get; set; }
        public string message { get; set; }
        public List<Error> errors { get; set; }
    }
    
}
