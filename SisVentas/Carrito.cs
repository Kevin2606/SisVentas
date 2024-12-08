using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SisVentas
{
    internal class Carrito
    {
        private readonly string ID_Venta;
        private decimal TotalVenta;
        private List<Producto> ListaProductos = new List<Producto>();
        public Carrito()
        {
            ID_Venta = GenerarID();
        }
        public string GetID_Venta()
        {
            return ID_Venta;
        }
        private static string GenerarID()
        {
            const string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            char[] id = new char[6];

            for (int i = 0; i < id.Length; i++)
            {
                id[i] = caracteres[random.Next(caracteres.Length)];
            }

            return new string(id);
        }
        public void AgregarProductoAlCarrito(Producto producto)
        {
            ListaProductos.Add(producto);
            Console.WriteLine($"Se agrego al carrito: {producto.Nombre}");
        }
        public void MostrarItemsCarrito()
        {
            if (ListaProductos.Count == 0)
            {
                Console.WriteLine("No hay productos en el carrito");
                return;
            }
            Console.WriteLine("+------------------+----------------------------+--------------------+");
            Console.WriteLine("| ID Producto      | Nombre                    | Precio             |");
            Console.WriteLine("+------------------+----------------------------+--------------------+");

            for (int i = 0; i < ListaProductos.Count; i++) 
            {
                var producto = ListaProductos[i];
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
            if (ListaProductos.Count == 0)
            {
                Console.WriteLine("No hay productos en el carrito");
                return;
            }
            TotalVenta = 0;
            for (int i = 0; i < ListaProductos.Count; i++) 
            {
                TotalVenta = TotalVenta + ListaProductos[i].Precio;
            }
        }
        public override string ToString()
        {
            try
            {
                CalcularTotalVenta();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al calcular el total de la venta: {ex.Message}");
                return "Error al generar la descripción de la venta.";
            }
            return $"ID_Venta: {ID_Venta} - Valor Total: {TotalVenta}";
        }
        public void VaciarCarrito()
        {
            ListaProductos.Clear();
        }
    }
}