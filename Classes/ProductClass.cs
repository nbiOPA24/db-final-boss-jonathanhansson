public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Stock { get; set; }
    public float Price { get; set; }

    public override string ToString()
    {
        return $"Product: {Name}\nStock: {Stock}st\nPrice: {Price}kr/st\n";
    }
}