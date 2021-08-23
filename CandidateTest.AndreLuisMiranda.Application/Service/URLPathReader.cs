using CandidateTest.AndreLuisMiranda.Service.Behavior;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CandidateTest.AndreLuisMiranda.Service
{
    public class URLPathReader : IURLPathReader
    {
        public async Task<string> Read(string urlFile)
        {
            using (WebClient client = new WebClient())
            {
                var content = client.DownloadString(urlFile);

                return content;
            }
        }
    }
}


