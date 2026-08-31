using System.Collections.Generic;

Console.WriteLine("Order Sync Failure Tracking Dashboard");
Console.WriteLine("=====================================");

List<OrderFailure> failures = new List<OrderFailure>();

OrderFailure failure1 = new OrderFailure
{
    OrderId = 1001,
    SourceSystem = "Online Store",
    DestinationSystem = "Warehouse",
    ErrorMessage = "The warehouse did not answer",
    RetryCount = 0,
    IsResolved = false,
    FailedAt = System.DateTime.Now
};

OrderFailure failure2 = new OrderFailure
{
    OrderId = 1002,
    SourceSystem = "Amazon",
    DestinationSystem = "Inventory System",
    ErrorMessage = "Product was not found",
    RetryCount = 2,
    IsResolved = false,
    FailedAt = System.DateTime.Now
};

OrderFailure failure3 = new OrderFailure
{
    OrderId = 1003,
    SourceSystem = "Online Store",
    DestinationSystem = "Shipping System",
    ErrorMessage = "The address was missing",
    RetryCount = 1,
    IsResolved = true,
    FailedAt = System.DateTime.Now
};

failures.Add(failure1);
failures.Add(failure2);
failures.Add(failure3);

ShowAllFailures(failures);

int unresolvedCount = CountUnresolved(failures);

Console.WriteLine($"Total failures: {failures.Count}");
Console.WriteLine($"Unresolved failures: {unresolvedCount}");

Console.WriteLine();
Console.WriteLine("Resolving order 1001...");

MarkAsResolved(failures, 1001);

unresolvedCount = CountUnresolved(failures);

Console.WriteLine($"Unresolved failures now: {unresolvedCount}");

void ShowAllFailures(List<OrderFailure> failureList)
{
    foreach (OrderFailure failure in failureList)
    {
        Console.WriteLine();
        Console.WriteLine("------------------------------");
        Console.WriteLine($"Order ID: {failure.OrderId}");
        Console.WriteLine($"From: {failure.SourceSystem}");
        Console.WriteLine($"To: {failure.DestinationSystem}");
        Console.WriteLine($"Error: {failure.ErrorMessage}");
        Console.WriteLine($"Retries: {failure.RetryCount}");
        Console.WriteLine($"Failed at: {failure.FailedAt}");

        if (failure.IsResolved == true)
        {
            Console.WriteLine("Status: Resolved");
        }
        else
        {
            Console.WriteLine("Status: Needs attention");
        }
    }

    Console.WriteLine();
    Console.WriteLine("------------------------------");
}

int CountUnresolved(List<OrderFailure> failureList)
{
    int count = 0;

    foreach (OrderFailure failure in failureList)
    {
        if (failure.IsResolved == false)
        {
            count = count + 1;
        }
    }

    return count;
}

void MarkAsResolved(List<OrderFailure> failureList, int orderId)
{
    foreach (OrderFailure failure in failureList)
    {
        if (failure.OrderId == orderId)
        {
            failure.IsResolved = true;
            Console.WriteLine($"Order {orderId} is now resolved.");
            return;
        }
    }

    Console.WriteLine($"Order {orderId} was not found.");
}