using AutoMapper;
using BeeTy.Data.IRepostories;
using BeeTy.Data.Repostories;
using BeeTy.Domain.Entities;
using BeeTy.Service.DTOs;
using BeeTy.Service.Extensions;
using BeeTy.Service.Helpers;
using BeeTy.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeTy.Service.Services;

public class WorkerService : IWorkerService
{
    private readonly IGenericRepostory<Worker> genericRepostory = new GenericRepostory<Worker>();
    private readonly DbContext dbContext;

    private readonly IMapper mapper;
    public WorkerService(IMapper mapper)
    {
        this.mapper = mapper;
    }

    public async Task<Response<WorkerDto>> CreateAsync(WorkerCDto worker)
    {
        var workers = await this.genericRepostory.SelectAllAsync();
        bool anyEntityExists = workers.Any(u => u.Email.Equals(worker.Email) && u.UserName.Equals(worker.UserName));
        if (anyEntityExists)
        {
            return new Response<WorkerDto>
            {
                Code = 405,
                Message = "User is already exist",
                Value = null
            };
        }

        var mappedWorker = this.mapper.Map<Worker>(worker);
        mappedWorker.Password = worker.Password.Encrypt();
        var resultLast = this.mapper.Map<WorkerDto>(mappedWorker);


        var WorkerCreate = await genericRepostory.InsertAsync(mappedWorker);

        return new Response<WorkerDto>
        {
            Code = 200,
            Message = "Succes",
            Value = resultLast
        };
    }

    public async Task<Response<bool>> DeleteAsync(long id)
    {
        var worker = await this.genericRepostory.DeleteAsync(p => p.Id == id);
        if (worker)
        {
            return new Response<bool>
            {
                Code = 200,
                Message = "Succes",
                Value = true
            };
        }

        return new Response<bool>
        {
            Code = 404,
            Message = "Not found",
            Value = false
        };
    }

    public async ValueTask<Response<List<WorkerDto>>> GetAllAsync(string search = null)
    {
        var workers = await this.genericRepostory.SelectAllAsync();
        var content = workers.ToList();
        if (content.Any())
        {
            return new Response<List<WorkerDto>>()
            {
                Code = 404,
                Message = "This place is empty",
                Value = null
            };
        }

        var result = workers.Where(user => user.FirstName.Contains(search, StringComparison.OrdinalIgnoreCase));
        var mappedWorker= this.mapper.Map<List<WorkerDto>>(result);

        return new Response<List<WorkerDto>>()
        {
            Code = 200,
            Message = "Succes",
            Value = mappedWorker
        };
    }

    public async ValueTask<Response<WorkerDto>> GetAsync(Predicate<WorkerCDto> predicate = null)
    {
        var workers = await this.genericRepostory.SelectAllAsync();
        if (!workers.Any())
        {
            return new Response<WorkerDto>
            {
                Code = 404,
                Message = "This place is empty",
                Value = null
            };
        }

        if (predicate is null)
            predicate = x => true;

        var mappedWorker = this.mapper.Map<WorkerDto>(workers);

        return new Response<WorkerDto>
        {
            Code = 200,
            Message = "Succes",
            Value = mappedWorker
        };
    }

    public async Task<Response<bool>> UpdateAsync(WorkerCDto worker, long id)
    {
        var workers = await this.genericRepostory.SelectAllAsync();
        var userForUpdate = workers.Where(w => w.Id == id).FirstOrDefault();
        if (userForUpdate is null)
        {
            return new Response<bool>
            {
                Code = 405,
                Message = "This place is empty",
                Value = false
            };
        }
        userForUpdate.UpdatedAt = DateTime.UtcNow;
        userForUpdate.FirstName = worker.FirstName;
        userForUpdate.LastName = worker.LastName;
        userForUpdate.Email = worker.Email;
        userForUpdate.UserName = worker.UserName;
        userForUpdate.Password = worker.Password;

        await genericRepostory.UpdateAsync(userForUpdate);
        
        return new Response<bool>
        {
            Code = 200,
            Message = "Succes",
            Value = true
        };
    }
}
