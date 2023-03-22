using BeeTy.Domain.Entities;
using BeeTy.Service.DTOs;
using BeeTy.Service.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeTy.Service.Interfaces;

public interface IWorkerService
{
    Task<Response<WorkerDto>> CreateAsync(WorkerCDto worker);
    Task<Response<bool>> UpdateAsync(WorkerCDto worker, long id);
    Task<Response<bool>> DeleteAsync(long id);
    ValueTask<Response<WorkerDto>> GetAsync(Predicate<WorkerCDto> predicate = null);
    ValueTask<Response<List<WorkerDto>>> GetAllAsync(string search = null);
}
