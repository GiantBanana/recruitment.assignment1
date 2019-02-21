using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Web.Repository
{
    public interface IGetData<T>
    {
        List<T> GetData();
    }
}
