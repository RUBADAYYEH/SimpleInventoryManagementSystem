namespace SimpleInventoryManagementSystem.Domain.ProductManagement
{
    public class Product
    {
        public int ProductId { get; init; }
        public string? ProductName { get; set; }
        public int? Quantity { get; set; }
        public double Price { get; set; }

        public string Description {  get; set; } = string.Empty;

        public override string ToString()
        {
            if(Quantity == default) return string.Empty;

            return $"{ProductId};{ProductName};{Quantity};{Price};"+ " ";  
            
        }
    }
}
