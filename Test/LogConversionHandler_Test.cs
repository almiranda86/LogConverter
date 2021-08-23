using CandidateTest.AndreLuisMiranda.Domain;
using CandidateTest.AndreLuisMiranda.Handler;
using CandidateTest.AndreLuisMiranda.Service.Behavior;
using FluentValidation;
using FluentValidation.Results;
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
    public class LogConversionHandler_Test
    {
        private readonly AutoMocker _autoMock;
        public LogConversionHandler_Test()
        {
            _autoMock = new AutoMocker();
        }

        [Fact(DisplayName = "#1 - Validate the main flow of the Handler")]
        [Trait("Category", "Success")]
        public async Task ProcessLogConversion_Test()
        {
            //Arrange
            var urlPath = new StringReader(@"AAA");
            var content = new StringReader(@"BBB");
            var noContent = new StringWriter();
            Console.SetIn(urlPath);
            Console.SetOut(noContent);

            var requestHandlerModel = _autoMock.GetMock<RequestHandlerModel>();
            requestHandlerModel.Object.Content = content.ReadLine();

            var collDestiny = _autoMock.GetMock<List<DestinationLogModel>>();

            _autoMock.GetMock<IValidator<string>>().Setup(validator => validator.Validate(urlPath.ReadLine()))
                                                   .Returns(new ValidationResult());

            _autoMock.GetMock<IValidator<RequestHandlerModel>>().Setup(validator => validator.Validate(It.IsAny<RequestHandlerModel>()))
                                                                .Returns(new ValidationResult());


            _autoMock.GetMock<IURLPathReader>().Setup(reader => reader.Read(urlPath.ReadLine()))
                                               .ReturnsAsync(content.ReadLine());

            _autoMock.GetMock<ISourceLogReader>().Setup(reader => reader.Read(It.IsAny<string>()))
                                                .ReturnsAsync(new List<SourceLogModel>());


            _autoMock.GetMock<IDestinationLogWriter>().Setup(writer => writer.Write(collDestiny.Object))
                                             .ReturnsAsync(It.IsAny<string>);


            var logConversionHandler = _autoMock.CreateInstance<LogConversionHandler>();

            //Act
            await logConversionHandler.ConvertFromSourcetoDestiny();

            //Assert

        }
    }
}
