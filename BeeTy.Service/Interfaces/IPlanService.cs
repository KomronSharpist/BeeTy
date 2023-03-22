using BeeTy.Domain.Entities;
using BeeTy.Service.DTOs;
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
    Task<Response<bool>> UpdateAsync(Plan plan, int id);
    Task<Response<bool>> DeleteAsync(int id);
    Task<Response<Plan>> GetAsync(int id);
    ValueTask<Response<List<Plan>>> GetAllAsync(string search = null);
}

