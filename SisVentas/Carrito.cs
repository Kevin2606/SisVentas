using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SisVentas
{
    internal class Carrito
    {
        private readonly string ID_Venta;
        private decimal TotalVenta;
        private List<Producto> ListaProductos { get; }
        public Carrito()
        {
            this.ID_Venta = Guid.NewGuid().ToString();
        }
        public string GetID_Venta()
        {
            return this.ID_Venta;
        }
        public void AgregarProductoAlCarrito(Producto producto)
        {
            this.ListaProductos.Add(producto);
            Console.WriteLine($"Se agrego al carrito: {producto.Nombre}");
        }
        public void MostrarItemsCarrito()
        {
            if (this.ListaProductos.Count == 0)
            {
                Console.WriteLine("No hay productos en el carrito");
                return;
            }
            Console.WriteLine("+------------------+----------------------------+--------------------+");
            Console.WriteLine("| ID Producto      | Nombre                    | Precio             |");
            Console.WriteLine("+------------------+----------------------------+--------------------+");

            for (int i = 0; i < this.ListaProductos.Count; i++) 
            {
                var producto = this.ListaProductos[i];
                Console.WriteLine("| {0,-16} | {1,-26} | {2,-18} |",
                    producto.Id,   // ID del producto
                    producto.Nombre, // Nombre del producto
                    producto.Precio.ToString("C")
                 );
            }
            Console.WriteLine("+------------------+----------------------------+--------------------+");

        }
        private void CalcularTotalVenta()
        {
            if (this.ListaProductos.Count == 0)
            {
                Console.WriteLine("No hay productos en el carrito");
                return;
            }
            this.TotalVenta = 0;
            for (int i = 0; i <= this.ListaProductos.Count; i++) 
            {
                this.TotalVenta = this.TotalVenta + this.ListaProductos[i].Precio;
            }
        }
        public override string ToString()
        {
            CalcularTotalVenta();
            return $"ID_Venta: {this.ID_Venta} - Valor Total: {this.TotalVenta}";
        }
        public void VaciarCarrito()
        {
            this.ListaProductos.Clear();
        }
    }
}