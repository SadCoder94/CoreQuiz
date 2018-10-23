using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoreMVC.Controllers
{
     public interface IDBClient
    {
        
        Task<HttpResponseMessage> GetData(string url);
        Task<HttpResponseMessage> GetDataEdit(string url);
        Task<HttpResponseMessage> PutAsJsonAsync<Question>(string url, Question JSONQues);
    }
}
