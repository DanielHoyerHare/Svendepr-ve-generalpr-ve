using Calorie_Tracker.Models.ApiModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Calorie_Tracker.Services
{
    class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://100.70.102.13:5000/api/"); // HUSK AT SKIFT TIL DIN IPCONFIG IP ELLERS CONNECTION FAILURE!!
        }

        public async Task<Bruger> getBrugerInformation(int id)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                return null;
            }

            return await _httpClient.GetFromJsonAsync<Bruger>($"query={id}");
        }
        public async Task<ObservableCollection<Food>> getFoodList()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<ObservableCollection<Food>>("foods");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ObservableCollection<DailyIntake>> getDailyIntakeAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<ObservableCollection<DailyIntake>>($"query={id}");
            }
            catch (Exception)
            {

                throw;
            }
        }



        public async Task<bool> RegisterUserAsync(Bruger bruger)
        {
            try
            {
                var json = System.Text.Json.JsonSerializer.Serialize(bruger);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("auth/register", content);

                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP request failed: {ex.Message}");
                return false;
            }
        }

        public async Task<string> LoginAsync(string email, string password)
        {
            var user = new
            {
                email = email.Contains("@") ? email : null,
                password
            };

            var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("login", content);


            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return result;
            }
            return null;

        }

        public async Task<Bruger> GetUserInfoAsync(string token,int id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync($"user/{id}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Bruger>();
            }

            return null;
        }


        public async Task<bool> RegisterGoalAsync(Goal goal)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(goal);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("goals", content);


            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
