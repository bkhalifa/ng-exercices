using Microsoft.FeatureManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCards
{
    [FilterAlias("xyz.RandomFilter")]
    public class RandomFilter : IFeatureFilter
    {
        public Task<bool> EvaluateAsync(FeatureFilterEvaluationContext context)
        {
            // Simple/naive "random" implementation
            bool isEnabled = DateTime.Now.Ticks % 2 == 0;

            return Task.FromResult(isEnabled);
        }
    }
}
