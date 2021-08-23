using CandidateTest.AndreLuisMiranda.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CandidateTest.AndreLuisMiranda.Service.Behavior
{
    public interface IDestinationLogWriter
    {
        Task<string> Write(List<DestinationLogModel> collDestinyLog);
    }
}
