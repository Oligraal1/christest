using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Company.Function
{
    public class HttpTrigger1
    {
        private readonly ILogger<HttpTrigger1> _logger;

        public HttpTrigger1(ILogger<HttpTrigger1> logger)
        {
            _logger = logger;
        }

        [Function("HttpTrigger1")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
        {
             _logger.LogInformation("C# HTTP trigger function processed a request.");

            string firstName = req.Query["firstName"];
            string lastName = req.Query["lastName"];

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                return new BadRequestObjectResult("Please pass both firstName and lastName in the query string.");
            }

            var user = new { firstName = firstName, lastName = lastName };

            return new OkObjectResult(user);
        }
    }
}
