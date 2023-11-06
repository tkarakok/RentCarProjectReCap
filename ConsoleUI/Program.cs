// See https://aka.ms/new-console-template for more information

using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entity.Abstract;
using Entity.Concrete;

CarManager carManager = new CarManager(new EfCarDal());

Car entitiy = new Car();

Console.WriteLine("ARABA EKLE");

Console.WriteLine("Id :");
entitiy.Id = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("BrandId :");
entitiy.BrandId = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("ColorId :");
entitiy.ColorId = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Model Year :");
entitiy.ModelYear = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("DailyPrice :");
entitiy.DailyPrice = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Description :");
entitiy.Description = Console.ReadLine();

carManager.Add(entitiy);
Console.WriteLine("");

foreach (var car in carManager.GetCarsByBrandId(21))
{
    Console.WriteLine(car.Description);
}

