namespace WebStore.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public void ApplyPercentageDiscount(int percentageDiscount)
        {
            Price -= Math.Round(Price * percentageDiscount / 100, 2);
        }

        public bool PlaceBulkOrder(int orderQuantity)
        {
            if (orderQuantity > Quantity)
            {
                return false;
            }

            Quantity -= orderQuantity;
            return true;
        }
    }
}
