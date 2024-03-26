using System.Text;
using System.Text.Json;
using NSE.WebApp.MVC.Models;

namespace NSE.WebApp.MVC.Services
{
    public class AutenticacaoService : IAutenticacaoService
    {
        private readonly HttpClient _httpClient;

        public AutenticacaoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<LoginResponseViewModel> Login(LoginUserViewModel loginUser)
        {
            var loginContent = new StringContent(
                JsonSerializer.Serialize(loginUser),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("https://localhost:5001/api/identidade/autenticar", loginContent);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            return JsonSerializer.Deserialize<LoginResponseViewModel>(await response.Content.ReadAsStringAsync(), options);
        }

        public async Task<LoginResponseViewModel> Register(RegisterUserViewModel registerUser)
        {
            var registerContent = new StringContent(
                JsonSerializer.Serialize(registerUser),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("https://localhost:5001/api/identidade/nova-conta", registerContent);

            return JsonSerializer.Deserialize<LoginResponseViewModel>(await response.Content.ReadAsStringAsync());
        }
    }
}
