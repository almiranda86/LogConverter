using CandidateTest.AndreLuisMiranda.Application.Common;
using CandidateTest.AndreLuisMiranda.Domain;
using CandidateTest.AndreLuisMiranda.Service.Behavior;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CandidateTest.AndreLuisMiranda.Application.Service
{
    public class SourceLogReader : ISourceLogReader
    {
        public async Task<List<SourceLogModel>> Read(string content)
        {
            List<SourceLogModel> collSource = new List<SourceLogModel>();

            try
            {
                content = content.Replace("\r", "");

                var splitedContent = content.Split('\n');

                foreach (string lineContent in splitedContent)
                {
                    if (string.IsNullOrWhiteSpace(lineContent))
                        break;

                    var lineSplitedContent = lineContent.Split('|');

                    var splitMethoPathProtocol = lineSplitedContent[3].Split(' ');

                    SourceLogModel sourceLogModel = new SourceLogModel()
                    {
                        CacheStatus = lineSplitedContent[2],
                        HttpMethod = splitMethoPathProtocol[0].Substring(1, splitMethoPathProtocol[0].Length - 1),
                        Protocol = splitMethoPathProtocol[2].Substring(0, splitMethoPathProtocol[2].Length - 1),
                        ResponseSize = lineSplitedContent[0],
                        StatusCode = lineSplitedContent[1],
                        TimeTaken = lineSplitedContent[4].Replace('.',','),
                        UriPath = splitMethoPathProtocol[1]
                    };

                    collSource.Add(sourceLogModel);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{Messages.EndProgram} - {typeof(SourceLogReader).FullName}.{nameof(Read)}", ex.InnerException);
            }

            return collSource;
        }
    }
}
