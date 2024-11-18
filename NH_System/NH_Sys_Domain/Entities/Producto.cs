using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NH_Sys_Domain.Entities;

public partial class Producto
{
    [Key]
    public long IdProducto { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = string.Empty;

    public decimal Precio { get; set; }

    public decimal PrecioDistribuidor { get; set; }

    public decimal PrecioCosto { get; set; }

    public string CodigoProducto { get; set; } = null!;

    public bool IsActive { get; set; } = true;

    [ForeignKey("Proveedor")]
    public long IdProveedor { get; set; }

    public bool DescuentoAplicable { get; set; }

    public string MarcaNombre { get; set; } = string.Empty;

    [ForeignKey("MarcaProducto")]
    public int MarcaId { get; set; }

    public string EscalaNombre { get; set; } = string.Empty;

    [ForeignKey("EscalaProducto")]
    public int EscalaId { get; set; }

    [ForeignKey("CategoriaProducto")]
    public long IdCategoriaProducto { get; set; }

    public virtual CategoriaProducto? CategoriaProducto { get; set; }

    public virtual Proveedor? Proveedor { get; set; }
    public virtual MarcaProducto? Marca { get; set; }
    public virtual EscalaProducto? Escala { get; set; }

    public virtual ICollection<DetallefacturaTb> DetallefacturaTbs { get; set; } = new List<DetallefacturaTb>();

    public virtual ICollection<InventarioTb> InventarioTbs { get; set; } = new List<InventarioTb>();
    public virtual ICollection<MovimientoInventario> MovimientosInventario { get; set; } = new List<MovimientoInventario>();

}
