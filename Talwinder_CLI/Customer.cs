// --- Customer Class ---
// This just holds the customer's info.
public class Customer
{
    public int CustomerNumber { get; set; }
    public string Name { get; set; }
    public string ContactDetails { get; set; }
    public bool IsStaff { get; set; } // To check if they get a discount on fees
}
