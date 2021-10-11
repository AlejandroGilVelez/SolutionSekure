using System;
using System.Runtime.CompilerServices;

namespace SC.Sekure.Domain.UseCase.DomainUseCase.Common
{
    public interface IManageEventsUseCase
    {
        /// <summary>
        /// Console information log from the whole process from base
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <param name="writeData"></param>
        /// <param name="callerMemberName"></param>
        /// <returns></returns>
        void ConsoleProcessLog(string eventName, string id, dynamic data, bool writeData = false, [CallerMemberName] string callerMemberName = null);

        /// <summary>
        /// Console error log
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        void ConsoleErrorLog(string message, Exception exception);

        /// <summary>
        /// Console information log
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        void ConsoleInfoLog(string message, params object[] args);
    }
}
