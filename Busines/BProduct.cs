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
        public Product BuscarPorNombre(string name)
        {
            List<Product> products = new List<Product>();
            products = DProduct.ListarProducts();

            foreach (var pro in products)
            {
                if (pro.Name.Equals(name))
                {
                    return pro;
                }
            }

            return null;
        }
    }
}