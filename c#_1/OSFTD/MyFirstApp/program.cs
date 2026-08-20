Console.WriteLine("Order Sync Failure Tracking Dashboard");
Console.WriteLine("-------------------------------------");

int orderId = 1001;
string sourceSystem = "Online Store";
string destinationSystem = "Warehouse";
string errorMessage = "The Warehouse did not answer";
int retryCount = 0;
bool isResolved = false;
DateTime failedAt = DateTime.Now;

Console.WriteLine($"Order ID: {orderId}");
Console.WriteLine($"From: {sourceSystem}");
Console.WriteLine($"To: {destinationSystem}");
Console.WriteLine($"Error: {errorMessage}");
Console.WriteLine($"Retry count: {retryCount}");
Console.WriteLine($"Resolve: {isResolved}");
Console.WriteLine($"Failed at: {failedAt}");

if (isResolved == true)
{   Console.WriteLine("Status: This Failure has been fixed");
}
else
{   Console.WriteLine("Status: This Failure needs attention");
}   

