using System;
using System.Collections.Generic;

namespace MVCCRUD.Models
{
    public partial class Tarea
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string Completada { get; set; }
    }
}
