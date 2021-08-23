using CandidateTest.AndreLuisMiranda.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CandidateTest.AndreLuisMiranda.Service.Behavior
{
    public interface ISourceLogReader
    {
        Task<List<SourceLogModel>> Read(string content);
    }
}
