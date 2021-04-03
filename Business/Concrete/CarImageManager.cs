using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
//using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
//using Microsoft.VisualStudio.TestPlatform.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        /*    public IResult Add(IFormFile file, CarImage carImage)
            {
                var result = BusinessRules.Run(CheckCarImageLimit(carImage));

                if (result != null)
                {
                    return result;
                }

                carImage.ImagePath = FileHelper.Add(file);
                carImage.Date = DateTime.Now;
                _carImageDal.Add(carImage);

                return new SuccessResult(Messages.AddedCarImage);
            }
  */
        public IResult Add(IFormFile file, CarImage carImage)
              {
                  var imageCount = _carImageDal.GetAll(c => c.CarId == carImage.CarId).Count;

                  if (imageCount >= 5)
                  {
                      return new ErrorResult("One car must have 5 or less images");
                  }

                  var imageResult = FileHelper.Add(file);

                  if (!imageResult.Success)
                  {
                      return new ErrorResult(imageResult.Message);
                  }
                  carImage.ImagePath = imageResult.Message;
                  _carImageDal.Add(carImage);
                  return new SuccessResult("Car image added");
              }
          
        public IResult Delete(CarImage carImage)
        {
            var oldpath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) + _carImageDal.Get(I => I.Id == carImage.Id).ImagePath;

            var result = BusinessRules.Run(FileHelper.Delete(oldpath));

            if (result != null)
            {
                return result;
            }

            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.DeletedCarImage);


        }

        public IDataResult<List<CarImage>> GetAll(Expression<Func<CarImage, bool>> filter = null)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(filter));
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(I => I.Id == id));
        }

        /*     public IResult Update(IFormFile file, CarImage carImage)
             {
                 var oldpath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) + _carImageDal.Get(p => p.Id == carImage.Id).ImagePath;
                 carImage.ImagePath = FileHelper.Update(oldpath, file);
                 carImage.Date = DateTime.Now;
                 _carImageDal.Update(carImage);
                 return new SuccessResult();

             }
*/
        public IResult Update(IFormFile file, CarImage carImage)
                {
                    var isImage = _carImageDal.Get(c => c.Id == carImage.Id);
                    if (isImage == null)
                    {
                        return new ErrorResult("Image not found");
                    }

                    var updatedFile = FileHelper.Update(file, isImage.ImagePath);
                    if (!updatedFile.Success)
                    {
                        return new ErrorResult(updatedFile.Message);
                    }
                    carImage.ImagePath = updatedFile.Message;
                    _carImageDal.Update(carImage);
                    return new SuccessResult("Car image updated");
                }
             
        private IResult CheckCarImageLimit(CarImage carImage)
        {
            if (_carImageDal.GetAll(c => c.CarId == carImage.CarId).Count >= 5)
            {
                return new ErrorResult(Messages.FailedCarImageAdd);
            }

            return new SuccessResult();
        }



    }
}