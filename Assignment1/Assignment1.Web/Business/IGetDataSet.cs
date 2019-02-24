using System.Collections.Generic;

namespace Assignment1.Web.Business
{
    public interface IGetDataSet<T>
    {
        List<T> GetDataSet(object requestParams);
    }
}
