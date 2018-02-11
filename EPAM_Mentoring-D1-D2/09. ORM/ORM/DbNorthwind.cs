using LinqToDB;
using ORM.Entities;

namespace ORM
{
    public class DbNorthwind : LinqToDB.Data.DataConnection
    {
        public DbNorthwind() : base("NorthwindDb") { }

        public ITable<Category> Category => GetTable<Category>();
        public ITable<Customer> Customer => GetTable<Customer>();
        public ITable<Employee> Employee => GetTable<Employee>();
        public ITable<EmployeeTerritory> EmployeeTerritory => GetTable<EmployeeTerritory>();
        public ITable<Order> Order => GetTable<Order>();
        public ITable<OrderDetail> OrderDetail => GetTable<OrderDetail>();
        public ITable<Product> Product => GetTable<Product>();
        public ITable<Region> Region => GetTable<Region>();
        public ITable<Shipper> Shipper => GetTable<Shipper>();
        public ITable<Supplier> Supplier => GetTable<Supplier>();
        public ITable<Territory> Territory => GetTable<Territory>();
    }
}
