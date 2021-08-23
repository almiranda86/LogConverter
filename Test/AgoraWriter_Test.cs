using CandidateTest.AndreLuisMiranda.Domain;
using CandidateTest.AndreLuisMiranda.Service;
using CandidateTest.AndreLuisMiranda.Service.Behavior;
using Moq;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test
{
    public class AgoraWriter_Test
    {

        private readonly AutoMocker _autoMock;

        public AgoraWriter_Test()
        {
            _autoMock = new AutoMocker();
        }

        [Fact(DisplayName = "#1 - Given a group of Source Format should write a new log file in Destiny format")]
        [Trait("Category", "Success")]
        public async Task ReadUrlInformed_Test()
        {
            //Arrange
            var collDestiny = new List<DestinationLogModel>();
            collDestiny.Add(new DestinationLogModel()
            {
                CacheStatus = "A",
                HttpMethod = "B",
                Provider = "C",
                ResponseSize = "D",
                StatusCode = "E",
                TimeTaken = "F",
                UriPath = "G"
            });

            var agoraReader = _autoMock.GetMock<IDestinationLogWriter>().Setup(writer => writer.Write(It.IsAny<List<DestinationLogModel>>()))
                                                                 .ReturnsAsync(It.IsAny<string>());

            _autoMock.GetMock<StreamWriter>();

            var agora = _autoMock.CreateInstance<DestinationLogWriter>();

            //Act
            var content = await agora.Write(collDestiny);

            //Assert
            Assert.True(File.Exists(content));

            if (File.Exists(content))
            {
                File.Delete(content);
            }
        }
    }
}
