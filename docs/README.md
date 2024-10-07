
# Paynau JCCM Project API

Este proyecto es una aplicación API basada en .NET Core 8 que utiliza una arquitectura limpia con patrones como CQRS, Mediator, Unit of Work, y Repositories. La aplicación está diseñada para ejecutarse en contenedores Docker, y el archivo `docker-compose.yml` está configurado para ejecutar tanto la API como una base de datos MySQL.

## Requisitos Previos

Asegúrate de tener instalados los siguientes requisitos:

- **[Docker](https://www.docker.com/)**: Para ejecutar contenedores.
- **[Docker Compose](https://docs.docker.com/compose/)**: Para orquestar la ejecución de múltiples contenedores.
- **[.NET Core SDK 8](https://dotnet.microsoft.com/download/dotnet/8.0)**: Para desarrollar y ejecutar la aplicación localmente.
  
## Estructura del Proyecto

El proyecto sigue una arquitectura limpia con separación de capas, entre ellas:

- **API**: Contiene los controladores y la lógica de presentación.
- **Application**: Contiene los casos de uso (Commands y Queries) implementados mediante CQRS y el patrón Mediator.
- **Domain**: Contiene las entidades del dominio.
- **Infrastructure**: Contiene la lógica de acceso a datos, repositorios, Unit of Work y la configuración de Entity Framework Core.

## Instrucciones para Ejecutar la Aplicación

### 1. Clonar el Repositorio

Clona este repositorio en tu máquina local:

```bash
git clone https://github.com/tu-usuario/paynausjccmprojectapi.git
cd paynausjccmprojectapi
```

### 2. Ejecutar la Aplicación con Docker Compose

Para levantar la aplicación junto con la base de datos MySQL, simplemente ejecuta el siguiente comando:

```bash
docker-compose up --build
```

Esto hará lo siguiente:

1. Construirá la imagen de la API desde el `Dockerfile` ubicado en `src/paynau.jccm.project.Api/`.
2. Levantará un contenedor para la base de datos MySQL (versión 8.4) con la contraseña `Admin2024` para el usuario root.
3. Expondrá la API en el puerto `8080` y MySQL en el puerto `3306`.

### 3. Variables de Entorno

La conexión a la base de datos MySQL está configurada mediante la variable de entorno `ConnectionStrings__ConexionMySql`. En este caso, la conexión apunta a:

- **Servidor**: `mysql` (el nombre del servicio dentro del contenedor Docker)
- **Usuario**: `root`
- **Contraseña**: `Admin2024`
- **Base de datos**: `paynau_db`

Estas variables están definidas en el archivo `docker-compose.yml` bajo el servicio `paynau.jccm.project.api`:

```yaml
environment:
  - ASPNETCORE_ENVIRONMENT=Development
  - >-
    ConnectionStrings__ConexionMySql=server=mysql;user=root;password=Admin2024;database=paynau_db;
```

### 4. Verificación

Una vez que los contenedores estén en ejecución, puedes acceder a la API en:

```
http://localhost:8080
```

### 5. Volúmenes Persistentes

La base de datos MySQL utiliza un volumen Docker para persistir los datos, incluso si los contenedores son eliminados. El volumen está configurado como:

```yaml
volumes:
  mysql_data:/var/lib/mysql
```

## Migraciones de Base de Datos

Si realizas cambios en las entidades del dominio, deberás generar nuevas migraciones para mantener la base de datos sincronizada. Para crear una migración, asegúrate de tener la API configurada correctamente y ejecuta:

```bash
dotnet ef migrations add NombreDeLaMigracion -o Data/Migrations
```

Luego, para aplicar las migraciones, ejecuta:

```bash
dotnet ef database update
```

> Nota: Debes tener el paquete `Microsoft.EntityFrameworkCore.Tools` instalado para usar el comando `ef`.

## Testing

Este proyecto sigue principios de **TDD** (Test-Driven Development). Asegúrate de crear tus pruebas unitarias utilizando xUnit, Moq, o cualquier otro framework de pruebas que prefieras. Puedes encontrar los tests en la carpeta `/Tests`.

Para ejecutar los tests:

```bash
dotnet test
```

## Limpieza

Para detener y eliminar los contenedores, ejecuta:

```bash
docker-compose down
```

Si también deseas eliminar los volúmenes:

```bash
docker-compose down --volumes
```

## Contribución

Si deseas contribuir a este proyecto, por favor crea un **pull request** con una descripción detallada de los cambios.
