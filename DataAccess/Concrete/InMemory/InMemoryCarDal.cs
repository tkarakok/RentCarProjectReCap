using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>()
            {
                new Car{Id =  1, BrandId = 1, ColorId = 1 ,DailyPrice = 1000},
                new Car{Id =  2, BrandId = 2, ColorId = 2 ,DailyPrice = 500},
                new Car{Id =  3, BrandId = 3, ColorId = 3 ,DailyPrice = 750},
                new Car{Id =  4, BrandId = 4, ColorId = 4 ,DailyPrice = 1300},
                new Car{Id =  5, BrandId = 4, ColorId = 4 ,DailyPrice = 1150},
                new Car{Id =  6, BrandId = 3, ColorId = 6 ,DailyPrice = 900}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.FirstOrDefault(p => p.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.FirstOrDefault(p => p.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(p => p.Id == id).ToList();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }
    }
}
