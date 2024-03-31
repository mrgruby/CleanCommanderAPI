using CleanCommander.Application.Contracts.Persistence;
using CleanCommander.Domain.Entities;
using CleanCommander.Infrastructure.Identity.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommander.Infrastructure.Identity.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AuthenticationDbContext _dbContext;

        public UserRepository(AuthenticationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public CommanderUser GetUserByUserName(string userName)
        {
            return _dbContext.CommanderUser.Where(u => u.UserName == userName).FirstOrDefault();
        }
    }
}
