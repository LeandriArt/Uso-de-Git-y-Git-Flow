# Tienda Inventario

CRUD de productos con ASP.NET Core MVC, .NET 10 y SQLite.
Permite crear, listar, editar y eliminar productos.

## Ejecución

Desde la carpeta Tienda.Inventario:

```bash
dotnet restore
dotnet run
```

Abre la dirección indicada y pulsa «Ir a productos».
La base de datos se crea automáticamente.

## Git Flow

Ramas principales: main, dev y qa.

Ramas de funcionalidades:
- feature/product-model
- feature/list-products
- feature/create-product
- feature/edit-product
- feature/delete-product

Cada funcionalidad se integró mediante PR hacia dev, qa y main:
15 PR integrados en total.
