using System;
using System.Collections.Generic;
using System.Text;

namespace CandidateTest.AndreLuisMiranda.Domain.Base
{
    public class LogBaseModel
    {
        public string ResponseSize { get; set; }
        public string StatusCode { get; set; }
        public string CacheStatus { get; set; }
        public string HttpMethod { get; set; }
        public string UriPath { get; set; }
        public string TimeTaken { get; set; }
    }
}
