using BeeTy.Data.DbContexts;
using BeeTy.Data.IRepostories;
using BeeTy.Data.Repostories;
using BeeTy.Domain.Entities;

HttpClient client = new HttpClient();

//for (int i = 0; i < 50; i++)
//{
//    HttpResponseMessage users = await client.GetAsync(AppSetings.PATH+$"{i}");
//    var user = await users.Content.ReadAsStringAsync();
//    var result = JsonConvert.DeserializeObject<User>(user);
//    Console.WriteLine(result.FirstName);
//}
//for (int i = 50; i < 101; i++)
//{
//    HttpResponseMessage workers = await client.GetAsync(AppSetings.PATH + $"{i}");
//    var worker = await workers.Content.ReadAsStringAsync();
//    var result = JsonConvert.DeserializeObject<User>(worker);
//    Console.WriteLine(result.FirstName);
//}


//HttpResponseMessage workers = await client.GetAsync(AppSetings.PATH + $"1");
//var worker = await workers.Content.ReadAsStringAsync();
//var result = JsonConvert.DeserializeObject<User>(worker);

//Console.WriteLine(result.FirstName); 

var context = new AppDbContext();
IGenericRepostory<Worker> Worker = new GenericRepostory<Worker>(context);

Worker newWorker = new Worker()
{
    FirstName = "Muzaffar",
    LastName = "Nurilayev",
    Email = "muzaffar022@gamil.com",
    Phone = "923u82323223",
    UserName = "Muzaffar",
    Password = "mjsadnajn2j9jnfa",
    Company = new Company()
    {
        Title = "Yangi ish",
        Department = "Oyligi yaxwi",
        Name = "Komronbek Sulaymonov"
    }
};
//var result = await Worker.InsertAsync(newWorker);

var res = await Worker.DeleteAsync(p => p.Id == 2);
Console.WriteLine(res);

var result2 = await Worker.SelectAllAsync();
foreach (var i in result2)
{
    Console.WriteLine(i.FirstName);
}