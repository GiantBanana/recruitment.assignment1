using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Assignment1.Web.Repository
{
    public class GetDataFromJson<T> : IGetData<T>
    {
        public List<T> GetData()
        {

            var json = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.GetData("DataDirectory").ToString(), "transactions.json"));
            var transactions = JsonConvert.DeserializeObject<List<T>>(json);


            return transactions;
        }

        
    }
}
