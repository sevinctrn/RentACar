using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

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

            if (rental.RentDate >= DateTime.Now.Date)
            {
                if (rental.ReturnDate <= DateTime.Now.Date)
                {
                    _rentalDal.Add(rental);

                    return new SuccessResult(Messages.Added);

                }
                else
                {
                    return new SuccessResult(Messages.NameInvalid);
                }

            }
            else
            {
                return new SuccessResult(Messages.NameInvalid);
            }



        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        /*        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
                {
                    return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
                }
        */
        public IDataResult<List<RentalDetailDto>> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(filter), Messages.Listed);
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(b => b.Id == id));
        }

        public IResult Update(Rental rental)
        {
            if (rental.RentDate >= DateTime.Now)
            {
                _rentalDal.Update(rental);
                return new SuccessResult(Messages.Updated);
            }
            else
            {
                return new ErrorResult(Messages.NameInvalid);
            }
        }


    }
}
