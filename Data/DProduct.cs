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
                string query = "SELECT * FROM ListarProducts()";

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

    }
}
