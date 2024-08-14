# NEXTI - Aplicativo de Venta de Entradas

Este proyecto es una aplicación web para la venta de entradas para acontecimientos deportivos y culturales, desarrollada para la empresa NEXTI. Los usuarios pueden registrar, eliminar, modificar y consultar eventos. La eliminación de eventos es lógica, lo que significa que los datos no se eliminan físicamente de la base de datos, sino que se marcan como eliminados.

## Características

- **Registro de eventos:** Los usuarios pueden registrar nuevos eventos con información detallada como fecha, lugar, descripción y precio.
- **Modificación de eventos:** Los eventos registrados pueden ser modificados por los usuarios.
- **Eliminación lógica de eventos:** Los eventos pueden ser eliminados lógicamente, es decir, marcados como eliminados en la base de datos.
- **Consulta de eventos:** Los usuarios pueden consultar eventos individuales o listar todos los eventos disponibles.
- **Consulta masiva con paginación:** Los eventos se pueden consultar en una lista paginada para una mejor gestión de los datos.

## Tecnologías Utilizadas

- **Frontend:** React.js
- **Backend:** C# ASP.NET Core 6 (API Rest) - Microservicios
- **Base de Datos:** SQL Server
- **Estado Global:** Zustand
- **Docker:** La aplicación está preparada para ejecutarse en contenedores Docker.
- **Pruebas Unitarias:** Implementadas para asegurar la calidad del código.
- **Arquitectura:** Clean Architecture

## Requisitos Previos

- Node.js (v14 o superior)
- .NET 6 SDK
- SQL Server
- Docker (opcional, para ejecutar la aplicación en contenedores)