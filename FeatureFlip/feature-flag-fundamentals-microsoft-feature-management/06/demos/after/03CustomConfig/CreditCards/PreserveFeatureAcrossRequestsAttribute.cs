using System;

namespace CreditCards
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public sealed class PreserveFeatureAcrossRequestsAttribute : Attribute 
    {
    }
}
