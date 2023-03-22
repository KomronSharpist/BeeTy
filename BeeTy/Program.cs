using BeeTy.Data.Configurations;
using BeeTy.Data.DbContexts;
using BeeTy.Data.IRepostories;
using BeeTy.Data.Repostories;
using BeeTy.Domain.Entities;
using BeeTy.Service.DTOs;
using BeeTy.Service.Interfaces;
using BeeTy.Service.Services;
using Microsoft.VisualBasic;
using Newtonsoft.Json;

AppDbContext dbContext = new AppDbContext();
HttpClient client = new HttpClient();


//SERVICESSS
IUserService UserService = new UserService(dbContext);
IWorkerService WorkerService = new WorkerService(dbContext);
IOrderService orderService = new OrderService(dbContext);
IPlanService PlanService = new PlanService(dbContext);

//REPOSTORIESSS
IUserRepostory UserRepostory = new UserRepostory(dbContext);
IWorkerRepostory WorkerRepostory = new WorkerRepostory(dbContext);
IOrderRepostory orderRepostory = new OrderRepostory(dbContext);
IPlanRespotory PlanRepostory = new PlanRepostory(dbContext);


//User newUser = new User()
//{
//    FirstName = "Test",
//    LastName = "Test",
//    Email = "Test",
//    Password = "Test",
//    Phone = "Test",
//    Age = 19,
//    CreatedAt = DateTime.Now,
//    UserName = "Test",
//};



//Worker newWorker = new Worker()
//{
//    Id = 12,
//    FirstName = "Test",
//    LastName = "Test",
//    Email = "Test",
//    Password = "Test",
//    Phone = "Test",
//    UserName = "Test",
//};
//await WorkerRepostory.InsertAsync(newWorker);




//for (int i = 2; i < 50; i++)
//{
//    HttpResponseMessage users = await client.GetAsync(AppSetings.PATH + $"{i}");
//    var user = await users.Content.ReadAsStringAsync();
//    var result = JsonConvert.DeserializeObject<User>(user);
//    Console.WriteLine(result.FirstName);
//    await UserRepostory.InsertAsync(result);
//}



//for (int i = 50; i < 101; i++)
//{
//    HttpResponseMessage workers = await client.GetAsync(AppSetings.PATH + $"{i}");
//    var worker = await workers.Content.ReadAsStringAsync();
//    var result = JsonConvert.DeserializeObject<Worker>(worker);
//    Console.WriteLine(result.FirstName);
//    await WorkerRepostory.InsertAsync(result);
//}

WorkerCDto newWorker = new WorkerCDto
{
    FirstName = "Komron",
    LastName = "Sulayomnov",
    UserName = "aDASdasda",
    Email = " admawndjawndjaw",
    Phone = "njasndjandjna",
    Password = "Password",
};

var res = await UserService.DeleteAsync(5);
