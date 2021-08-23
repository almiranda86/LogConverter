using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CandidateTest.AndreLuisMiranda.Service.Behavior
{
    public interface IURLPathReader
    {
        Task<string> Read(string urlFile);
    }
}
