using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{

    class Program
    {
        public static void Main(string[] args)
        {
            /*
                    Console.WriteLine("Araba Kiralama Sistemi - Arac Listesi");

                    //// renk islemi
                    //ColorTest();

                    //// Marka islemi
                    //BrandTest();

                    //// Araba işlemleri
                    //CarTest();

                    //// Kullanıcı işlemleri
                    //UserTest();

                    //// Müşteri işlemleri
                    //CustomerTest();

                    //// Araç kiralama  işlemleri
                    RentalTest();

             */
        }
        /*
            #region Arac kiralama islemleri
            private static void RentalTest()
            {
                RentalManager rent = new RentalManager(new EfRentalDal());


                //Rental rent1 = new Rental
                //{
                //    CarId = 3,
                //    CustomerId = 1,
                //    RentDate = DateTime.Now,
                //};

                //var res = rent.Add(rent1);
                var res = rent.GetRentalDetails();


                foreach (var item in res.Data)
                {
                    Console.WriteLine(item.CarName + "" + item.CustomerName + "" + item.RentDate + "/" + item.ReturnDate);
                }
                Console.WriteLine(res.Message);
            }
            #endregion

            #region Müşteri işlemleri
            private static void CustomerTest()
            {
                CustomerManager cust = new CustomerManager(new EfCustomerDal());

                //// müsteri ekleme
                //Customer newCust = new Customer
                //{
                //    CompanyName = "Ford",
                //    UserId = 3
                //};
                //var res = cust.Add(newCust);


                //// Müşteri güncelleme
                //var res = cust.Update(new Customer { Id = 2, UserId = 2, CompanyName = "Mercedes" });

                //// müşteri silme
                //var res = cust.Delete(new Customer { Id = 3 });

                var res = cust.GetCustomerDetails();

                foreach (var item in res.Data)
                {
                    Console.WriteLine(item.UserFirstName + "" + item.UserLastName + "" + item.CompanyName);
                }

                Console.WriteLine(res.Message);
            }
            #endregion

            #region Kullanıcı işlemleri
            private static void UserTest()
            {
                // Kullanıcı ekleme
                UserManager userManager = new UserManager(new EfUserDal());

                //User user1 = new User
                //{
                //    FirstName = "omer",
                //    LastName = "ustunay",
                //    Email = "omerustunay",
                //    Password = "123"
                //};
                //User user4 = new User
                //{
                //    FirstName = "omer4",
                //    LastName = "ustunay4",
                //    Email = "omerustunay4",
                //    Password = "123"
                //};

                //var result = userManager.Add(user4);

                //// Kullanıcı Güncelleme
                //result = userManager.Update(new User
                //{
                //    Id = 3,
                //    Email = "omerustunay3",
                //    FirstName = "omer3",
                //    LastName = "ustunay3",
                //    Password = "1234"
                //});
                //Console.WriteLine(result.Message);

                ////Kullanıcı Silme
                //result = userManager.Delete(new User
                //{
                //    Id = 3
                //});
                //Console.WriteLine(result.Message);

                //Kullanıcı Listesi
                var result = userManager.GetAll();
                foreach (var item in result.Data)
                {
                    Console.WriteLine("Kullanıcılar : " + item.FirstName + "-" + item.LastName);
                }
            }
            #endregion

            #region Marka işlemleri
            private static void BrandTest()
            {
                BrandManager brandManager = new BrandManager(new EfBrandDal());

                Brand newBrand = new Brand()
                {
                    BrandName = "bmw"
                };

                brandManager.Add(newBrand);

                var result = brandManager.GetAll();
                foreach (var item in result.Data)
                {
                    Console.WriteLine("brand is : " + item.BrandName);
                }

                result = brandManager.GetCarsByBrandId(2);
                foreach (var item in result.Data)
                {
                    Console.WriteLine("two id brand is : " + item.BrandName);
                }

                brandManager.Delete(new Brand { Id = 3 });
            }
            #endregion

            #region Renk işlemleri
            private static void ColorTest()
            {
                ColorManager colorManager = new ColorManager(new EfColorDal());

                Color newColor = new Color()
                {
                    ColorName = "kırmızı"
                };

                colorManager.Add(newColor);

                var result = colorManager.GetAll();
                foreach (var item in result.Data)
                {
                    Console.WriteLine("color is : " + item.ColorName);
                }

                result = colorManager.GetCarsByColorId(1);
                foreach (var item in result.Data)
                {
                    Console.WriteLine("one id color is : " + item.ColorName);
                }
                colorManager.Delete(new Color { Id = 3 });
            }
            #endregion

            #region Arac işlemleri
            private static void CarTest()
            {
                CarManager carManager = new CarManager(new EfCarDal());

                //Car newCar = new Car()
                //{
                //    BrandId = 2,
                //    ColorId = 1,
                //    DailyPrice = 300,
                //    Description = "c5",
                //    ModelYear = 2014
                //};
                //carManager.Add(newCar);

                var result = carManager.GetCarDetails();
                if (result.Success == true)
                {
                    foreach (var item in result.Data)
                    {
                        Console.WriteLine(item.BrandName + "-" + item.ColorName + "-" +
                            item.DailyPrice + "-" + item.ModelYear + "-" + item.Description);
                    }
                }
                else
                {
                    Console.WriteLine(result.Message);

                }

            }
            #endregion
        */
    }
}
