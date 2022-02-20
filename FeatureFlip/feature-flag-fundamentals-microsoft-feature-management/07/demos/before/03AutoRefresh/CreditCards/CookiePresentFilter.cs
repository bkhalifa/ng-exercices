using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.FeatureManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCards
{
    [FilterAlias("CreditCards.CookiePresentFilter")]
    public class CookiePresentFilter : IFeatureFilter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CookiePresentFilter(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public Task<bool> EvaluateAsync(FeatureFilterEvaluationContext context)
        {
            CookiePresentFilterSettings settings = context.Parameters.Get<CookiePresentFilterSettings>();

            bool isEnabled = _httpContextAccessor.HttpContext.Request.Cookies.ContainsKey(settings.CookieName);

            return Task.FromResult(isEnabled);
        }
    }
}
