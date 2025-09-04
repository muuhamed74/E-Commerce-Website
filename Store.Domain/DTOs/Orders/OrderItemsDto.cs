namespace Store.Domain.DTOs.Orders
{
    public class OrderItemsDto
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductImages { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}