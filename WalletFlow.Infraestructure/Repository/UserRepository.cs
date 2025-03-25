using Microsoft.EntityFrameworkCore;
using WalletFlow.Domain.Entities;
using WalletFlow.Infraestructure.Context;
using WalletFlow.Infraestructure.Interfaces.Repository;

namespace WalletFlow.Infraestructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(User entity)
        {
            try
            {
                await _context.Users.AddAsync(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public Task<User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Save()
        {
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
