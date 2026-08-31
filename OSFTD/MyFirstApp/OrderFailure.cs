public class OrderFailure
{
    public int OrderId { get; set; }

    public string SourceSystem { get; set; } = "";

    public string DestinationSystem { get; set; } = "";

    public string ErrorMessage { get; set; } = "";

    public int RetryCount { get; set; }

    public bool IsResolved { get; set; }

    public System.DateTime FailedAt { get; set; }
}