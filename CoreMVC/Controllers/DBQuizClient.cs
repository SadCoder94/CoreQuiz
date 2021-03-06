﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using CoreAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net.Http.Formatting;
namespace CoreMVC.Controllers
{
    public class DBQuizClient : IDBClient
    {
        HttpClient client;
        private readonly string BaseURL = "https://localhost:44347/";

        public DBQuizClient()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri(BaseURL)
            };
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public async Task<HttpResponseMessage> GetData(string url)
        {
            HttpResponseMessage res = await client.GetAsync(BaseURL + url);

            var response = res.Content.ReadAsStringAsync().Result;
            List<Question> questions = JsonConvert.DeserializeObject<List<Question>>(response);

            return res;

        }

        public async Task<HttpResponseMessage> PutAsJsonAsync<Question>(string url, Question JSONQues)//Send edited question
        {
            HttpResponseMessage res = client.PutAsJsonAsync(url, JSONQues).Result;

            if (res.IsSuccessStatusCode)
            {
                return new HttpResponseMessage(HttpStatusCode.Accepted);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }

        }

        public async Task<HttpResponseMessage> GetDataEdit(string url)
        {
            HttpResponseMessage res = await client.GetAsync(url);

            var response = res.Content.ReadAsStringAsync().Result;
            Question questions = JsonConvert.DeserializeObject<Question>(response);

            return res;
        }

        public async Task<HttpResponseMessage> PostAsync(string url, Question JSONQues)//To create question
        {
            var content = JsonConvert.SerializeObject(JSONQues);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage res = client.PostAsync(BaseURL+url, byteContent).Result;

            if (res.IsSuccessStatusCode)
            {
                return new HttpResponseMessage(HttpStatusCode.Accepted);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }

        public async Task<HttpResponseMessage> PostAsync(string url)//To delete question
        {
            HttpResponseMessage res = client.DeleteAsync(BaseURL + url).Result;

            if (res.IsSuccessStatusCode)
            {
                return new HttpResponseMessage(HttpStatusCode.Accepted);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }

    }
}
