using Microsoft.AspNetCore.Http;
using Microsoft.FeatureManagement.FeatureFilters;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CreditCardsManagement
{
    /// <summary>
    /// Simplified version based on https://github.com/microsoft/FeatureManagement-Dotnet/blob/master/examples/FeatureFlagDemo/HttpContextTargetingContextAccessor.cs
    /// </summary>
    public class HttpTargetingContextAccessor : ITargetingContextAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpTargetingContextAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public ValueTask<TargetingContext> GetContextAsync()
        {
            HttpContext httpContext = _httpContextAccessor.HttpContext;

            ClaimsPrincipal user = httpContext.User;

            TargetingContext targetingContext = new TargetingContext
            {
                UserId = user.Identity.Name,
                Groups = GetGroupsFromClaims(user)
            };

            return new ValueTask<TargetingContext>(targetingContext);
        }

        private static IEnumerable<string> GetGroupsFromClaims(ClaimsPrincipal user)
        {
            // In this implementation groups/roles are specified using claims (ClaimTypes.Role)
            foreach (Claim claim in user.Claims)
            {
                if (claim.Type == ClaimTypes.Role)
                {
                    yield return claim.Value;
                }
            }
        }
    }
}