using System.Threading.Tasks;
using CandidateTest.AndreLuisMiranda.Domain;
using CandidateTest.AndreLuisMiranda.Validator;
using FluentAssertions;
using Moq.AutoMock;
using Xunit;

namespace Test
{
    public class ContentFileValidator_Test
    {
        private readonly AutoMocker _autoMock;
        ContentFileValidator _contentFileValidator { get; }
        public ContentFileValidator_Test()
        {
            _autoMock = new AutoMocker();
            _contentFileValidator = new ContentFileValidator();
        }

        [Fact(DisplayName = "#1 - Should return error because the content was not informed")]
        [Trait("Category", "Fail")]
        public async Task ReturnErrorContentNotInformed_Test()
        {
            //Arrange
            var requestHandlerModel = _autoMock.GetMock<RequestHandlerModel>();
            requestHandlerModel.Object.Content = string.Empty;

            //Act
            var result = _contentFileValidator.Validate(requestHandlerModel.Object);

            //Assert
            result.IsValid.Should().BeFalse();
        }

        [Fact(DisplayName = "#2 - Should return error because the content was informed but it is not in the correct format")]
        [Trait("Category", "Fail")]
        public async Task ReturnErrorContenInformedIncorrectFormat_Test()
        {
            //Arrange
            var requestHandlerModel = _autoMock.GetMock<RequestHandlerModel>();
            requestHandlerModel.Object.Content = "content";

            //Act
            var result = _contentFileValidator.Validate(requestHandlerModel.Object);

            //Assert
            result.IsValid.Should().BeFalse();
        }

        [Fact(DisplayName = "#3 - Should return success because the content was informed and it is in the correct format")]
        [Trait("Category", "Success")]
        public async Task ReturnSuccessContenInformedCorrectFormat_Test()
        {
            //Arrange
            var requestHandlerModel = _autoMock.GetMock<RequestHandlerModel>();
            requestHandlerModel.Object.Content = @"312|200|HIT|""GET / robots.txt HTTP / 1.1""|100.2";


            //Act
            var result = _contentFileValidator.Validate(requestHandlerModel.Object);

            //Assert
            result.IsValid.Should().BeTrue();
        }
    }
}
