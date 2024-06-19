# Proyecto de API en .NET para CRUD de Usuarios y Roles

## Descripción

Este proyecto es una API en .NET con C# que ejemplifica un pequeño CRUD (Crear, Leer, Actualizar, Eliminar) para la gestión de usuarios y roles en una base de datos. La API soporta operaciones básicas y avanzadas, conectándose a una base de datos SQL Server utilizando Always Encrypted con claves gestionadas en Azure Key Vault. Además, la API traduce las respuestas de los procedimientos almacenados al inglés y español según el encabezado "Accept-Languages" de la petición HTTP.

## Funcionalidades Principales

### Usuarios

- Obtener todos los usuarios
- Obtener un usuario por ID
- Crear un nuevo usuario
- Actualizar un usuario existente
- Inhabilitar un usuario
- Eliminar un usuario

### Roles

- Obtener todos los roles
- Obtener un rol por ID
- Crear un nuevo rol
- Actualizar un rol existente
- Inhabilitar un rol
- Eliminar un rol

## Otras Funcionalidades Internas

- Uso correcto de los métodos y respuestas HTTP.
- Conexión a la base de datos SQL Server utilizando Always Encrypted.
- Gestión de claves en Azure Key Vault para Always Encrypted.
- Traducción de las respuestas de los procedimientos almacenados al inglés y español según el header "Accept-Languages".

## Requisitos

- .NET 6.0 o superior
- SQL Server
- Azure Key Vault configurado para Always Encrypted

## Configuración

### Configuración de la Base de Datos

1. Crear una base de datos SQL Server.
2. Configurar Always Encrypted en la base de datos.
3. Almacenar las claves de cifrado en Azure Key Vault.
4. Crear los procedimientos almacenados necesarios para las operaciones CRUD.

### Configuración de Azure Key Vault

1. Crear un Azure Key Vault.
2. Almacenar las claves de cifrado utilizadas por Always Encrypted en Azure Key Vault.
3. Configurar los permisos adecuados para que la aplicación pueda acceder a las claves en Azure Key Vault.

### Configuración de la Aplicación

1. Clonar el repositorio:

   ```sh
   git clone https://github.com/tu_usuario/tu_repositorio.git
   cd tu_repositorio
   ```

2. Configurar la cadena de conexión en `appsettings.json`:

   ```json
   {
     "Logging": {
       "LogLevel": {
         "Default": "Information",
         "Microsoft.AspNetCore": "Warning"
       }
     },
     "ConnectionStrings": {
       "DefaultConnection": "Server=YOUR_SERVER Database=YOUR_DATABASE;User Id=YOUR_USER;Password=YOUR_PASSWORD;TrustServerCertificate=True;Column Encryption Setting = Enabled;"
     },
     "KeyVaultConfig": {
       "AkvClientId": "tu-client-id",
       "AkvClientSecretId": "tu-client-secret"
     },
     "AllowedHosts": "*"
   }
   ```

3. Restaurar las dependencias y construir el proyecto:
   ```sh
   dotnet restore
   dotnet build
   ```

## Ejecución

Para ejecutar el proyecto en modo de desarrollo: `sh dotnet run`

La API estará disponible en `https://localhost:5001` o `http://localhost:5000`.
Swagger: `http://localhost:5137/swagger/index.html`

## Endpoints

### Roles

- `GET /api/roles`: Obtener todos los roles.
- `GET /api/roles/{id}`: Obtener un rol por ID.
- `POST /api/roles`: Crear un nuevo rol.
- `PUT /api/roles/{id}`: Actualizar un rol existente.
- `PATCH /api/roles/{id}/disable`: Inhabilitar un rol.
- `DELETE /api/roles/{id}`: Eliminar un rol.

### Usuarios

- `GET /api/users`: Obtener todos los usuarios.
- `GET /api/users/{id}`: Obtener un usuario por ID.
- `POST /api/users`: Crear un nuevo usuario.
- `PUT /api/users/{id}`: Actualizar un usuario existente.
- `PATCH /api/users/{id}/disable`: Inhabilitar un usuario.
- `DELETE /api/users/{id}`: Eliminar un usuario.
