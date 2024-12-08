# Sistema de Ventas - Readme

## Descripción del Proyecto

Este proyecto es un **Sistema de Ventas** desarrollado en **C#**, diseñado para simular la gestión de productos, usuarios, carritos de compra y ventas. Permite la autenticación de usuarios, el manejo de un catálogo de productos y el seguimiento de compras realizadas.

---

## Estructura del Proyecto

### Clases Principales
1. **Carrito**
2. **Producto**
3. **Usuario**
4. **SistemaVenta**

Cada clase está diseñada para cumplir con una funcionalidad específica dentro del sistema.

---

### Clase: **Carrito**

#### Descripción:
Gestiona los productos seleccionados para una venta, incluyendo el cálculo del total y la generación de un identificador único para cada carrito.

#### Atributos y Métodos:

| **Atributos**          | **Descripción**                                                                 | **Tipo**          |
|-------------------------|---------------------------------------------------------------------------------|-------------------|
| `ID_Venta (string)`     | Identificador único generado automáticamente para cada carrito.                 | `string`          |
| `TotalVenta (decimal)`  | Total acumulado del precio de los productos en el carrito.                     | `decimal`         |
| `ListaProductos (List<Producto>)` | Lista de productos agregados al carrito.                             | `List<Producto>`  |

| **Métodos**                        | **Descripción**                                                                                         | **Tipo de Retorno** |
|------------------------------------|---------------------------------------------------------------------------------------------------------|---------------------|
| `Carrito()`                        | Constructor que inicializa un carrito y genera un ID único.                                            | `void`              |
| `GetID_Venta()`                    | Devuelve el ID único del carrito.                                                                      | `string`            |
| `GenerarID()`                      | Genera un identificador único para el carrito usando caracteres aleatorios.                           | `string`            |
| `AgregarProductoAlCarrito(Producto producto)` | Añade un producto a la lista del carrito.                                                     | `void`              |
| `MostrarItemsCarrito()`            | Muestra los productos en el carrito en formato tabular.                                                | `void`              |
| `CalcularTotalVenta()`             | Calcula el total sumando los precios de los productos en el carrito.                                   | `void`              |
| `ToString()`                       | Retorna una descripción del carrito, incluyendo el ID y el total.                                      | `string`            |
| `VaciarCarrito()`                  | Limpia todos los productos del carrito.                                                                | `void`              |

---

### Clase: **Producto**

#### Descripción:
Representa un producto dentro del catálogo del sistema.

#### Atributos y Métodos:

| **Atributos**       | **Descripción**                                           | **Tipo**        |
|---------------------|-----------------------------------------------------------|-----------------|
| `Id (int)`          | Identificador único del producto.                         | `int`           |
| `Nombre (string)`   | Nombre descriptivo del producto.                          | `string`        |
| `Precio (decimal)`  | Precio del producto.                                      | `decimal`       |

| **Métodos**                  | **Descripción**                                                                 | **Tipo de Retorno** |
|------------------------------|---------------------------------------------------------------------------------|---------------------|
| `Producto(int id, string nombre, decimal precio)` | Constructor que inicializa un producto con su ID, nombre y precio. | `void`              |
| `ToString()`                 | Retorna una descripción del producto con su ID, nombre y precio.               | `string`            |

---

### Clase: **Usuario**

#### Descripción:
Administra la autenticación de los usuarios en el sistema.

#### Atributos y Métodos:

| **Atributos**        | **Descripción**                                     | **Tipo**        |
|----------------------|-----------------------------------------------------|-----------------|
| `Email (string)`     | Dirección de correo electrónico del usuario.        | `string`        |
| `Contraseña (string)`| Contraseña del usuario.                             | `string`        |

| **Métodos**                           | **Descripción**                                                                 | **Tipo de Retorno** |
|---------------------------------------|---------------------------------------------------------------------------------|---------------------|
| `Usuario(string email, string contraseña)` | Constructor que inicializa un usuario con email y contraseña.              | `void`              |
| `Autenticar(string email, string contraseña)` | Verifica si las credenciales coinciden con las almacenadas.               | `bool`              |

---

### Clase: **SistemaVenta**

#### Descripción:
Orquesta el funcionamiento principal del sistema, permitiendo la gestión de usuarios, productos y ventas.

#### Atributos y Métodos:

| **Atributos**                 | **Descripción**                                                                 | **Tipo**          |
|-------------------------------|---------------------------------------------------------------------------------|-------------------|
| `Usuarios (List<Usuario>)`    | Lista de usuarios registrados en el sistema.                                   | `List<Usuario>`   |
| `Productos (List<Producto>)`  | Lista de productos disponibles en el catálogo.                                 | `List<Producto>`  |
| `usuarioAutenticado (Usuario)`| Usuario autenticado actualmente.                                               | `Usuario`         |
| `historial (List<string>)`    | Lista que almacena las ventas realizadas.                                      | `List<string>`    |

| **Métodos**                             | **Descripción**                                                                 | **Tipo de Retorno** |
|-----------------------------------------|---------------------------------------------------------------------------------|---------------------|
| `SistemaVenta()`                        | Constructor que inicializa el sistema.                                         | `void`              |
| `AgregarUsuario(Usuario usuario)`       | Añade un nuevo usuario al sistema.                                             | `void`              |
| `AutenticarUsuario(string email, string contraseña)`       | Autentica un usuario verificando sus credenciales.                           | `Usuario`           |
| `AgregarProducto(Producto producto)`    | Agrega un producto al catálogo.                                               | `void`              |
| `MostrarCatalogo()`                     | Muestra la lista de productos disponibles en el catálogo.                     | `void`              |
| `IngresarProducto()`                    | Permite al usuario agregar un nuevo producto al catálogo mediante la consola. | `void`              |
| `EliminarProducto()`                    | Elimina un producto del catálogo.                                             | `void`              |
| `HandlerCarrito()`                      | Gestiona las operaciones del carrito, como agregar productos y procesar ventas.| `void`              |
| `MostrarHistorial()`                    | Muestra un historial de las ventas realizadas en el sistema.                  | `void`              |
| `MostrarMenu()`                         | Presenta un menú interactivo con las opciones disponibles.                    | `void`              |

---

## Ejecución

### Flujo de Uso
1. **Inicio de Sesión**:
   - Los usuarios deben autenticar sus credenciales antes de acceder al sistema.
2. **Gestión de Productos**:
   - Los usuarios pueden agregar, eliminar y visualizar productos en el catálogo.
3. **Gestión del Carrito**:
   - Permite agregar productos al carrito, procesar ventas y vaciar el carrito.
4. **Historial de Ventas**:
   - Registra y muestra las ventas completadas, incluyendo el ID del carrito y el total de la venta.

### Requisitos
- **Framework**: .NET 6 o superior.
- **IDE Recomendado**: Visual Studio.
