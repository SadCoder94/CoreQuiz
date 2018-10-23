using CoreMVC.Controllers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoreMVC.Tests.Controller
{
    public class TestClient : IDBClient
    {
        public string res { get; set; }
        public async Task<HttpResponseMessage> GetData(string url)
        {
            HttpResponseMessage responseMessage = new HttpResponseMessage();
            responseMessage.Content = new StringContent(res);
            responseMessage.StatusCode= System.Net.HttpStatusCode.OK;
            return responseMessage;
        }

        public Task<HttpResponseMessage> GetDataEdit(string url)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> PutAsJsonAsync<Question>(string url, Question JSONQues)
        {
            throw new NotImplementedException();
        }
    }
}
