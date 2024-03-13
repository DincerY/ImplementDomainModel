
var laptop = new Product("Laptop", 2200, 10);

laptop.UpdateStockQuantity(5);

laptop.UpdatePrice(2000);

Console.ReadLine();


public class Product
{
    public int ProductId { get; private set; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public int StockQuantity { get; private set; }

    public Product(string name, decimal price, int stockQuantity)
    {
        ValidateInputs(name, price, stockQuantity);

        ProductId = CreateIndetity();
        Name = name;
        Price = price;
        StockQuantity = stockQuantity;
    }

    public void UpdateStockQuantity(int newQuantity)
    {
        ValidateStockUpdate(newQuantity);

        StockQuantity = newQuantity;
    }

    public void UpdatePrice(decimal newPrice)
    {
        ValidatePriceUpdate(newPrice);

        Price = newPrice;
    }

    private void ValidateInputs(string name, decimal price, int stockQuantity)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Ürün adı geçerli değil.");

        if (price <= 0)
            throw new ArgumentException("Ürün fiyatı geçerli değil.");

        if (stockQuantity < 0)
            throw new ArgumentException("Ürün stok miktarı geçerli değil.");
    }

    private void ValidateStockUpdate(int newQuantity)
    {
        if (newQuantity < 0)
            throw new InvalidOperationException("Geçersiz stok güncellemesi.");
    }

    private void ValidatePriceUpdate(decimal newPrice)
    {
        if (newPrice <= 0)
            throw new InvalidOperationException("Geçersiz fiyat güncellemesi.");
    }

    private int CreateIndetity()
    {
        return Random.Shared.Next();
    }
}
