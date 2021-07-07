using RentACar.Core.DataAccess;
using RentACar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentACar.DataAccess.Abstract
{
    //Burada temel veri erişim operasyonları olucak Crud işlemleri yani
    public interface ICaseTypeDal:IEntityRepository<CaseType> // IEntityRepository'deki bütün operasyonlar eklenmiş oldu
    {
        //yeni operasyonları yani atıyorum burda casetype gelmiş biz tüm modeller için bu interface'i oluşturcaz
        //bir modelimized farklı bir operasyon kullanacaksak buraya yazacaz onu
        //böylece EfCaseTypeDal klasında implemente edilmiş olucak modelin kendine has özellikleri eklenmiş olucak yani
    }
}
