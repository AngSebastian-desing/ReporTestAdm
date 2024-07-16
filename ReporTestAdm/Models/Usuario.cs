using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ReporTestAdm.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public int? Edad { get; set; }

    public string? Puesto { get; set; }
    [JsonIgnore]
    public string Email { get; set; } = null!;
    [JsonIgnore]
    public string Password { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Reporte> Reportes { get; set; } = new List<Reporte>();
}
