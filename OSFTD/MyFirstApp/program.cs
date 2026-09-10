using System.Collections.Generic; // Read: Open the toolbox containing List
using System.IO;                  // LESSON 4 — Read: Open the file toolbox
using System.Text.Json;           // LESSON 4 — Read: Open the JSON toolbox




Console.WriteLine("Order Sync Failure Tracking Dashboard"); // Read: Print the dashboard name
Console.WriteLine("-------------------------------------"); // Read: Print a divider




OrderFailure failure1 = new OrderFailure(); // Read: Create a new OrderFailure called failure1

failure1.OrderId = 1001; // Read: Put 1001 into failure1's OrderId
failure1.ErrorMessage = "The warehouse did not answer"; // Read: Give failure1 this error
failure1.IsResolved = false; // Read: Mark failure1 as not resolved




OrderFailure failure2 = new OrderFailure(); // Read: Create another OrderFailure called failure2

failure2.OrderId = 1002; // Read: Put 1002 into failure2's OrderId
failure2.ErrorMessage = "The product was not found"; // Read: Give failure2 this error
failure2.IsResolved = true; // Read: Mark failure2 as resolved



OrderFailure failure3 = new OrderFailure(); // Read: Create another OrderFailure called failure3

failure3.OrderId = 1003; // Read: Put 1003 into failure3's OrderId
failure3.ErrorMessage = "The address was missing"; // Read: Give failure3 this error
failure3.IsResolved = true; // Read: Mark failure3 as resolved





List<OrderFailure> failures = new List<OrderFailure>(); // Read: Create an empty list for OrderFailure objects

failures.Add(failure1); // Read: Add failure1 to the failures list
failures.Add(failure2); // Read: Add failure2 to the failures list
failures.Add(failure3); // Read: Add failure3 to the failures list

ShowAllFailures(failures); // Read: Show every failure inside the failures list




int unresolvedCount = CountUnresolved(failures); // Read: Count unresolved failures and save the answer

Console.WriteLine(); // Read: Print an empty line
Console.WriteLine($"Total failures: {failures.Count}"); // Read: Print how many failures are in the list
Console.WriteLine($"Unresolved failures: {unresolvedCount}"); // Read: Print the unresolved count


ResolveFailure(failures, 1001); // Read: Find order 1001 in the list and resolve it
unresolvedCount = CountUnresolved(failures); // Read: Count unresolved failures again



Console.WriteLine($"Unresolved failures now: {unresolvedCount}"); // Read: Print the new count


SaveFailures(failures, "failures.json"); // LESSON 4 — Read: Save the list in failures.json



void ShowAllFailures(List<OrderFailure> failureList) // Read: Create a method that displays a failure list
{
    foreach (OrderFailure failure in failureList) // Read: Look at each failure in the list, one at a time
    {
        Console.WriteLine(); // Read: Print an empty line

        Console.WriteLine($"Order ID: {failure.OrderId}"); // Read: Print the current failure's OrderId
        Console.WriteLine($"Error: {failure.ErrorMessage}"); // Read: Print the current failure's error

        if (failure.IsResolved == true) // Read: If the current failure is resolved
        {
            Console.WriteLine("Status: Resolved"); // Read: Print Resolved
        }
        else // Read: Otherwise, if it is not resolved
        {
            Console.WriteLine("Status: Needs attention"); // Read: Print Needs attention
        }
    }
}



int CountUnresolved(List<OrderFailure> failureList) // Read: Create a method that returns an unresolved count
{
    int count = 0; // Read: Start the count at zero

    foreach (OrderFailure failure in failureList) // Read: Look at each failure in the list
    {
        if (failure.IsResolved == false) // Read: If the current failure is not resolved
        {
            count = count + 1; // Read: Add one to the count
        }
    }

    return count; // Read: Give the finished count back
}



void ResolveFailure(List<OrderFailure> failureList, int orderId) // Read: Create a method that resolves one order
{
    foreach (OrderFailure failure in failureList) // Read: Search each failure in the list
    {
        if (failure.OrderId == orderId) // Read: If the two order numbers are equal
        {
            failure.IsResolved = true; // Read: Change this failure to resolved

            Console.WriteLine(); // Read: Print an empty line
            Console.WriteLine($"Order {orderId} is now resolved."); // Read: Print which order was resolved

            return; // Read: Stop this method because the order was found
        }
    }

    Console.WriteLine($"Order {orderId} was not found."); // Read: Print this if no matching order exists
}



// LESSON 4: This method saves failures into a JSON file
void SaveFailures(List<OrderFailure> failureList, string fileName) // Read: Create a method that saves a list into a file
{
    JsonSerializerOptions options = new JsonSerializerOptions(); // Read: Create settings for the JSON writer

    options.WriteIndented = true; // Read: Make the JSON neat and easy to read

    string json = JsonSerializer.Serialize(failureList, options); // Read: Turn the failure objects into JSON text

    File.WriteAllText(fileName, json); // Read: Write all the JSON text into the file

    Console.WriteLine($"Failures saved to {fileName}."); // Read: Tell the user that saving worked
}