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



// Ozimga mos api topolmagach userlar uchun apini olib ikiga bolib ishlatganman bu yerda. 

#region Api orqali malumot qoshish. Agar oldin qoshilgan malumot qoshilsa eror beradi

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
#endregion

