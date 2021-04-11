﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rental rental)
        {
            var result = BusinessRules.Run(
                IsRentable(rental));
            if (result != null)
            {
                return result;
            }
            rental.RentDate = DateTime.Now;
            _rentalDal.Add(rental);
            return new SuccessResult();

        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<List<Rental>> GetAllByCarId(int carId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.CarId == carId));
        }

        public IDataResult<Rental> GetLastByCarId(int carId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.GetAll(r => r.CarId == carId).LastOrDefault());
        }

        public IDataResult<List<Rental>> GetAllByCustomerId(int userId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.UserId == userId));
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id));
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }

        public IResult IsDelivered(Rental rental)
        {
            var result = this.GetAllByCarId(rental.CarId).Data.LastOrDefault();
            if (result == null || result.ReturnDate != default)
                return new SuccessResult();
            return new ErrorResult();

        }

        public IResult IsRentable(Rental rental)
        {
            var result = this.GetAllByCarId(rental.CarId).Data.LastOrDefault();
            if (IsDelivered(rental).Success || (rental.RentStartDate > result.RentEndDate && rental.RentStartDate >= DateTime.Now))
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IDataResult<List<RentalDetailDto>> GetAllRentalsDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetAllRentalDetails());
        }
        //private IResult CheckIfFindeksScoreEnough(string productName)
        //{
        //   var result 
        //}
    }
}
