var productService = new ProductService();

var laptop = productService.AddProduct("Laptop", 2000, 10);

productService.UpdateStockQuantity(laptop, 5);

productService.UpdatePrice(laptop, 2200);




Console.ReadLine();




public class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
}

public class ProductService
{
    public Product AddProduct(string name, decimal price, int stockQuantity)
    {
        ValidateInputs(name, price, stockQuantity);

        var newProduct = new Product
        {
            ProductId = GenerateUniqueId(),
            Name = name,
            Price = price,
            StockQuantity = stockQuantity
        };

        return newProduct;
    }

    public void UpdateStockQuantity(Product product, int newQuantity)
    {
        ValidateStockUpdate(newQuantity);

        product.StockQuantity = newQuantity;
    }

    public void UpdatePrice(Product product, decimal newPrice)
    {
        ValidatePriceUpdate(newPrice);

        product.Price = newPrice;
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

    private int GenerateUniqueId()
    {
        return new Random().Next();
    }
}