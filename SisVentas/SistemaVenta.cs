
namespace SisVentas
{
    internal class SistemaVenta
    {
        private List<Usuario> Usuarios = new List<Usuario>();
        private List<Producto> Productos = new List<Producto>();
        private Usuario usuarioAutenticado = null;
        private List<string> historial = null;

        public SistemaVenta()
        {
        }
        private void PauseConsole()
        {
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }
        internal void AgregarUsuario(Usuario usuario)
        {
            Usuarios.Add(usuario);
        }
        internal object AutenticarUsuario(string? email, string? contraseña)
        {
            var usuario = Usuarios.Find(u => u.Email == email);
            if (usuario != null && usuario.Autenticar(email, contraseña))
            {
                usuarioAutenticado = usuario;
                Console.WriteLine("Autenticación exitosa.");
                return usuario;
            }
            throw new Exception("Usuario no encontrado o contraseña incorrecta.");
        }
        internal void AgregarProducto(Producto producto)
        {
            if (Productos.Any(p => p.Id == producto.Id))
            {
                Console.WriteLine($"Error: Ya existe un producto con el ID {producto.Id}. No se puede agregar {producto.Nombre}.");
                return;
            }
            Productos.Add(producto);
            Console.WriteLine($"{producto.Nombre} agregado al catálogo.");
        }
        private void MostrarCatalogo()
        {
            Console.WriteLine("Catálogo de Productos:");
            foreach (var producto in Productos)
            {
                Console.WriteLine(producto);
            }
            PauseConsole();
        }
        private void IngresarProducto()
        {
            Console.Write("Ingrese el ID (Numerico) del Producto: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Ingrese el Nombre del Producto: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese el Precio del Producto: ");
            decimal precio = decimal.Parse(Console.ReadLine());

            Producto nuevoProducto = new Producto(id, nombre, precio);
            AgregarProducto(nuevoProducto);
            PauseConsole();
        }
        private void EliminarProducto()
        {
            Console.Write("Ingrese el ID del Producto a eliminar: ");
            int id = int.Parse(Console.ReadLine());
            var producto = Productos.Find(p => p.Id == id);
            if (producto != null)
            {
                Productos.Remove(producto);
                Console.WriteLine($"{producto.Nombre} ha sido eliminado.");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
            PauseConsole();
        }
        private void HandlerCarrito()
        {
            Console.Clear();
            Console.WriteLine("MODULO: Carrito");
            var carrito = new Carrito();
            while (true) {
                Console.WriteLine("Ingrese el ID del producto registrarlo al carrito");
                int id = int.Parse(Console.ReadLine());
                var producto = Productos.Find(p => p.Id == id);
                if (producto == null)
                {
                    Console.WriteLine("Producto no encontrado.");
                    return;
                }
                carrito.AgregarProductoAlCarrito(producto);
                Console.WriteLine("Digite 'Y' o 'N' respectivamente para guardar o cancelar la compra");
                Console.WriteLine("Apriete la tecla Enter para continuar agregando productos");
                char input = Console.ReadLine().ToUpper()[0];
                if (input == 'Y')
                {
                    Console.WriteLine($"Carrito #{carrito.GetID_Venta()}");
                    carrito.MostrarItemsCarrito();
                    historial.Add(carrito.ToString());
                    carrito.VaciarCarrito();
                    break;
                }
                else if (input == 'N')
                {
                    Console.WriteLine("Eliminando items del carrito...");
                    carrito.VaciarCarrito();
                    break;
                }
            }
            PauseConsole();
        }
        private void MostrarHistorial()
        {
            if (historial == null)
            {
                Console.WriteLine("Aun no has realizado ventas");
                PauseConsole();
                return;
            }
            Console.WriteLine("+--------------------+---------------------------+");
            Console.WriteLine("| ID Venta           | Valor Total              |");
            Console.WriteLine("+--------------------+---------------------------+");
            foreach (string item in historial)
            {
                // Separar los valores de ID_Venta y TotalVenta
                string[] partes = item.Split(new string[] { "ID_Venta: ", " - Valor Total: " }, StringSplitOptions.RemoveEmptyEntries);

                // Asegurarnos de que haya al menos 2 partes antes de mostrar
                if (partes.Length == 2)
                {
                    string idVenta = partes[0].Trim();
                    string valorTotal = partes[1].Trim();

                    // Mostrar en formato tabular
                    Console.WriteLine("| {0,-18} | {1,-25} |", idVenta, valorTotal);
                }
                else
                {
                    Console.WriteLine("| Error en el formato de la venta                 |");
                }
            }
            Console.WriteLine("+--------------------+---------------------------+");
            PauseConsole();
        }
        internal void MostrarMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n--- Menú ---");
                Console.WriteLine("1. Ver Catálogo de Productos");
                Console.WriteLine("2. Ingresar Producto");
                Console.WriteLine("3. Eliminar Producto");
                Console.WriteLine("4. Registrar Compra");
                Console.WriteLine("5. Ver Historial de Compras");
                Console.WriteLine("6. Salir");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        MostrarCatalogo();
                        break;
                    case "2":
                        IngresarProducto();
                        break;
                    case "3":
                        EliminarProducto();
                        break;
                    case "4":
                        HandlerCarrito();
                        break;
                    case "5":
                        MostrarHistorial();
                        break;
                    case "6":
                        Console.WriteLine("Saliendo...");
                        return;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }
    }
}
