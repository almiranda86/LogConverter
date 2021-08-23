using CandidateTest.AndreLuisMiranda.Application.Service;
using CandidateTest.AndreLuisMiranda.Domain;
using CandidateTest.AndreLuisMiranda.Service.Behavior;
using Moq;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test
{
    public class SourceLogReader_Test
    {
        private readonly AutoMocker _autoMock;

        public SourceLogReader_Test()
        {
            _autoMock = new AutoMocker();
        }

        [Fact(DisplayName = "#1 - Given a Source content should map its value to a List of Source Model")]
        [Trait("Category", "Success")]
        public async Task ReadUrlInformed_Test()
        {
            //Arrange
            var content = @"312|200|HIT|""GET / robots.txt HTTP / 1.1""|100.2";

            _autoMock.GetMock<ISourceLogReader>().Setup(reader => reader.Read(It.IsAny<string>()))
                                                                     .ReturnsAsync(new List<SourceLogModel>());

            var sourceReades = _autoMock.CreateInstance<SourceLogReader>();

            var collSource = await sourceReades.Read(content);

            Assert.NotNull(collSource);
        }
    }
}
