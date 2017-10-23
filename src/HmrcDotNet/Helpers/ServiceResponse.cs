using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmrcDotNet.Helpers
{
    public class ServiceResponse
    {
        private Dictionary<string, string> _errorMessages;

        public ServiceResponse()
        {
            _errorMessages = new Dictionary<string, string>();
        }

        public void AddError(string key, string errorMessage)
        {
            if (!string.IsNullOrWhiteSpace(key))
                _errorMessages.Add(key, errorMessage);
        }

        public void AddErrors(Dictionary<string, string> errors)
        {
            foreach (var error in errors)
            {
                _errorMessages.Add(error.Key, error.Value);
            }
        }

        public bool IsValid
        {
            get { return !_errorMessages.Any(); }
        }

        public bool ContainsError(string error)
        {
            return _errorMessages.Values.Contains(error, StringComparer.OrdinalIgnoreCase);
        }
    }

    public class ServiceResponse<T> : ServiceResponse
    {
        public T Data { get; set; }
    }
}
