using SisVentas;

class Program
{
    static void Main(string[] args)
    {
        var sistema = new SistemaVenta();

        // Crear usuario administrador
        sistema.AgregarUsuario(new Usuario("admin@example.com", "12345"));

        // Agregar productos predefinidos
        sistema.AgregarProducto(new Producto(1, "Laptop Dell", 1200.00m));
        sistema.AgregarProducto(new Producto(2, "MacBook Pro", 2400.00m));
        sistema.AgregarProducto(new Producto(3, "HP Pavilion", 900.00m));
        sistema.AgregarProducto(new Producto(4, "Lenovo ThinkPad", 1100.00m));

        // Flujo principal
        try
        {
            // Autenticación
            Console.WriteLine("Inicio de sesión:");
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Contraseña: ");
            string contraseña = Console.ReadLine();

            var usuario = sistema.AutenticarUsuario(email, contraseña);

            // Mostrar menú de opciones para el administrador/vendedor
            sistema.MostrarMenu();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}