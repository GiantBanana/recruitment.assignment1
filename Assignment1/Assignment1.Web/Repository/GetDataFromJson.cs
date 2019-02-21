using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Assignment1.Web.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Assignment1.Web.Repository
{
    public class GetDataFromJson<T> : IGetData<T>
    {
        public List<T> GetData()
        {

            var json = File.ReadAllText(System.IO.Path.Combine(AppDomain.CurrentDomain.GetData("DataDirectory").ToString(), "transactions.json"));
            var transactions = JsonConvert.DeserializeObject<List<T>>(json);


            return transactions;
        }

        
    }
}
