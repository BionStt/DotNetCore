using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DotNetCore.Logging.Tests
{
    [TestClass]
    public class LoggingTests
    {
        private readonly ILogService _logService;

        public LoggingTests()
        {
            var services = new ServiceCollection();

            var configuration = new ConfigurationBuilder().AddJsonFile("AppSettings.json").Build();

            services.AddSingleton<IConfiguration>(configuration);
            services.AddSingleton<ILogService, LogService>();

            _logService = services.BuildServiceProvider().GetService<ILogService>();
        }

        private object Data { get; } = new { Id = 1, Name = "Name" };

        [TestMethod]
        public void Debug()
        {
            _logService.Debug(nameof(Debug));
        }

        [TestMethod]
        public void DebugData()
        {
            _logService.Debug(nameof(DebugData), Data);
        }

        [TestMethod]
        public void ErrorException()
        {
            _logService.Error(new ArgumentNullException());
        }

        [TestMethod]
        public void ErrorExceptionData()
        {
            _logService.Error(new ArgumentNullException(), Data);
        }

        [TestMethod]
        public void ErrorMessage()
        {
            _logService.Error(nameof(ErrorMessage));
        }

        [TestMethod]
        public void ErrorMessageData()
        {
            _logService.Error(nameof(ErrorMessageData), Data);
        }

        [TestMethod]
        public void Fatal()
        {
            _logService.Fatal(new Exception(nameof(Fatal)));
        }

        [TestMethod]
        public void FatalData()
        {
            _logService.Fatal(new Exception(nameof(FatalData)), Data);
        }

        [TestMethod]
        public void Information()
        {
            _logService.Information(nameof(Information));
        }

        [TestMethod]
        public void InformationData()
        {
            _logService.Information(nameof(InformationData), Data);
        }

        [TestMethod]
        public void InformationDataChange()
        {
            _logService.Information("Begin", 1);
            _logService.Information("Change", 2);
            _logService.Information("End", 3);
        }

        [TestMethod]
        public void Warning()
        {
            _logService.Warning(nameof(Warning));
        }

        [TestMethod]
        public void WarningData()
        {
            _logService.Warning(nameof(WarningData), Data);
        }
    }
}
