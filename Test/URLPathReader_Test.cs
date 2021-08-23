using CandidateTest.AndreLuisMiranda.Service;
using CandidateTest.AndreLuisMiranda.Service.Behavior;
using Moq;
using Moq.AutoMock;
using System.Threading.Tasks;
using Xunit;

namespace Test
{
    public class URLPathReader_Test
    {
        private readonly AutoMocker _autoMock;

        public URLPathReader_Test()
        {
            _autoMock = new AutoMocker();
        }

        [Fact(DisplayName = "#1 - Given an Url should return its content")]
        [Trait("Category", "Success")]
        public async Task ReadUrlInformed_Test()
        {
            //Arrange
            var path = @"https://s3.amazonaws.com/uux-itaas-static/minha-cdn-logs/input-01.txt";

            _autoMock.GetMock<IURLPathReader>().Setup(reader =>reader.Read(It.IsAny<string>()))
                                               .ReturnsAsync(It.IsAny<string>());

            var urlPathReader = _autoMock.CreateInstance<URLPathReader>();

            //Act
            var content = await urlPathReader.Read(path);

            //Assert
            Assert.NotNull(content);
        }
    }
}
