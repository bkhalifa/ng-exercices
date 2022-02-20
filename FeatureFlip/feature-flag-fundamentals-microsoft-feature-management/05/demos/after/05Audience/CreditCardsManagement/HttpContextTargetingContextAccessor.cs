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
}using Microsoft.AspNetCore.Http;
using Microsoft.FeatureManagement.FeatureFilters;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CreditCardsManagement
{
    /// <summary>
    /// Provides an implementation of <see cref="ITargetingContextAccessor"/> that creates a targeting context using info from the current HTTP request.
    /// </summary>
    public class HttpContextTargetingContextAccessor : ITargetingContextAccessor
    {
        private const string TargetingContextLookup = "HttpContextTargetingContextAccessor.TargetingContext";
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpContextTargetingContextAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public ValueTask<TargetingContext> GetContextAsync()
        {
            HttpContext httpContext = _httpContextAccessor.HttpContext;

            //
            // Try cache lookup
            if (httpContext.Items.TryGetValue(TargetingContextLookup, out object value))
            {
                return new ValueTask<TargetingContext>((TargetingContext)value);
            }

            ClaimsPrincipal user = httpContext.User;

            List<string> groups = new List<string>();

            //
            // This application expects groups to be specified in the user's claims
            foreach (Claim claim in user.Claims)
            {
                if (claim.Type == ClaimTypes.GroupName)
                {
                    groups.Add(claim.Value);
                }
            }

            //
            // Build targeting context based off user info
            TargetingContext targetingContext = new TargetingContext
            {
                UserId = user.Identity.Name,
                Groups = groups
            };

            //
            // Cache for subsequent lookup
            httpContext.Items[TargetingContextLookup] = targetingContext;

            return new ValueTask<TargetingContext>(targetingContext);
        }
    }
}