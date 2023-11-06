// See https://aka.ms/new-console-template for more information

using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entity.Concrete;

CarTest();





void CarTest()
{
    CarManager carManager = new CarManager(new EfCarDal());


    foreach (var car in carManager.GetCarDetails())
    {
        Console.WriteLine(car.BrandName + "/ " + car.ColorName);
    }
}

