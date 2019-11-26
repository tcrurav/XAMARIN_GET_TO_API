using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AppXamarinCrud
{
    public class RestService : IRestService
    {
        HttpClient _client;

        public List<Bicycle> Items { get; private set; }

        public RestService()
        {
            _client = new HttpClient();
        }

        public async Task<List<Bicycle>> RefreshDataAsync()
        {
            Items = new List<Bicycle>();

            var uri = new Uri(string.Format(Constants.BicyclesUrl, string.Empty));
            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<List<Bicycle>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Items;
        }

        public async Task SaveBicycleAsync(Bicycle item, bool isNewItem = false)
        {
            var uri = new Uri(string.Format(Constants.BicyclesUrl, isNewItem? string.Empty : item.ID.ToString()));

            try
            {
                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response = await _client.PostAsync(uri, content);
                }
                else
                {
                    response = await _client.PutAsync(uri, content);
                }

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tBicycle successfully saved.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        public async Task DeleteBicycleAsync(int id)
        {
            var uri = new Uri(string.Format(Constants.BicyclesUrl, id));

            try
            {
                var response = await _client.DeleteAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\Bicycle successfully deleted.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }
    }
}
