using System;
using System.Collections.Generic;

namespace ProyectoWeb.Models;

public partial class Venta
{
    public int Id { get; set; }

    public int? IdClientes { get; set; }

    public int? IdProductos { get; set; }

    public virtual Producto? IdProductosNavigation { get; set; }

    public virtual ICollection<VentaDetalle> VentaDetalles { get; set; } = new List<VentaDetalle>();
}
