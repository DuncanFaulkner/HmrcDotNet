using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace HmrcDotNet.Helpers
{
    public static class Validator
    {
        public static void ValidateUtRandTaxYear(string utr, string taxYear, ServiceResponse response)
        {
            if (!Regex.Match(utr, @"^\d{10}$", RegexOptions.IgnoreCase).Success)
            {
                response.AddError("UTR", "The UTR needs to be 10 characters");
            }
            if (!Regex.Match(taxYear, @"^[0-9]{4}-[0-1][0-9]$", RegexOptions.IgnoreCase).Success)
            {
                response.AddError("Year", "The Year is in the wrong format");
            }
        }

        public static void ValidateNinoandTaxYear(string nino, string taxYear, ServiceResponse response)
        {
            if (!Regex.Match(nino, @"^\s*[a-zA-Z]{2}(?:\s*\d\s*){6}[a-zA-Z]?\s*$", RegexOptions.IgnoreCase).Success)
            {
                response.AddError("NINO", "The nino is in the wrong format");
            }
            if (!Regex.Match(taxYear, @"^[0-9]{4}-[0-1][0-9]$", RegexOptions.IgnoreCase).Success)
            {
                response.AddError("Year", "The Year is in the wrong format");
            }
        }
    }
}
