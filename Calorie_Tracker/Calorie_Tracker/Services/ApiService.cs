using Calorie_Tracker.Models.ApiModels;
using Calorie_Tracker.Models.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Calorie_Tracker.Services
{
    // ApiService class responsible for handling API interactions
    class ApiService
    {
        private readonly HttpClient _httpClient; // HttpClient instance for making HTTP requests

        // Constructor to initialize ApiService with base URL
        public ApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://100.70.102.13:5000/api/"); // Replace with your own IP address
        }

        // Method to fetch list of foods from API asynchronously
        public async Task<FoodListReponse> getFoodList(string token)
        {

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // Send GET request to API endpoint for foods
            var response = await _httpClient.GetAsync("foods");

            var contentresponse = await response.Content.ReadAsStringAsync();

            var foods = JsonConvert.DeserializeObject<FoodListReponse>(contentresponse);


            try
            {
                return foods; // Return list of foods obtained from API
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP request failed: {ex.Message}");
                return null; // Return null in case of HTTP request failure
            }
        }

        // Method to fetch daily intake data for a user asynchronously
        public async Task<ObservableCollection<DailyIntake>> getDailyIntakeAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<ObservableCollection<DailyIntake>>($"dailyIntakes/search/{id}");
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Method to register a new user asynchronously
        public async Task<bool> RegisterUserAsync(Bruger bruger)
        {
            try
            {
                // Serialize user object to JSON
                var json = System.Text.Json.JsonSerializer.Serialize(bruger);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Send POST request to register endpoint
                var response = await _httpClient.PostAsync("auth/register", content);

                return response.IsSuccessStatusCode; // Return true if registration is successful
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP request failed: {ex.Message}");
                return false; // Return false if HTTP request fails
            }
        }

        // Method to authenticate user login and obtain token asynchronously
        public async Task<string> LoginAsync(string email, string password)
        {
            var user = new
            {
                email = email.Contains("@") ? email : null,
                password
            };

            // Serialize user credentials to JSON
            var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("auth/login", content);

            // Process response if login is successful
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var bruger = System.Text.Json.JsonSerializer.Deserialize<Bruger>(result);

                // Store user ID and token securely
                await SecureStorage.SetAsync("userId", bruger.Id);
                await SecureStorage.SetAsync("auth_token", bruger.token);
                return result; // Return JSON result if login is successful
            }

            return null; // Return null if login fails
        }

        // Method to fetch user information by ID asynchronously
        public async Task<Bruger> GetUserInfoByIdAsync(string token, string userId)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            try
            {
                var response = await _httpClient.GetAsync($"users/{userId}");

                var bruger = await response.Content.ReadFromJsonAsync<Bruger>();
                return bruger; // Return user information fetched from API
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Goal> GetUserGoalByIdAsync(string token, string userId)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            try
            {
                var response = await _httpClient.GetAsync($"goals/{userId}");

                var contentresponse = await response.Content.ReadAsStringAsync();

                GoalReponse bruger = JsonConvert.DeserializeObject<GoalReponse>(contentresponse);

                return bruger.Goal; // Return user information fetched from API
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Method to register a new food item asynchronously
        public async Task<bool> RegisterFoodAsync(Food food)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(food);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("foods", content);

            if (response.IsSuccessStatusCode)
            {
                return true; // Return true if food registration is successful
            }
            else
            {
                return false; // Return false if food registration fails
            }
        }
        public async Task<bool> RegisterGoalAsync(Goal goal)
        {
            var token = await SecureStorage.GetAsync("auth_token");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

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

        public async Task<bool> CreateDailyIntakeAsync(Food food, string weight)
        {
            var token = await SecureStorage.GetAsync("auth_token");
            var id = await SecureStorage.GetAsync("userId");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            DailyIntake newIntake = new DailyIntake();

            newIntake.Weight = Convert.ToInt32(weight);
            newIntake.FoodID = food._id;
            newIntake.UserID = id;
            newIntake.Date = DateTime.Now;

            var json = System.Text.Json.JsonSerializer.Serialize(newIntake);
            var content = new StringContent(json, Encoding.UTF8, "application/json");


            var response = await _httpClient.PostAsync("dailyIntakes", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public async Task<bool> UpdateDailyIntakeAsync(string token, string id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return true;



        }
        public async Task<double?> GetDailyIntakeAsync(string token, string id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync($"dailyIntakes/search/user/{id}");

            var contentresponse = await response.Content.ReadAsStringAsync();

            DailyIntakeResponseList intake = JsonConvert.DeserializeObject<DailyIntakeResponseList>(contentresponse);

            double? calories = 0;

            foreach (var item in intake.dailyIntake)
            {
                Food food = await GetFoodByIdAsync(token,item.FoodID);
                calories += food.calories * item.Weight;
            }

            return calories;
        }

        public async Task<Food> GetFoodByIdAsync(string token, string id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync($"foods/search/{id}");

            var contentresponse = await response.Content.ReadAsStringAsync();

            FoodReponse food = JsonConvert.DeserializeObject<FoodReponse>(contentresponse);

            return food.Food;
        }




    }
}
