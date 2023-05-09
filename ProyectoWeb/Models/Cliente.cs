using System;
using System.Collections.Generic;

namespace ProyectoWeb.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string? NombreDelCliente { get; set; }

    public string? ApellidoDelCliente { get; set; }

    public int? Telefono { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
