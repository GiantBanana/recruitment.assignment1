using System.Collections.Generic;

namespace Assignment1.Web.Repository
{
    public interface IGetData<T>
    {
        List<T> GetData();
    }
}
