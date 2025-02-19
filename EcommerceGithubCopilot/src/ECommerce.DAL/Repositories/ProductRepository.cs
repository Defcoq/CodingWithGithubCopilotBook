using ECommerce.Model;

namespace ECommerce.DAL.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ECommerceDbContext context) : base(context)
        {
        }

        // Implementa metodi specifici per Product se necessario
    }
}