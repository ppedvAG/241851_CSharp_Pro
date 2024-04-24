using Autofac;
using ppedv.CarCare.Data.EfCore;
using ppedv.CarCare.Logic.Core;
using ppedv.CarCare.Model;
using ppedv.CarCare.Model.Contracts;
using System.Reflection;

Console.WriteLine("*** CarCare v0.1 ***");

string conString = "Server=(localdb)\\mssqllocaldb;Database=CarCare_Test;Trusted_Connection=true;";

//DI per Hand
//var repo = new CarCareContextRepositoryAdapter(conString);
//var gs = new GarageService(repo);

//DI per AutoFac
var builder = new ContainerBuilder();
builder.Register(x => new CarCareContextRepositoryAdapter(conString)).As<IRepository>();
builder.RegisterType<GarageService>();
var container = builder.Build();

var repo = container.Resolve<IRepository>();
var gs = container.Resolve<GarageService>();

//DI per Reflection
//var file = @"C:\Users\Fred\source\repos\ppedvAG\241851_CSharp_Pro\ppedv.CarCare\ppedv.CarCare.Data.EfCore\bin\Debug\net7.0\ppedv.CarCare.Data.EfCore.dll";
//var ass = Assembly.LoadFrom(file);
//var typeMitRepo = ass.GetTypes().FirstOrDefault(x => x.GetInterfaces().Contains(typeof(IRepository)));

//var repo = (IRepository)Activator.CreateInstance(typeMitRepo, conString);
//var gs = new GarageService(repo);

Console.WriteLine($"Blue Monday Cars:");
foreach (var item in gs.GetAllBlueMondayCars())
{
    Console.WriteLine($"{item.Model}");
}

Console.WriteLine($"All Cars:");
foreach (var item in repo.GetAll<Car>())
{
    Console.WriteLine($"{item.Model} {item.Color} {item.BuiltDate}");
}