using System.Collections.Generic;   // Opens the C# toolbox that contains List

// Print the dashboard heading
Console.WriteLine("Order Sync Failure Tracking Dashboard");
Console.WriteLine("-------------------------------------");

// Create the first failure object
OrderFailure failure1 = new OrderFailure();

// Fill in the first failure's properties
failure1.OrderId = 1001;
failure1.ErrorMessage = "The warehouse did not answer";
failure1.IsResolved = false;

// Create the second failure object
OrderFailure failure2 = new OrderFailure();

// Fill in the second failure's properties
failure2.OrderId = 1002;
failure2.ErrorMessage = "The product was not found";
failure2.IsResolved = true;

// Create the third failure object
OrderFailure failure3 = new OrderFailure();

// Fill in the third failure's properties
failure3.OrderId = 1003;
failure3.ErrorMessage = "The address was missing";
failure3.IsResolved = true;

// Create an empty list that holds OrderFailure objects
List<OrderFailure> failures = new List<OrderFailure>();

// Put the three failure objects into the list
failures.Add(failure1);
failures.Add(failure2);
failures.Add(failure3);

// Call the method that displays every failure
ShowAllFailures(failures);

// Call the counting method and save its answer
int unresolvedCount = CountUnresolved(failures);

// Display the totals
Console.WriteLine();
Console.WriteLine($"Total failures: {failures.Count}");
Console.WriteLine($"Unresolved failures: {unresolvedCount}");

// Call the method that resolves order 1001
ResolveFailure(failures, 1001);

// Count again because an order was changed
unresolvedCount = CountUnresolved(failures);

// Display the new count
Console.WriteLine($"Unresolved failures now: {unresolvedCount}");


// METHOD 1: Display every failure
void ShowAllFailures(List<OrderFailure> failureList)
{
    // Repeat once for every failure in the list
    foreach (OrderFailure failure in failureList)
    {
        // Print an empty line
        Console.WriteLine();

        // Print information from the current failure
        Console.WriteLine($"Order ID: {failure.OrderId}");
        Console.WriteLine($"Error: {failure.ErrorMessage}");

        // Decide which status to display
        if (failure.IsResolved == true)
        {
            Console.WriteLine("Status: Resolved");
        }
        else
        {
            Console.WriteLine("Status: Needs attention");
        }
    }
}


// METHOD 2: Count failures that are not resolved
int CountUnresolved(List<OrderFailure> failureList)
{
    // Begin counting at zero
    int count = 0;

    // Check every failure in the list
    foreach (OrderFailure failure in failureList)
    {
        // Check whether the current failure is unresolved
        if (failure.IsResolved == false)
        {
            // Add one to our count
            count = count + 1;
        }
    }

    // Give the final number back
    return count;
}


// METHOD 3: Mark one order as resolved
void ResolveFailure(
    List<OrderFailure> failureList,
    int orderId
)
{
    // Search every failure in the list
    foreach (OrderFailure failure in failureList)
    {
        // Check whether this is the requested order
        if (failure.OrderId == orderId)
        {
            // Change the order's status to resolved
            failure.IsResolved = true;

            // Tell the user what happened
            Console.WriteLine();
            Console.WriteLine($"Order {orderId} is now resolved.");

            // Stop searching because we found the order
            return;
        }
    }

    // This runs only when the order was not found
    Console.WriteLine($"Order {orderId} was not found.");
}