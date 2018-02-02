using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmrcDotNet.Service
{
    public interface IDividendDataService : IBaseService
    {
        
    }

    public class DividendDataService : IDividendDataService
    {
        private readonly IHmrcCommonDataService _hmrcCommonDataService;
        private string _token;

        public DividendDataService(IHmrcCommonDataService HmrcCommonDataService)
        {
            _hmrcCommonDataService = HmrcCommonDataService;
        }

        public void SetToken(string token)
        {
            _token = token;
        }
    }
}
