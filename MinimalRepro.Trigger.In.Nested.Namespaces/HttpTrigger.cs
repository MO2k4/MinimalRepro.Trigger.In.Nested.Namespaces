using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace MinimalRepro.Trigger.In.Nested.Namespaces;

public static class HttpTrigger
{
    [Function("HttpTrigger")]
    public static HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "foobar")] HttpRequestData req,
        FunctionContext executionContext)
    {
        var logger = executionContext.GetLogger("HttpTrigger");
        logger.LogInformation("C# HTTP trigger function processed a request.");

        var response = req.CreateResponse(HttpStatusCode.OK);
        response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

        response.WriteString("Welcome to Azure Functions!");

        return response;
        
    }
}