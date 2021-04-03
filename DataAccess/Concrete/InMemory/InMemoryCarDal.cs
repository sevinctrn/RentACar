using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
   public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        //  ctor tab tab constructor olusturur
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
            new Car{Id=1,BrandId =1,ColorId=1,DailyPrice=10,ModelYear="1982",Descriptions="tosba"},
            new Car{Id=2,BrandId =1,ColorId=1,DailyPrice=100,ModelYear="1960",Descriptions="bmw"},
            new Car{Id=3,BrandId =2,ColorId=2,DailyPrice=8000,ModelYear="1955",Descriptions="mercedes"},
            new Car{Id=4,BrandId =3,ColorId=3,DailyPrice=990,ModelYear="1990",Descriptions="minibus"},

            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);


        }

        public void Delete(Car car)
        {
           
          Car carToDelete = _cars.SingleOrDefault(c=>c.Id==car.Id);
            _cars.Remove(carToDelete);

        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public int GetById(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
           
            return car.Id;
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Descriptions = car.Descriptions;
            carToUpdate.ModelYear = car.ModelYear;
        }

    }
}
