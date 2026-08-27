Console.WriteLine("Order Sync Failure Tracking Dashboard");
Console.WriteLine("-------------------------------------");

int orderId = 2050;
string sourceSystem = "Amazon";
string destinationSystem = "Inventory System";
string errorMessage = "Product was not found";
int retryCount = 3;
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

