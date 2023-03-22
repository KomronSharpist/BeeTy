using BeeTy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeTy.Data.IRepostories
{
    public interface IWorkerRepostory
    {
        Task<Worker> InsertAsync(Worker worker);
        Task<Worker> UpdateAsync(Worker worker);
        Task<bool> DeleteAsync(int id);
        Task<Worker> SelectAsync(int id);
        Task<List<Worker>> SelectAllAsync();
    }
}
