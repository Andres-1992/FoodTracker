using FoodTracker.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using Xamarin.Essentials;
using System.Net.Http.Headers;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace FoodTracker.ftTrackService
{
    public class FtTrackService : IFtTrackService
    {
        // static string BaseUrl = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5000" : "http://localhost:5000";
        //  string baseUrl = "https://lobonode.ddns.net";
        private static HttpClient client = new HttpClient() {
            BaseAddress = new Uri("https://lobonode.ddns.net")
        };

        public async Task<bool> AddItem(Item item)
        {
            string url = "/ft/addItem";
            //  HttpClient client = new HttpClient();
            string json = JsonConvert.SerializeObject(item);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage respons = await client.PostAsync(url, content);
           // var result = respons.Content;
            return respons.IsSuccessStatusCode;
        }

        public async Task<ObservableCollection<Item>> GetItemById(string ean)
        {
            string url = $"/ft/getItem/{ean}";
            // HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(url);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string result = await response.Content.ReadAsStringAsync();

                Item fountItem = JsonConvert.DeserializeObject<Item>(result);
                return new ObservableCollection<Item>() { fountItem };
            }
            return null;
        }

        public async Task<ObservableCollection<Item>> GetItems()
        {
            string url = "/ft/getItems/";
            // HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(url);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ObservableCollection<Item>>(result);
            }
            return null;
        }
    }
}
