using BeeTy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeTy.Data.IRepostories
{
    public interface IPlanRespotory
    {
        Task<Plan> InsertAsync(Plan plan);
        Task<Plan> UpdateAsync(Plan plan);
        Task<bool> DeleteAsync(int id);
        Task<Plan> SelectAsync(int id);
        Task<List<Plan>> SelectAllAsync();
    }
}
