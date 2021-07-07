using RentACar.Core.DataAccess.EntityFramework;
using RentACar.DataAccess.Abstract;
using RentACar.DataAccess.Concrete.EntityFramework.Contexts;
using RentACar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentACar.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfCaseTypeDal : EfEntityRepositoryBase<CaseType, RentACarDbContext>, ICaseTypeDal
    {

    }
}
