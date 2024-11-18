using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NH_Sys_Application.ServiceInterfaces.Product
{
    public interface IInventoryService
    {
        Task<int> ConsultarStock(long idProducto);
        Task<bool> RegistrarEntrada(long idProducto, int cantidad, string motivo);
        Task<bool> RegistrarSalida(long idProducto, int cantidad, string motivo);


    }
}
