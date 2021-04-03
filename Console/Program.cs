using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            // CarManager carManager = new CarManager(new InMemoryCarDal());
              CarTest();
            //   ColorTest();

//            ******
            // AddUser();
          //  AddCustomer();

            AddRental();
            //   RentalTest();

        }

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EFRentalDal());
            foreach (var rental in rentalManager.GetRentalDetails().Data)
            {
                System.Console.WriteLine($"{rental.Id}\t{rental.BrandName}\t{rental.ColorName}\t{rental.RentDate}\t{rental.ReturnDate}");
            }
        }

        private static void AddRental()
        {
            RentalManager rentalManager = new RentalManager(new EFRentalDal());
            Rental rental = new Rental();
            {
                
                rental.CarId = 3;
                rental.CustomerId = 3;
                rental.RentDate = DateTime.Now;
                rental.ReturnDate = DateTime.Now;
                //   rental.ReturnDate =null;
            }
          
            rentalManager.Add(rental);
        }

        private static void AddCustomer()
        {
            CustomerManager customerManager =new CustomerManager(new EFCustomerDal());
            Customer customer = new Customer();
            {
                customer.UserId = 1;
                customer.CompanyName = "YAZILIM";
            }
            customerManager.Add(customer);
        }
        private static void AddUser()
        {
            UserManager userManager = new UserManager(new EFUserDal());
            User user = new User
            {
                FirstName = "Sevinc",
                LastName = "Turan",
                Email = "sevinc_keskin@hotmail.com",
             //   Password = "12345678"

            };
            userManager.Add(user);
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EFColorDal());
            foreach (var car in colorManager.GetAll().Data)
            {
                System.Console.WriteLine(car.ColorName);
                // Console.WriteLine(car.Description);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EFCarDal());
            //foreach (var car in carManager.GetAll())
            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    System.Console.WriteLine(car.BrandName + " /" + car.ColorName);
                }
            }
            else
            {
                System.Console.WriteLine(result.Message);
            }
                //       System.Console.WriteLine(car.Description);
                // Console.WriteLine(car.Description);
            }
        }

   /*     public int AddColor(Color color)
        {
            ColorManager colorManager = new ColorManager(new EFColorDal());
         //   Color color = new Color();

            System.Console.WriteLine("Lutfen Renk giriniz");
            String name = System.Console.ReadLine();
            color.ColorName = name;
            colorManager.Add(color);

        //    System.Console.WriteLine( "Araba Rengi eklendi");

            return color.ColorId;
        }

        public static int AddBrand(Brand brand)
        {
            BrandManager brandManager = new BrandManager(new EFBrandDal());
         //   Brand brand = new Brand();

            System.Console.WriteLine("Lütfen araba markası giriniz");
            String name = System.Console.ReadLine();
            brand.BrandName = name;
            brandManager.Add(brand);
          //  brandManager.GetById(brand.BrandId);kullan dene
            //  System.Console.WriteLine("Araba Markası eklendi");
            return brand.BrandId;
        }

        public static void AddCar(Car car,Brand brand,Color color)
        {
            CarManager carManager = new CarManager(new EFCarDal());
            
          
            int brandId= AddBrand(brand);
            int colorId=  AddColor(color);
            
            System.Console.WriteLine("Lutfen Model yılı giriniz");
            string ModelYear = System.Console.ReadLine();
            
            System.Console.WriteLine("Lutfen Günlük ücret giriniz");
            decimal DailyPrice = Convert.ToDecimal(System.Console.ReadLine());

            System.Console.WriteLine("Lutfen Açıklama giriniz");
            string Description = System.Console.ReadLine();

            car.BrandId = brandId;
            car.ColorId= colorId;
            car.ModelYear = ModelYear;
            car.DailyPrice = DailyPrice;
            car.Descriptions = Description;

            carManager.Add(car);


            System.Console.WriteLine("Araba başarıyla eklenmiştir");
    
          

        }
     */
    
        
    }

