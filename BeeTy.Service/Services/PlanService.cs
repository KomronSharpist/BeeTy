using BeeTy.Domain.Entities;
using BeeTy.Service.Helpers;
using BeeTy.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeTy.Service.Services;

public class PlanService : IPlanService
{
    public Task<Response<Plan>> CreateAsync(Plan plan)
    {
        throw new NotImplementedException();
    }

    public Task<Response<bool>> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Response<Plan> GetAllAsync(Predicate<Plan> predicate = null)
    {
        throw new NotImplementedException();
    }

    public Response<Plan> GetAsync(Predicate<Plan> predicate = null)
    {
        throw new NotImplementedException();
    }

    public Task<Response<bool>> UpdateAsync(Plan plan, long id)
    {
        throw new NotImplementedException();
    }
}
