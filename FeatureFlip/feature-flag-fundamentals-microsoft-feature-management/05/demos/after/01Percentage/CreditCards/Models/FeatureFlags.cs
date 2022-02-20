namespace CreditCards.Models
{
    public enum FeatureFlags
    {
        [PreserveFeatureAcrossRequests]
        Printing,
        PrintPreview,
        SlowDown
    }
}
