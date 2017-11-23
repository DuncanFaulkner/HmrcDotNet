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
        private readonly ICommonDataService _commonDataService;
        private string _token;

        public DividendDataService(ICommonDataService commonDataService)
        {
            _commonDataService = commonDataService;
        }

        public void SetToken(string token)
        {
            _token = token;
        }
    }
}
