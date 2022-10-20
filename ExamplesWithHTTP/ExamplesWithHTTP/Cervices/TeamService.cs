using ExamplesWithHTTP.Models;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.ComponentModel.DataAnnotations;

namespace ExamplesWithHTTP.Cervices
{
    public class TeamService
    {
        private string _token;

        public async Task<AuthResponse> Authorise(AuthData authData)
        {
            AuthResponse authResponse;

            var serializedData = JsonConvert.SerializeObject(authData);
            var content = new StringContent(serializedData, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                HttpResponseMessage responseMessage = await client.PostAsync("http://dev.trainee.dex-it.ru/api/Auth/SignIn", content);

                var message = await responseMessage.Content.ReadAsStringAsync();
                authResponse = JsonConvert.DeserializeObject<AuthResponse>(message);
            }

            _token = authResponse.Token;
            return authResponse;
        }

        public async Task<TeamResponse> GetTeams()
        {
            TeamResponse teams;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
                HttpResponseMessage responseMessage = await client.GetAsync("http://dev.trainee.dex-it.ru/api/Team/GetTeams");

                responseMessage.EnsureSuccessStatusCode();

                var message = await responseMessage.Content.ReadAsStringAsync();
                teams = JsonConvert.DeserializeObject<TeamResponse>(message);
            }

            return teams;
        }

        public async Task AddTeam(Team team)
        {
            var serialisedData = JsonConvert.SerializeObject(team);
            var content = new StringContent(serialisedData, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

                await client.PostAsync("http://dev.trainee.dex-it.ru/api/Team/Add", content);
            }
        }
    }
}
