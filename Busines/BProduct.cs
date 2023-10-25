using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Data;
namespace Business
{
    public class BProduct
    {
        public List<Product> BuscarPorNombre(string name)
        {
            List<Product> products = new List<Product>();
            products = DProduct.ListarProducts();

            //foreach (var pro in products)
            //{
            //    if (pro.Name.Equals(name))
            //    {
            //        return pro;
            //    }
            //}

            return products;
        }

        public void CrearProduct(Product product)
        {
            // Validaciones u lógica de negocio, si es necesario
            DProduct.InsertarProducts(product);
        }

        public void ActualizarProduct(Product product)
        {
            // Validaciones u lógica de negocio, si es necesario
            DProduct.ActualizarProducts(product);
        }

        public void EliminarProduct(int productId)
        {
            // Validaciones u lógica de negocio, si es necesario
            DProduct.EliminarProducts(productId);
        }
    }
}