namespace DAL.Entities
{
    public class OrderDetailHistory
    {
        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }

        public short Quantity { get; set; }

        public int Discount { get; set; }

        public decimal ExtendedPrice { get; set; }

        public override string ToString()
        {
            return $"{ProductName} {UnitPrice} {Quantity} {Discount} {ExtendedPrice}";
        }
    }
}