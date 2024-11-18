using NH_Sys_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NH_Sys_Domain.Interfaces
{
    public interface IInventoryRepository
    {
        Task<int> ConsultInventory(long idProduct);
        Task<InventarioTb> GetInventory(long idProduct, string almacen);
        Task<InventarioTb> AddInventory (InventarioTb inventario);

        Task<bool> UpdateInventory (InventarioTb inventario);
    }
}
