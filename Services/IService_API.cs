﻿using API_consumer.Models;

namespace API_consumer.Services
{
    public interface IService_API
    {
        Task<List<Producto>> GetProductosAsync();
        Task<Producto> GetProductoAsync(int id);
        Task<bool> AddProductoAsync(Producto producto);
        Task<bool> UpdateProductoAsync(Producto producto);
        Task<bool> DeleteProductoAsync(int id);

        Task<List<Cliente>> GetClientesAsync();
        Task<Cliente> GetClienteAsync(int id);
        Task<bool> AddClienteAsync(Cliente cliente);
        Task<bool> UpdateClienteAsync(Cliente cliente);
        Task<bool> DeleteClienteAsync(int id);
    }
}
