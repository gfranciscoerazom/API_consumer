﻿using API_consumer.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace API_consumer.Services
{
    public class Service_API : IService_API
    {
        private static string _baseUrl;

        public Service_API()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseUrl = builder.GetSection("ApiSettings:baseUrl").Value;
        }

        public async Task<List<Producto>> GetProductosAsync()
        {
            var productos = new List<Producto>();

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_baseUrl);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await httpClient.GetAsync("api/Productos");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    productos = JsonConvert.DeserializeObject<List<Producto>>(json);
                }
            }
            
            return productos;
        }

        public async Task<Producto> GetProductoAsync(int id)
        {
            var producto = new Producto();

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_baseUrl);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await httpClient.GetAsync($"api/Productos/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    producto = JsonConvert.DeserializeObject<Producto>(json);
                }
            }

            return producto;
        }

        public async Task<bool> AddProductoAsync(Producto producto)
        {
            bool success = false;

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_baseUrl);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json = JsonConvert.SerializeObject(producto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("api/Productos", content);

                if (response.IsSuccessStatusCode)
                {
                    success = true;
                }
            }

            return success;
        }

        public async Task<bool> UpdateProductoAsync(Producto producto)
        {
            var success = false;

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_baseUrl);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json = JsonConvert.SerializeObject(producto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync($"api/Productos/{producto.ProductoId}", content);

                if (response.IsSuccessStatusCode)
                {
                    success = true;
                }
            }

            return success;
        }

        public async Task<bool> DeleteProductoAsync(int id)
        {
            var success = false;

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_baseUrl);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await httpClient.DeleteAsync($"api/Productos/{id}");

                if (response.IsSuccessStatusCode)
                {
                    success = true;
                }
            }

            return success;
        }

        public async Task<List<Cliente>> GetClientesAsync()
        {
            var clientes = new List<Cliente>();

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_baseUrl);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await httpClient.GetAsync("api/Clientes");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    clientes = JsonConvert.DeserializeObject<List<Cliente>>(json);
                }
            }

            return clientes;
        }

        public async Task<Cliente> GetClienteAsync(int id)
        {
            var cliente = new Cliente();

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_baseUrl);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await httpClient.GetAsync($"api/Clientes/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    cliente = JsonConvert.DeserializeObject<Cliente>(json);
                }
            }

            return cliente;
        }

        public async Task<bool> AddClienteAsync(Cliente cliente)
        {
            var success = false;

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_baseUrl);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json = JsonConvert.SerializeObject(cliente);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("api/Clientes", content);

                if (response.IsSuccessStatusCode)
                {
                    success = true;
                }
            }

            return success;
        }

        public async Task<bool> UpdateClienteAsync(Cliente cliente)
        {
            var success = false;

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_baseUrl);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json = JsonConvert.SerializeObject(cliente);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync($"api/Clientes/{cliente.ClienteId}", content);

                if (response.IsSuccessStatusCode)
                {
                    success = true;
                }
            }

            return success;
        }

        public async Task<bool> DeleteClienteAsync(int id)
        {
            var success = false;

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_baseUrl);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await httpClient.DeleteAsync($"api/Clientes/{id}");

                if (response.IsSuccessStatusCode)
                {
                    success = true;
                }
            }

            return success;
        }
    }
}
