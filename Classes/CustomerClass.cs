public class Customer
{
    public string Name {get;set;}
    public decimal TotalRevenue {get;set;}

    public override string ToString()
    {
        return $"Name: {Name}, Total revenue: {TotalRevenue}";
    }
}