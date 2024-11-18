using Microsoft.EntityFrameworkCore;
using NH_Sys_Application.ServiceInterfaces.Product;
using NH_Sys_Domain.Entities;
using NH_Sys_Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NH_Sys_Application.Services.Product
{
    public class InventoryService : IInventoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IRepositoryGeneric<MovimientoInventario> _repositoryMovimiento;

        public InventoryService(IInventoryRepository inventoryRepository, IUnitOfWork unitOfWork, IRepositoryGeneric<MovimientoInventario> repositoryMovimiento)
        {
            _inventoryRepository = inventoryRepository;
            _unitOfWork = unitOfWork;
            _repositoryMovimiento = repositoryMovimiento;
        }

        public async Task<int> ConsultarStock(long idProducto)
        {
            var stock = await _inventoryRepository.ConsultInventory(idProducto);
            return stock;
        }

        public async Task<bool> RegistrarEntrada(long idProducto, int cantidad, string motivo)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                // Registrar en MovimientosInventario
                var movimiento = new MovimientoInventario
                {
                    IdProducto = idProducto,
                    TipoMovimiento = "Entrada",
                    Cantidad = cantidad,
                    Almacen = "Principal",
                    Motivo = motivo,
                    FechaMovimiento = DateTime.UtcNow
                };
                await _repositoryMovimiento.Add(movimiento);

                // Actualizar Inventario
                var inventario = await _inventoryRepository.GetInventory(idProducto, movimiento.Almacen);

                if (inventario == null)
                {
                    inventario = new InventarioTb
                    {
                        ProductoId = idProducto,
                        Ubicacion = "Principal",
                        Cantidad = 0
                    };
                    await _inventoryRepository.AddInventory(inventario);
                }

                inventario.Cantidad += cantidad;
                inventario.FechaActualizacion = DateTime.UtcNow;

                await _inventoryRepository.UpdateInventory(inventario);
                await _unitOfWork.CommitTransactionAsync();

                return true;
            }
            catch
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }

        public async  Task<bool> RegistrarSalida(long idProducto, int cantidad, string motivo)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                // Registrar en MovimientosInventario
                var movimiento = new MovimientoInventario
                {
                    IdProducto = idProducto,
                    TipoMovimiento = "Salida",
                    Cantidad = cantidad,
                    Almacen = "Principal",
                    Motivo = motivo,
                    FechaMovimiento = DateTime.UtcNow
                };
                await _repositoryMovimiento.Add(movimiento);

                // Actualizar Inventario
                var inventario = await _inventoryRepository.GetInventory(idProducto, movimiento.Almacen);

                if (inventario == null || inventario.Cantidad < cantidad) throw new InvalidOperationException("Stock insuficiente para realizar la salida");
                

                inventario.Cantidad -= cantidad;
                inventario.FechaActualizacion = DateTime.UtcNow;

                await _inventoryRepository.UpdateInventory(inventario);
                await _unitOfWork.CommitTransactionAsync();

                return true;
            }
            catch
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }
    }
}
