using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace CPR.WebFunctions
{
    public class RetrievalFunction
    {
        private readonly ILogger _logger;

        public RetrievalFunction(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<RetrievalFunction>();
        }

        [Function("RetrievalFunction")]
        public void Run([TimerTrigger("0 * * * *")] TimerInfo myTimer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            
            if (myTimer.ScheduleStatus is not null)
            {
                _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
            }
        }
    }
}
