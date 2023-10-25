using Business;
using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Presentacion
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<Product> products = DProduct.ListarProducts();


            dgSimple.ItemsSource = products;
        }
    }

    private void Crear_Click(object sender, RoutedEventArgs e)
    {
        // Abre un formulario o ventana emergente para ingresar los detalles del nuevo producto
        CrearProductoForm crearForm = new CrearProductoForm();

        if (crearForm.ShowDialog() == true)
        {
            // Obtiene los detalles del producto ingresados en el formulario
            Product nuevoProducto = crearForm.ProductoCreado;

            // Llama a la función de la capa de negocios para crear el producto
            BProduct bProduct = new BProduct();
            bProduct.CrearProduct(nuevoProducto);

            // Actualiza la lista de productos llamando a CargarProductos
            CargarProductos();
        }
    }

}