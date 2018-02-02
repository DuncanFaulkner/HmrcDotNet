using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmrcDotNet.Service
{
    public interface ISavingsAccountData : IBaseService
    {

    }

    public class SavingsAccountData : IDividendDataService
    {
        private readonly IHmrcCommonDataService _commonDataService;
        private string _token;

        public SavingsAccountData(IHmrcCommonDataService commonDataService)
        {
            _commonDataService = commonDataService;
        }

        public void SetToken(string token)
        {
            _token = token;
        }
    }
}
