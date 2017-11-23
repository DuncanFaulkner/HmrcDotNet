using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmrcDotNet.Service
{
    public interface ISelfDataService : IBaseService
    {

    }

    public class SelfDataService : ISelfDataService
    {
        private readonly ICommonDataService _commonDataService;
        private string _token;

        public SelfDataService(ICommonDataService commonDataService)
        {
            _commonDataService = commonDataService;
        }

        public void SetToken(string token)
        {
            _token = token;
        }
    }
}
