using AutoMapper;
using CandidateTest.AndreLuisMiranda.Application.Common;
using CandidateTest.AndreLuisMiranda.Application.Mapper.Configuration;
using CandidateTest.AndreLuisMiranda.Application.Service;
using CandidateTest.AndreLuisMiranda.Application.Service.Behavior;
using CandidateTest.AndreLuisMiranda.Domain;
using CandidateTest.AndreLuisMiranda.Handler;
using CandidateTest.AndreLuisMiranda.Handler.Behavior;
using CandidateTest.AndreLuisMiranda.Service;
using CandidateTest.AndreLuisMiranda.Service.Behavior;
using CandidateTest.AndreLuisMiranda.Validator;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CandidateTest.AndreLuisMiranda
{
    class Program
    {
        static void Main(string[] args)
        {

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            ConfigureValidator(serviceCollection);
            ConfigureMapper(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var logConversionHandler = serviceProvider.GetService<ILogConversionHandler>();

            Console.WriteLine(Messages.Wellcome);
            logConversionHandler.ConvertFromSourcetoDestiny();
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ILogConversionHandler, LogConversionHandler>()
                    .AddScoped<IDestinationLogWriter, DestinationLogWriter>()
                    .AddScoped<IURLPathReader, URLPathReader>()
                    .AddScoped<ISourceLogReader, SourceLogReader>();
        }

        public static void ConfigureValidator(IServiceCollection services)
        {
            services.AddScoped<IValidator<RequestHandlerModel>, ContentFileValidator>();
            services.AddScoped<IValidator<string>, UrlFileValidator>();
        }

        public static void ConfigureMapper(IServiceCollection services)
        {
            var mapperConfig= AutoMapperConfiguration.Register();
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
