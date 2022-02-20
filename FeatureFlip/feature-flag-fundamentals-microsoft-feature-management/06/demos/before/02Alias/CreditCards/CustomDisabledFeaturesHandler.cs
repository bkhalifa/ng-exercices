using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.FeatureManagement.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CreditCards
{
    internal class CustomDisabledFeaturesHandler : IDisabledFeaturesHandler
    {
        public Task HandleDisabledFeatures(IEnumerable<string> features, ActionExecutingContext context)
        {
            // Log error

            // For demo purposes only, do not expose sensitive information which may include feature names
            var message = $"The following features are not available at this time: {string.Join(',',features)}";
            
            context.Result = new ContentResult()
            {
                ContentType = "text/plain",
                Content = message,
                StatusCode = 404
            };
            
            return Task.CompletedTask;
        }
    }
}