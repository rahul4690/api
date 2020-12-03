using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Filters
{
    public class MyActionFilter : IActionFilter
    {
        private ILogger<MyActionFilter> _logger;
        public MyActionFilter(ILogger<MyActionFilter> logger)
        {
            _logger = logger;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // our code before action executes
            _logger.LogInformation("OnActionExecuting");
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // our code after action executes
            _logger.LogInformation("OnActionExecuted");
        }
    }
}
