using AutoMapper;
using CandidateTest.AndreLuisMiranda.Application.Common;
using CandidateTest.AndreLuisMiranda.Domain;
using CandidateTest.AndreLuisMiranda.Handler.Behavior;
using CandidateTest.AndreLuisMiranda.Service.Behavior;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidateTest.AndreLuisMiranda.Handler
{
    public class LogConversionHandler : ILogConversionHandler
    {
        private readonly IValidator<string> _validatorURL;
        private readonly IValidator<RequestHandlerModel> _contentValidator;
        private readonly IURLPathReader _urlPathReader;
        private readonly ISourceLogReader _sourceReader;
        private readonly IDestinationLogWriter _destinyWriter;
        private readonly IMapper _mapper;

        public LogConversionHandler(IValidator<string> validatorURL,
                                    IValidator<RequestHandlerModel> contentValidator,
                                    IURLPathReader urlPathReader,
                                    ISourceLogReader sourceReader,
                                    IDestinationLogWriter destinyWriter,
                                    IMapper mapper)
        {
            _validatorURL = validatorURL;
            _contentValidator = contentValidator;
            _urlPathReader = urlPathReader;
            _destinyWriter = destinyWriter;
            _sourceReader = sourceReader;
            _mapper = mapper;
        }

        public async Task ConvertFromSourcetoDestiny()
        {
            var requestModel = new RequestHandlerModel();

            try
            {
                Console.WriteLine(Messages.EnterUrl);
                var urlPath = Console.ReadLine();

                Console.WriteLine(Messages.WaitForValidation);

                var validationPath = _validatorURL.Validate(urlPath);

                if (!validationPath.IsValid)
                {
                    Console.WriteLine(Messages.NoPathInformed);
                    return;
                }

                requestModel.Content = await _urlPathReader.Read(urlPath);

                var validationContent = _contentValidator.Validate(requestModel);

                if (!validationContent.IsValid)
                {
                    Console.WriteLine(Messages.WrongFormat);
                    return;
                }

                Console.WriteLine(Messages.FileIsValid);

                var collSourceLog = await _sourceReader.Read(requestModel.Content);

                if (collSourceLog.Count > 0)
                {
                    List<DestinationLogModel> collDestiny = _mapper.Map<List<SourceLogModel>, List<DestinationLogModel>>(collSourceLog);

                    var responseWrite = await _destinyWriter.Write(collDestiny);
                    Console.WriteLine($"File created! See at - {responseWrite}");
                }
                else
                {
                    Console.WriteLine($"{Messages.NoContent}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            finally
            {
                Console.WriteLine($"{Messages.EndProgram}");
            }
        }
    }
}
