using System;
using System.Collections.Generic;

namespace ProyectoWeb.Models;

public partial class Producto
{
    public int Id { get; set; }

    public string? NombreDelProducto { get; set; }

    public string? DescripcionDelProducto { get; set; }

    public int? IdClientes { get; set; }

    public virtual Cliente? IdClientesNavigation { get; set; }

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
