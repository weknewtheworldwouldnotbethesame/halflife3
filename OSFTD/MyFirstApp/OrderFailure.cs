public class OrderFailure // Blueprint for one failed order
{
    public int OrderId { get; set; } // Stores the order number

    public string ErrorMessage { get; set; } = ""; // Stores why it failed

    public bool IsResolved { get; set; } // true = fixed, false = not fixed
}