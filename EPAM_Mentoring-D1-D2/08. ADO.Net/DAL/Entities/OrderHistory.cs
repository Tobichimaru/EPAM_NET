namespace DAL.Entities
{
    public class OrderHistory
    {
        public string ProductName { get; set; }

        public int Total { get; set; }

        public override string ToString()
        {
            return $"{ProductName} {Total}";
        }
    }
}