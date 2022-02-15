using System;
using System.Linq;
using System.Threading.Tasks;
using AspectCore.DependencyInjection;
using AspectCore.DynamicProxy;
using CoreProfiler;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AOPExample.Core.Filters
{
    [AttributeUsage(AttributeTargets.Method)]
    public class LogAttribute : AbstractInterceptorAttribute
    {
        [FromServiceContext] 
        public ILogger<ProfilingAttribute> Logger { get; set; }

        private readonly string _stepName;

        public LogAttribute(string stepName)
        {
            _stepName = stepName;
        }

        public async override Task Invoke(AspectContext context, AspectDelegate next)
        {
            
            var parameter = GetParameter(context.Parameters);
            Logger.LogInformation($"{_stepName} parameter is {parameter}");

            await next(context);
            
            var response = GetResponse(context.ReturnValue);
            Logger.LogInformation($"{_stepName} response is  {response}");
            
        }

        private string GetParameter(object[] parameters)
        {
            var para = parameters.Select(x => x.ToString());
            return JsonConvert.SerializeObject(para);
        }

        private string GetResponse(object response)
        {
            return JsonConvert.SerializeObject(response);
        }
    }
}