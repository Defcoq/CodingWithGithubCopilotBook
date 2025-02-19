using ECommerce.Model;

namespace ECommerce.DAL.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ECommerceDbContext context) : base(context)
        {
        }

        // Implementa metodi specifici per Category se necessario
    }
}