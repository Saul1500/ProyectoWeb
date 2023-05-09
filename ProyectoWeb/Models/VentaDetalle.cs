using System;
using System.Collections.Generic;

namespace ProyectoWeb.Models;

public partial class VentaDetalle
{
    public int Id { get; set; }

    public int? IdProductos { get; set; }

    public int? IdVentas { get; set; }

    public decimal? CantidadDeLaCompra { get; set; }

    public decimal? PrecioDeLaCompra { get; set; }

    public decimal? PrecioTotal { get; set; }

    public virtual Venta? IdVentasNavigation { get; set; }
}
