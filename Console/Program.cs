
using System;
using System.Linq;
using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            EFRentalDal efRentalDal = new EFRentalDal();
            var result = efRentalDal.GetRentalDetails();
            foreach (var r in result)
            {
                Console.WriteLine(r.BrandName);
            }
            //EFRentalDal rentalDal = new EFRentalDal();
            //foreach (var r in rentalDal.GetRentalDetails())
            //{
            //    Console.WriteLine(r.FirstName);
            //}
            //RentalManager rentalManager = new RentalManager(new EFRentalDal());
            //Console.Write("Araba numarasını giriniz :");
            //int carId = Convert.ToInt32(Console.ReadLine());
            //Console.Write("Müşteri numaranızı giriniz :");
            //int customerId = Convert.ToInt32(Console.ReadLine());
            //Console.Write("Başlangıç tarihini giriniz :");
            //DateTime rentDate = Convert.ToDateTime(Console.ReadLine());
            //Console.Write("Bitiş tarihini giriniz :");
            //DateTime? returnDate = Convert.ToDateTime(Console.ReadLine());
            //var resultt = rentalManager.Add(new Rental()
            //{
            //    CustomerId = customerId,
            //    CarId = carId,
            //    RentDate = rentDate,
            //    ReturnDate = returnDate,
            //});
            //if (resultt.Success == true)
            //{
            //    Console.WriteLine(resultt.Message);
            //}
            //else
            //{
            //    Console.WriteLine(resultt.Message);
            //}
            //BrandConsoleAdded();
            //ColorConsoleAdded();
            //CarConsoleAdded();

            // RentalGetAll();
            //RentalAdded();

            //CustomerAdded(); 

            //UserAdded();

            //var carManager = FilterBrandAdded();
            //ColorDeleted();
            //ColorUpdated(); 
            //ColorGetById(); 
            //ColorGetAll(); 
            //ColorAdded(); 

         
            //BrandUpdated();
            //BrandDeleted();
            //BrandAdded(); 
            //BrandGetAll();

            //CarGetAll();
          
                               
            //CarUpdated();
            //CarDeleted();
            //CarAdded();
            //GetCarByColorId(2);


            //Console.ReadLine();
        }

        private static void BrandConsoleAdded()
        {
            BrandManager brandManager = new BrandManager(new EFBrandDal());
            Console.Write("Araba ismini giriniz :");
            string brandName = Console.ReadLine();
            var result = brandManager.Add(new Brand() { BrandName = brandName });
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void ColorConsoleAdded()
        {
            ColorManager colorManager = new ColorManager(new EFColorDal());
            Console.Write("Renk giriniz :");
            string colorName = Console.ReadLine();
            var result = colorManager.Add(new Color() { ColorName = colorName });
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CarConsoleAdded()
        {
            CarManager carManager = new CarManager(new EFCarDal());
            Console.Write("Marka numarasını giriniz :");
            int brandId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Renk numarasını giriniz :");
            int colorId = Convert.ToInt32(Console.ReadLine());
            
            Console.Write("Günlük satış fiyatını giriniz :");
            int dailyPrice = Convert.ToInt32(Console.ReadLine());
            Console.Write("Açıklamayı giriniz :");
            string description = Console.ReadLine();
            var result = carManager.Add(new Car()
            {
                BrandId = brandId,
                ColorId = colorId,
                DailyPrice = dailyPrice,
                Descriptions = description
            });
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void RentalGetAll()
        {
            RentalManager rentalManager = new RentalManager(new EFRentalDal());
            foreach (var r in rentalManager.GetAll().Data)
            {
                Console.WriteLine(r.CarId + " " + r.Id + " " + r.Id + " " + r.RentDate + " " + r.ReturnDate);
            }
        }

        private static void RentalAdded()
        {
            RentalManager rentalManager = new RentalManager(new EFRentalDal());
            var result = rentalManager.Add(new Rental()
            {
                CarId = 1,
                CustomerId = 2,
                RentDate = new DateTime(2021, 02, 10),
                ReturnDate = new DateTime(2021, 02, 15)

            });
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CustomerAdded()
        {
            CustomerManager customerManager = new CustomerManager(new EFCustomerDal());
            customerManager.Add(new Customer()
            {
                CompanyName = "Apple"
            });
            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine(customer.CompanyName);
            }
        }


        private static void UserAdded()
        {
            UserManager userManager = new UserManager(new EFUserDal());
            userManager.Add(new User()
            {
                FirstName = "Sevinc",
                LastName = "Turan",
                Email = "keskinsevinc.turan@gmail.com",
            });
        }

        private static CarManager FilterBrandAdded()
        {
            CarManager carManager = new CarManager(new EFCarDal());
            var result = carManager.Add(new Car()
            { BrandId = 2, ColorId = 3, DailyPrice = 500, Descriptions = "...", ModelYear = "2014" });
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            return carManager;
        }

        private static void ColorDeleted()
        {
            EFColorDal efColorDal = new EFColorDal();
            Color color = new Color()
            {
                ColorId = 5
            };
            efColorDal.Delete(color);
        }

        private static void ColorUpdated()
        {
            EFColorDal efColorDal = new EFColorDal();
            Color color = new Color()
            {
                ColorId = 7,
                ColorName = "Mor"
            };
            efColorDal.Update(color);
        }

        private static void ColorGetById()
        {
            ColorManager colorManager = new ColorManager(new EFColorDal());
            var result = colorManager.GetById(2);
            Console.WriteLine(result.Data);
        }

        private static void ColorGetAll()
        {
            ColorManager colorManager = new ColorManager(new EFColorDal());
            foreach (var c in colorManager.GetAll().Data)
            {
                Console.WriteLine(c.ColorId + "--" + c.ColorName);
            }
        }

        private static void ColorAdded()
        {
            ColorManager colorManager = new ColorManager(new EFColorDal());
            colorManager.Add(new Color()
            {
                ColorId = 5,
                ColorName = "MAVİ"
            });
        }

        private static void BrandUpdated()
        {
            EFBrandDal efBrandDal = new EFBrandDal();
            Brand brand = new Brand()
            {
                BrandId = 3,
                BrandName = "Mercedes"
            };
            efBrandDal.Update(brand);
        }

        private static void BrandDeleted()
        {
            EFBrandDal efBrandDal = new EFBrandDal();
            Brand brand = new Brand()
            {
                BrandId = 4,
                BrandName = "Tofas"
            };
            efBrandDal.Delete(brand);
        }

        private static void BrandAdded()
        {
            BrandManager brandManager = new BrandManager(new EFBrandDal());
            var result = brandManager.Add(new Brand());
            if (result.Success == true)
            {
                brandManager.Add(new Brand()
                {
                    BrandId = 2,
                    BrandName = "Mercedes"
                });

            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CarGetAll()
        {
            CarManager carManager = new CarManager(new EFCarDal());
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine("{0}--{1}--{2}", car.BrandId, car.DailyPrice, car.Descriptions);
            }
        }

        private static void BrandGetAll()
        {
            BrandManager brandManager = new BrandManager(new EFBrandDal());
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandId + " " + brand.BrandName);
            }
        }

        private static void GetByDailyPrice(CarManager carManager)
        {
            foreach (var car in carManager.GetByDailyPrice(100, 130).Data)
            {
                Console.WriteLine(car.BrandId + " " + car.DailyPrice);
            }
        }

        private static void CarUpdated()
        {
            EFCarDal efCarDal = new EFCarDal();
            Car car = new Car()
            { BrandId = 1, ColorId = 1, DailyPrice = 700, Descriptions = "....", Id = 6, ModelYear = "2020" };
            efCarDal.Update(car);
        }

        private static void CarDeleted()
        {
            EFCarDal efCarDal = new EFCarDal();
            Car car = new Car()
            { BrandId = 1, ColorId = 1, DailyPrice = 700, Descriptions = "------", Id = 2, ModelYear = "2020" };
            efCarDal.Delete(car);
        }

        private static void CarAdded()
        {
            CarManager carManager = new CarManager(new EFCarDal());
            carManager.Add(new Car()
            {
                Id = 10,
                BrandId = 1,
                ColorId = 1,
                DailyPrice = 10,
                Descriptions = "---",
                ModelYear = "2021"
            });
        }

        public static void GetCarByColorId(int colorId)
        {
            ReCapContext context = new ReCapContext();
            var result = context.Cars.Where(c => c.ColorId == colorId);
            foreach (var car in result)
            {
                Console.WriteLine(car.Descriptions);
            }
        }
    }

}
