using Microsoft.AspNetCore.Http;
using Microsoft.FeatureManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCards
{
    [FilterAlias("CreditCards.BetaCookieFilter")]
    public class BetaCookieFilter : IFeatureFilter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BetaCookieFilter(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public Task<bool> EvaluateAsync(FeatureFilterEvaluationContext context)
        {
            bool isEnabled = _httpContextAccessor.HttpContext
                                                 .Request
                                                 .Cookies.ContainsKey("beta");

            return Task.FromResult(isEnabled);
        }
    }
}
