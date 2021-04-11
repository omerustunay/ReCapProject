using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        ICarService _carService;

        public CarImageManager(ICarImageDal carImage, ICarService carService)
        {
            _carImageDal = carImage;
            _carService = carService;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add( CarImage carImage, IFormFile file)
        {
            IResult result = BusinessRules.Run(CarControl(carImage.CarId), CheckImageCountCorrect(carImage.CarId));

            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = CarImagesFileHelper.Add(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IDataResult<List<CarImage>> CheckIfCarHaveNoImage(int carId)
        {
            string path = @"\Images\defaultImage.jpg";
            CarImage empty = new CarImage { CarId = carId, ImagePath = path };
            List<CarImage> list = new List<CarImage>();
            list.Add(empty);
            var result = _carImageDal.GetAll(i => i.CarId == carId);
            if (result.Count != 0)
                return new SuccessDataResult<List<CarImage>>(result);
            return new ErrorDataResult<List<CarImage>>(list);
        }

        public IResult Delete(int carImageId)
        {
            var getCarImage = DatabaseCarImageCheck(carImageId);
            IResult result = BusinessRules.Run(getCarImage);

            if (result != null)
            {
                return result;
            }
            var delete = CarImagesFileHelper.Delete(getCarImage.Data.ImagePath);
            if (delete.Success)
            {
                _carImageDal.Delete(getCarImage.Data);
                return new SuccessResult(Messages.CarImageDeleted);
            }
            return new ErrorResult(Messages.CarImageNotDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(CheckIfCarHaveNoImage(carId).Data);
        }

        public IDataResult<CarImage> GetById(int carImageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(i => i.Id == carImageId));
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(int carImageId, IFormFile file)
        {
            CarImage carImage = new CarImage();
            var carControl = CarImageControl(carImageId);
            IResult result = BusinessRules.Run(CarImageIdCheck(carImageId), carControl);

            if (result != null)
            {
                return result;
            }
            carImage = carControl.Data;
            var carUpdateFile = CarImagesFileHelper.Update(file, carImage.ImagePath);
            carImage.ImagePath = carUpdateFile;
            _carImageDal.Update(carImage);

            return new SuccessResult(Messages.CarImageUpdated);
        }

        private IResult CarImageIdCheck(int carImageId)
        {
            if (carImageId <= 0)
            {
                return new ErrorResult(Messages.IdError);
            }
            return new SuccessResult();
        }

        private IResult CheckImageCountCorrect(int carImageId)
        {
            var res = _carImageDal.GetAll(c => c.CarId == carImageId).Count;
            if (res > 5)
            {
                return new ErrorResult(Messages.ImageCountError);
            }
            return new SuccessResult();
        }

        private IDataResult<CarImage> CarImageControl(int carImageId)
        {
            var carImage = _carImageDal.Get(i => i.Id == carImageId);
            if (carImage != null)
            {
                return new SuccessDataResult<CarImage>(carImage);
            }
            return new ErrorDataResult<CarImage>(Messages.CarImageNotFound);
        }

        private IDataResult<Car> CarControl(int carId)
        {
            var car = _carService.GetById(carId);
            if (car.Success)
            {
                return new SuccessDataResult<Car>(car.Data);
            }
            return new ErrorDataResult<Car>(Messages.CarNotFound);
        }
        private IDataResult<CarImage> DatabaseCarImageCheck(int carImageId)
        {
            var result = _carImageDal.Get(i => i.Id == carImageId);
            if (result == null)
            {
                return new ErrorDataResult<CarImage>(Messages.CarImageNotFound);
            }
            return new SuccessDataResult<CarImage>(result);
        }
    }
}
