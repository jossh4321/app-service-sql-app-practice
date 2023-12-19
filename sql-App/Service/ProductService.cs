using sql_App.Models;
using System.Data.SqlClient;

namespace sql_App.Service
{
    public class ProductService : IProductService
    {
        private readonly string db_server = "sqlapp200.database.windows.net";
        private readonly string db_usr = "sqlusr";
        private readonly string db_password = "PR1M4V3R42023..";
        private readonly string db_database = "sql-app";

        private IConfiguration configuration;

        public ProductService(IConfiguration config)
        {
            configuration = config;
        }

        private SqlConnection getConnection()
        {
            /*SqlConnectionStringBuilder connBuilder  = new SqlConnectionStringBuilder();
            connBuilder.DataSource = db_server;
            connBuilder.UserID = db_usr;
            connBuilder.Password = db_password;
            connBuilder.InitialCatalog = db_database;
            return new SqlConnection(connBuilder.ConnectionString);*/
            return new SqlConnection(configuration.GetConnectionString("SqlConnection"));
        }

        public List<Product> getAllProducts()
        {
            List<Product> productList = new List<Product>();
            SqlConnection conn = getConnection();
            string statmentQuery = "SELECT * FROM PRODUCTS";
            SqlCommand sqlCommand = new SqlCommand(statmentQuery, conn);
            conn.Open();
            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            while (dataReader.Read())
            {
                productList.Add(new Product()
                {
                    ProductID = dataReader.GetInt32(0),
                    ProductName = dataReader.GetString(1),
                    Quantity = dataReader.GetInt32(2)
                });
            }
            conn.Close();
            return productList;
        }
    }
}
