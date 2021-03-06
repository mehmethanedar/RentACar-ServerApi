using RentACar.Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Core.Utilities.Results.Concrete
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data, bool status) : base(status)
        {
            Data = data;
        }

        public DataResult(T data, bool status, string message) : base(status, message)
        {
            Data = data;
        }

        public T Data { get; }

    }
}
