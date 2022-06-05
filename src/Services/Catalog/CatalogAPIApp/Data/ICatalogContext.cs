using CatalogAPIApp.Entities;
using MongoDB.Driver;

namespace CatalogAPIApp.Data
{
    public interface ICatalogContext
    {
        IMongoCollection<Product> Products { get; }
    }
}
