using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace CreditCards
{
    public class SlowDownActionFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, 
                                                 ActionExecutionDelegate next)
        {
            await Task.Delay(5000);

            await next();
        }
    }
}
