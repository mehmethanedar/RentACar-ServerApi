using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Contants
{
    public static class Messages
    {
        public static string SuccessfullyAdded = "Başarıyla eklendi";
        public static string SuccessfullyArchieved = "Başarıyla getirildi";
        public static string SuccessfullyUpdated = "Başarıyla güncellendi";
        public static string SuccessfullyDeleted = "Başarıyla silindi";
        public static string AnErrorOccuredOnAddition = "Eklemede bir hata oluştu";
        public static string AnErrorOccuredOnDeletion = "Silmede bir hata oluştu";
        public static string AnErrorOccuredOnUpdation = "Güncellemede bir hata oluştu";

        public static string NotFound = "Bulunamadı";

        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";

        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string ProductNameAlreadyExists = "Ürün ismi zaten mevcut";

        public static string AccountActivationCodeInvalid = "Aktivasyon Kodu Geçersiz";
        public static string AnErrorOccurred = "Bir hata Oluştu";
        public static string AccountActivationNecessary = "Mailinizi Onaylayın";

    }
}
