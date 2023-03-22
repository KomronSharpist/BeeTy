using AutoMapper;
using BeeTy.Data.DbContexts;
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
    private readonly IWorkerRepostory workerRepostory = new WorkerRepostory();

    private readonly IMapper mapper;
    private AppDbContext dbContext;

    public WorkerService(IMapper mapper)
    {
        this.mapper = mapper;
    }

    public WorkerService(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Response<WorkerDto>> CreateAsync(WorkerCDto worker)
    {
        var workers = await this.workerRepostory.SelectAllAsync();
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
        var UserCreate = workerRepostory.InsertAsync(mappedWorker);

        return new Response<WorkerDto>
        {
            Code = 200,
            Message = "Succes",
            Value = resultLast
        };
    }

    public async Task<Response<bool>> DeleteAsync(int id)
    {
        var worker = await this.workerRepostory.DeleteAsync(id);
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
        var workers = await this.workerRepostory.SelectAllAsync();
        var content = workers.ToList();
        if (!content.Any())
        {
            return new Response<List<WorkerDto>>()
            {
                Code = 404,
                Message = "This place is empty",
                Value = null
            };
        }

        List<WorkerDto> workersDTo = workers.Select(u => new WorkerDto
        {
            FirstName = u.FirstName,
            LastName = u.LastName,
            Email = u.Email,
            Password = u.Password,
            UserName = u.UserName,
            Phone = u.Phone
        }).ToList();

        return new Response<List<WorkerDto>>()
        {
            Code = 200,
            Message = "Succes",
            Value = workersDTo
        };
    }

    public async ValueTask<Response<WorkerDto>> GetAsync(int id)
    {
        var worker  = await this.workerRepostory.SelectAsync(id);
        if (worker is null)
        {
            return new Response<WorkerDto>
            {
                Code = 404,
                Message = "This place is empty",
                Value = null
            };
        }

        var mappedWorker =  new WorkerDto
        {
            FirstName = worker.FirstName,
            LastName = worker.LastName,
            Email = worker.Email,
            Password = worker.Password,
            UserName = worker.UserName,
            Phone = worker.Phone
        };

        //var mappedUser = this.mapper.Map<WorkerDto>(worker);

        return new Response<WorkerDto>
        {
            Code = 200,
            Message = "Succes",
            Value = mappedWorker = new WorkerDto
            {
                FirstName = worker.FirstName,
                LastName = worker.LastName,
                Email = worker.Email,
                Password = worker.Password,
                UserName = worker.UserName,
                Phone = worker.Phone
            }
        };
    }

    public async Task<Response<bool>> UpdateAsync(WorkerCDto worker, int id)
    {
        var workers = await this.workerRepostory.SelectAllAsync();
        var workerForUpdate = workers.Where(worker => worker.Id == id).FirstOrDefault();
        if (workerForUpdate is null)
        {
            return new Response<bool>
            {
                Code = 405,
                Message = "This place is empty",
                Value = false
            };
        }
        workerForUpdate.UpdatedAt = DateTime.UtcNow;
        workerForUpdate.FirstName = worker.FirstName;
        workerForUpdate.LastName = worker.LastName;
        workerForUpdate.Email = worker.Email;
        workerForUpdate.UserName = worker.UserName;
        workerForUpdate.Password = worker.Password;
        await workerRepostory.UpdateAsync(workerForUpdate);
        return new Response<bool>
        {
            Code = 200,
            Message = "Succes",
            Value = true
        };
    }
}
