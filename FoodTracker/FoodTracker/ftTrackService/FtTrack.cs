using FoodTracker.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FoodTracker.ftTrackService
{
    public class FtTrack : IFtTrack
    {
        private string Base_url = "https://lobonode.ddns.net/ft";

        public async Task<bool> AddItem(Item item)
        {

        HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(Base_url)
            };
            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json,Encoding.UTF8,"application/json");
            var response= (await client.PostAsync("https://lobonode.ddns.net/ft/addItem", content)).IsSuccessStatusCode;

            return response;
        }

        public async Task<ObservableCollection<Item>> GetItems()
        {
            HttpClient client = new HttpClient();
            //{ 
            //BaseAddress = new Uri(Base_url)
            //};
            string url = Base_url + "/getItems";
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();

                var json = JsonConvert.DeserializeObject<ObservableCollection<Item>>(result);

                return json;
            }
            return null;
        }
    }
}
