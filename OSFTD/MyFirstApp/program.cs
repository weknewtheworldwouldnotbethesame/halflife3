using System.Collections.Generic;

Console.WriteLine("Order Sync Failure Tracking Dashboard");
Console.WriteLine("-------------------------------------");

OrderFailure failure1 = new OrderFailure();

failure1.OrderId = 1001;
failure1.ErrorMessage = "The warehouse did not answer";
failure1.IsResolved = false;

OrderFailure failure2 = new OrderFailure();

failure2.OrderId = 1002;
failure2.ErrorMessage = "The product was not found";
failure2.IsResolved = true;

OrderFailure failure3 = new OrderFailure();

failure3.OrderId = 1003;
failure3.ErrorMessage = "The product was not found";
failure3.IsResolved = true;

List<OrderFailure> failures = new List<OrderFailure>();

failures.Add(failure1);
failures.Add(failure2);
failures.Add(failure3);

Console.WriteLine($"Total failures: {failures.Count}");

foreach (OrderFailure failure in failures)
{
    Console.WriteLine();
    Console.WriteLine($"Order ID: {failure.OrderId}");
    Console.WriteLine($"Error: {failure.ErrorMessage}");

    if (failure.IsResolved == true)
    {
        Console.WriteLine("Status: Resolved");
    }
    else
    {
        Console.WriteLine("Status: Needs attention");
    }
}