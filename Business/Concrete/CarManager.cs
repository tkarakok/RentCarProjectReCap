using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _iCarDal;

        public CarManager(ICarDal iCarDal)
        {
            _iCarDal = iCarDal;
        }


        public List<Car> GetAll()
        {
            return _iCarDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _iCarDal.GetAll(p => p.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _iCarDal.GetAll(p => p.ColorId == colorId);
        }

        public void Add(Car car)
        {
            _iCarDal.Add(car);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _iCarDal.GetCarDetails();

        }
    }
}
