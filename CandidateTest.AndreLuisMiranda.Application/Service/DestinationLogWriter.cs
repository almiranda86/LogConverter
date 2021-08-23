using CandidateTest.AndreLuisMiranda.Application.Common;
using CandidateTest.AndreLuisMiranda.Domain;
using CandidateTest.AndreLuisMiranda.Service.Behavior;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CandidateTest.AndreLuisMiranda.Service
{
    public class DestinationLogWriter : IDestinationLogWriter
    {
        private readonly string _Version = "#Version: 1.0";
        private readonly string _Fields = "#Fields: provider http-method status-code uri-path time-taken response-size cache-status";
        private string _path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

        public async Task<string> Write(List<DestinationLogModel> collDesntinyLog)
        {
            var fullPath = $@"{_path}\destination_from_source_{DateTimeOffset.Now.ToUnixTimeSeconds()}.txt";

            try
            {
                using var sw = new StreamWriter(fullPath);
                sw.WriteLine(_Version);
                sw.WriteLine($"#Date {DateTime.Now}");
                sw.WriteLine(_Fields);

                foreach (var log in collDesntinyLog)
                {
                    sw.WriteLine($"{log.Provider} {log.HttpMethod} {log.StatusCode} {log.UriPath} {log.TimeTaken} {log.ResponseSize} {log.CacheStatus}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{Messages.EndProgram} - {typeof(DestinationLogWriter).FullName}.{nameof(Write)}", ex.InnerException);
            }

            return fullPath;
        }
    }
}
