using ECommerce.Model;

namespace ECommerce.DAL.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ECommerceDbContext context) : base(context)
        {
        }

        // Implementa metodi specifici per User se necessario
    }
}