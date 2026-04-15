# 🚗 Sistema de inventario.

Este proyecto es una solución integral desarrollada para la gestión de inventario y ventas de vehículos. Implementa una arquitectura profesional utilizando **DTOs** (Data Transfer Objects) para separar la lógica de datos de la interfaz de usuario, garantizando seguridad y escalabilidad.

## 🧰 Tecnologías Usadas

* **Framework:** .NET 8 (LTS) / Blazor Server.
* **ORM:** Entity Framework Core (Enfoque Database First/Code First).
* **Base de Datos:** SQL Server 2022
* **Diseño UI:** Bootstrap 5, Animate.css y estilos personalizados en `app.css`.
* **Lenguaje:** C#.

## ⚙️ Instrucciones de instalación

1.  **Clonar el repositorio:**
    ```bash
    git clone [https://github.com/tu_usuario/tu_repositorio.git](https://github.com/tu_usuario/tu_repositorio.git)
    ```
2.  **Configurar la Base de Datos:**
    * Vaya a la carpeta `/BD` y ejecute el archivo `base_de_datos.sql` en su instancia local de SQL Server.
    * Ajuste la cadena de conexión en el archivo `appsettings.json`:
    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Server=TU_SERVIDOR;Database=PruebaTec;Trusted_Connection=True;TrustServerCertificate=True;Connect Timeout=60;"
    }
    ```
3.  **Ejecutar el proyecto:**
    * Abra la solución en Visual Studio o VS Code.
    * Ejecute el comando `dotnet run` o presione `F5`.

## 🧾 Estructura de la Base de Datos

El sistema incluye lógica avanzada en SQL para optimizar el rendimiento:
* **Tablas:** `Vehiculos`, `Marcas`, `Vendedores`, `Ventas`.
* **Vistas:** `VistaVentas` (Unifica toda la información del historial de ventas para reportes rápidos).
* **Procedimientos Almacenados:** `ConsultarVentasPorCedula` para búsquedas parametrizadas.

## ✅ Funcionalidades principales

* **Gestión de Vendedores:** Registro con validación de estados, actualización de datos y consulta de vendedores.
* **Inventario:** CRUD completo de vehículos y marcas.
* **Ventas:** Registro de ventas, eliminaciión por venta mal ingresada y consulta.

## 📁 Estructura del Proyecto

* `/BD`: Scripts de creación y datos iniciales de SQL Server.
* `/Models`: Entidades y contexto de base de datos.
* `/Models/DTOs`: Objetos de transferencia para comunicación segura entre capas.
* `/Services`: Lógica de negocio y servicios de acceso a datos.
* `/Controllers`: Enpoints definidos donde se realizaron las pruebas con Postman para comprobar el funcionamiendo del Services.
* `/Pages`: Componentes Razor para la interfaz de usuario.
* `/wwwroot`: Estilos globales y recursos estáticos.

---
**Desarrollado por:** Laura Daniela Roballo
