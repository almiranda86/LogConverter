using System.Threading.Tasks;
using CandidateTest.AndreLuisMiranda.Validator;
using FluentAssertions;
using Moq.AutoMock;
using Xunit;

namespace Test
{
    public class UrlFileValidator_Test
    {
        private readonly AutoMocker _autoMock;
        UrlFileValidator _urlFileValidator { get; }
        public UrlFileValidator_Test()
        {
            _autoMock = new AutoMocker();
            _urlFileValidator = new UrlFileValidator();
        }

        [Fact(DisplayName = "#1 - Should return error because the URL was not informed")]
        [Trait("Category", "Fail")]
        public async Task ReturnErrorUrlNotInformed_Test()
        {
            //Arrange
            string url = string.Empty;

            //Act
            var result = _urlFileValidator.Validate(url);

            //Assert
            result.IsValid.Should().BeFalse();
        }
    }
}
