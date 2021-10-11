using Microsoft.Extensions.Logging;
using System;
using System.Runtime.CompilerServices;

namespace SC.Sekure.Domain.UseCase.DomainUseCase.Common
{
    /// <summary>
    /// ManageEventsUseCase
    /// </summary>
    public class ManageEventsUseCase : IManageEventsUseCase
    {
        private readonly ILogger<ManageEventsUseCase> _logger;
        /// <summary>
        /// ManageEventsUseCase
        /// </summary>
        /// <param name="logger"></param>
        public ManageEventsUseCase(ILogger<ManageEventsUseCase> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// <see cref="IManageEventsUseCase.ConsoleProcessLog(string, string, dynamic, bool, string)"/>
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <param name="writeData"></param>
        /// <param name="callerMemberName"></param>
        /// <returns></returns>
        public void ConsoleProcessLog(string eventName, string id, dynamic data, bool writeData = false, [CallerMemberName] string callerMemberName = null)
        {
            _logger.LogInformation($"ClassName: {eventName} - MethodName: {callerMemberName} - Id: {id}");

            if (writeData)
                _logger.LogInformation($"Data: {data}");

        }


        /// <summary>
        /// <see cref="IManageEventsUseCase.ConsoleErrorLog(string, Exception)"/>
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public void ConsoleErrorLog(string message, Exception exception)
        {
            _logger.LogError("ERROR - {message} :: {@exception}", message, exception);
        }

        /// <summary>
        /// <see cref="IManageEventsUseCase.ConsoleInfoLog(string, object[])"/>
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public void ConsoleInfoLog(string message, params object[] args)
        {
            _logger.LogInformation("INFORMATION - {message} :: {@data}", message, args);
        }

    }
}
