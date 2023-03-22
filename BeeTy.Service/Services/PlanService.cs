using AutoMapper;
using BeeTy.Data.DbContexts;
using BeeTy.Data.IRepostories;
using BeeTy.Data.Repostories;
using BeeTy.Domain.Entities;
using BeeTy.Service.Helpers;
using BeeTy.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeTy.Service.Services;

public class PlanService : IPlanService
{
    private readonly IPlanRespotory planRepostory = new PlanRepostory();

    private readonly IMapper mapper;
    private AppDbContext dbContext;

    public PlanService(IMapper mapper)
    {
        this.mapper = mapper;
    }

    public PlanService(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Response<Plan>> CreateAsync(Plan plan)
    {
        var result = await this.planRepostory.InsertAsync(plan);
        return new Response<Plan>
        {
            Code = 200,
            Message = "Succes",
            Value = result
        };
    }

    public async Task<Response<bool>> DeleteAsync(int id)
    {
        var plan = (await this.planRepostory.SelectAllAsync()).FirstOrDefault(p => p.Id == id);
        if (plan is null)
        {
            return new Response<bool>
            {
                Code = 404,
                Message = "Not Found",
                Value = false
            };
        }
        return new Response<bool>
        {
            Code = 200,
            Message = "Succes",
            Value = true
        };
    }
    public async ValueTask<Response<List<Plan>>> GetAllAsync(string search = null)
    {
        var plans = await this.planRepostory.SelectAllAsync();
        if (plans is null)
        {
            return new Response<List<Plan>>
            {
                Code = 404,
                Message = "Not found",
                Value = null
            };
        }

        return new Response<List<Plan>>
        {
            Code = 200,
            Message = "Succes",
            Value = plans
        };
    }

    public async Task<Response<Plan>> GetAsync(int id)
    {
        var plans = await this.planRepostory.SelectAsync(id);
        if (plans is not null)
        {
            return new Response<Plan>
            {
                Code = 404,
                Message = "Not found",
                Value = null
            };
        }

        var mappedPlan = this.mapper.Map<Plan>(plans);


        return new Response<Plan>
        {
            Code = 200,
            Message = "Succes",
            Value = mappedPlan
        };
    }

    public async Task<Response<bool>> UpdateAsync(Plan plan, int id)
    {
        var plans = await this.planRepostory.SelectAllAsync();
        var planForUpdate = plans.Where(w => w.Id == id).FirstOrDefault();
        if (planForUpdate is not null)
        {
            planForUpdate.UpdatedAt = DateTime.UtcNow;
            planForUpdate.UserId = plan.UserId;
            planForUpdate.WorkerId = plan.WorkerId;

            await planRepostory.UpdateAsync(planForUpdate);

            return new Response<bool>
            {
                Code = 200,
                Message = "Succes",
                Value = true
            };
        }

        return new Response<bool>
        {
            Code = 405,
            Message = "This place is empty",
            Value = false
        };
    }
}
