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
       private readonly string baseUrl = "https://lobonode.ddns.net";

        public async Task<bool> AddItem(Item item)
        {
            string url = baseUrl + "/ft/addItem";
            HttpClient client = new HttpClient();
            var json = JsonConvert.SerializeObject(item);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage respons = await client.PostAsync(url,content);
            return respons.IsSuccessStatusCode;
        }

        public async Task<ObservableCollection<Item>> GetItemById(string ean)
        {
            string url = baseUrl + $"/ft/getItem/{ean}";
            HttpClient client = new HttpClient();
        
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
        
                var fountItem = JsonConvert.DeserializeObject<Item>(result);
                return new ObservableCollection<Item>() {fountItem}; 
            }
            return null;
        }

        public async Task<ObservableCollection<Item>> GetItems()
        {
            string url = baseUrl + "/ft/getItems/";
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(url);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ObservableCollection<Item>>(result);
            }
            return null;
        }
    }
}
