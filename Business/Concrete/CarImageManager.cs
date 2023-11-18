using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;
        private IFileHelperService _iFileHelperService;

        public CarImageManager(ICarImageDal carImageDal, IFileHelperService iFileHelperService)
        {
            _carImageDal = carImageDal;
            _iFileHelperService = iFileHelperService;
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            IResult result = BusinessRules.Run(CheckImageExists(carId));
            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(GetDefaultImage(carId).Data);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.Id == id), Messages.ImagesListedById);
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {

            IResult result = BusinessRules.Run(CheckForCarImageLimit(carImage.CarId));

            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = _iFileHelperService.Upload(file, PathConstants.CarImagesPath);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.ImageAdded);
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = _iFileHelperService.Update(file, PathConstants.CarImagesPath + carImage.ImagePath,
                PathConstants.CarImagesPath);
            carImage.Date = DateTime.Now;
            
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.ImageUpdated);
        }

        public IResult Delete(CarImage carImage)
        {
            _iFileHelperService.Delete(PathConstants.CarImagesPath + carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }


        #region BusinessRules

        private IResult CheckForCarImageLimit(int carId)
        {
            var result = _carImageDal.GetAll(car => car.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitReached);
            }
            return new SuccessResult();
        }


        private IDataResult<List<CarImage>> GetDefaultImage(int carId)
        {
            List<CarImage> carImages = new List<CarImage>();

            CarImage carImage = new CarImage{CarId = carId, Date = DateTime.Now, ImagePath = "88c9f3357073.png" };
            for (int i = 0; i < 5; i++)
            {
                carImages.Add(carImage);    
            }
            return new SuccessDataResult<List<CarImage>>(carImages);
        }

        private IResult CheckImageExists(int carId)
        {
            var result = _carImageDal.GetAll(p => p.CarId == carId).Count;
            if (result > 0)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
        #endregion
    }
}
