using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CandidateTest.AndreLuisMiranda.Application.Service.Behavior
{
    public interface IConverter
    {
        Task Convert(string content);
    }
}
