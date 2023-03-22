using BeeTy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeTy.Data.IRepostories
{
    public interface IUserRepostory
    {
        Task<User> InsertAsync(User model);
        Task<User> UpdateAsync(User model);
        Task<bool> DeleteAsync(int id);
        Task<User> SelectAsync(int id);
        Task<List<User>> SelectAllAsync();
    }
}
