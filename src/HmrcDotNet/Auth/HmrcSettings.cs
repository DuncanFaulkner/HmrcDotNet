﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmrcDotNet.Auth
{
    public class HmrcSettings
    {
        public string BaseUrl { get; set; }
        public string ClientId { get; set; }
        public string ClientSecretId { get; set; }
        public string ServerToken { get; set; }
    }
}