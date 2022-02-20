using Microsoft.Extensions.Configuration;
using Microsoft.FeatureManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCards
{
    [FilterAlias("CreditCards.RandomFilter")]
    public class RandomFilter : IFeatureFilter
    {
        public Task<bool> EvaluateAsync(FeatureFilterEvaluationContext context)
        {
            RandomFilterSettings settings = context.Parameters.Get<RandomFilterSettings>();

            if (settings.Method == "Even")
            {
                return Task.FromResult(DateTime.Now.Ticks % 2 == 0);
            }

            if (settings.Method == "Odd")
            {
                return Task.FromResult(DateTime.Now.Ticks % 2 != 0);
            }

            throw new Exception($"Random feature filter configured value '{settings.Method}' is invalid, must be 'Even' or 'Odd'.");
        }
    }
}
