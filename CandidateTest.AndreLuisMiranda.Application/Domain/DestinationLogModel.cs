using CandidateTest.AndreLuisMiranda.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CandidateTest.AndreLuisMiranda.Domain
{
    public class DestinationLogModel : LogBaseModel
    {
        public string Provider { get; set; }

        public DestinationLogModel()
        {
            Provider = @"""DESTINY_LOG""";
        }
    }
}
