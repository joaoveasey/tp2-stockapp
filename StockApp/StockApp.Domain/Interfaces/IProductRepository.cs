using StockApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Domain.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProductAsync();
    Task<Product> GetIdAsync (int id);
    Task<Product> CreateAsync (Product product);
    Task<Product> UpdateAsync (Product product);
    Task<Product> RemoveAsync (Product product);
}
