using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
  public static class Messages
    {
       
        public static string DailyPriceInvalid = "Günlük fiyat kısmını 0'dan büyük giriniz ";
        public static string MaintanenceTime = "Sistem Bakımda";
        public static string Added = "Ekleme işlemi başarılı";
        public static string NameInvalid = "Eksik veya hatalı bilgi";
        public static string Updated = "Güncelleme işlemi başarılı";
        public static string Deleted = "Silme işlemi başarılı";
        public static string DeletedInvalid = "Silme işlemi başarısız";
        public static string Listed = "Listeleme işlemi başarılı";
        public static string AddedCarImage = "Araba Resmi Eklendi";
        public static string FailedCarImageAdd = "Araba Resmi Eklenemedi";
        public static string DeletedCarImage = "Araba Resmi Silindi";
        public static string AuthorizationDenied = "Yetkilendirme reddedildi";

        public static string UserAlreadyExists = "\nKullanıcı zaten var.\n";
        public static string UserNotFound = "\nKullanıcı bulunamadı.\n";

        public static string PasswordError = "\nParola hatalı.\n";
        public static string UserRegistered = "\nKullanıcı kayıt edildi.\n";
        public static string AccessTokenCreated = "\n Access Token oluşturuldu.\n";
        public static string TransactionSucceed = "\nTransaction işlemi başarılı.\n";
    }
}
