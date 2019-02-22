using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Web.Business
{
    interface IGetDataSet<T>
    {
        List<T> GetDataSet(object requestParams);
    }
}
