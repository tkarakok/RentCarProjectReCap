using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentCarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = from car in context.Cars
                    join brand in context.Brands on car.BrandId equals brand.Id
                    join color in context.Colors on car.ColorId equals color.Id
                    select new CarDetailDto
                    {
                        BrandName = brand.Name,
                        ColorName = color.Name,
                        DailyPrice = car.DailyPrice
                    };

                return result.ToList();
            }
        }

    }
}
