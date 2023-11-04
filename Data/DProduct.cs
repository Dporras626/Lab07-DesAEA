using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Data
{
    public class DProduct
    {
        public static string connectionString = "Data Source=DESKTOP-RFUO01J\\SQLEXPRESS;Initial Catalog=FacturaDB;User ID=sa;Password=123456";

        public static List<Product> ListarProducts()
        {
            List<Product> products = new List<Product>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Abrir la conexión
                connection.Open();
                string query = "ListarProductos";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Verificar si hay filas
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                // Leer los datos de cada fila
                                products.Add(new Product
                                {
                                    ProductId = (int)reader["Product_id"],
                                    Name = reader["name"].ToString(),
                                    Price = Convert.ToDecimal(reader["price"]),
                                    Stock = Convert.ToInt32(reader["stock"]),
                                    Active = (bool)reader["active"],
                                });

                            }
                        }
                    }
                }

                // Cerrar la conexión
                connection.Close();


            }
            return products;

        }

        public static void InsertarProducts(Product product)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("InsertarProducts", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@name", product.Name);
                    command.Parameters.AddWithValue("@price", product.Price);
                    command.Parameters.AddWithValue("@stock", product.Stock);
                    command.Parameters.AddWithValue("@active", product.Active);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void ActualizarProducts(Product product)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("ActualizarProducts", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Product_id", product.ProductId);
                    command.Parameters.AddWithValue("@name", product.Name);
                    command.Parameters.AddWithValue("@price", product.Price);
                    command.Parameters.AddWithValue("@stock", product.Stock);
                    command.Parameters.AddWithValue("@active", product.Active);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void EliminarProducts(int productId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("EliminarProducts", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Product_id", productId);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
