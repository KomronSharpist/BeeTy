using BeeTy.Domain.Entities;
using BeeTy.Service.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeTy.Service.Interfaces;

public interface IPlanService
{
    Task<Response<Plan>> CreateAsync(Plan plan);
    Task<Response<bool>> UpdateAsync(Plan plan, long id);
    Task<Response<bool>> DeleteAsync(long id);
    Response<Plan> GetAsync(Predicate<Plan> predicate = null);
    Response<Plan> GetAllAsync(Predicate<Plan> predicate = null);
}
