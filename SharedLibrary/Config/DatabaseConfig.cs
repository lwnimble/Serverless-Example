namespace ProductsApi.DependencyInjection
{
    public class DatabaseConfig
    {
        public string DatabaseURI { get; set; }
        public string DatabasePrimaryKey { get; set; }
        public string PrimaryConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
