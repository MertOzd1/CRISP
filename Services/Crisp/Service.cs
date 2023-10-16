using Newtonsoft.Json;
using Services.Models;

namespace Services.HappyPaths
{
    public class Service
    {
        private HttpClient restClient = new HttpClient();
        private string URI = "https://apimgmt-dev-crisp.azure-api.net/patients/query/";

        public async Task<List<Patient>> GetServiceResult()
        {
            //Build the URI
            restClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "PostmanRuntime/7.33.0");
            restClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "*/*");
            restClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Encoding", "gzip, deflate, br");
            restClient.DefaultRequestHeaders.TryAddWithoutValidation("Connection", "keep-alive");
            restClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-type", "text/json");
            restClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-type", "application/json");

            //Makes the get call to the rest endpoint
            var response = await restClient.GetAsync(URI);
            string result = await response.Content.ReadAsStringAsync();
            var patients = JsonConvert.DeserializeObject<List<Patient>>(result);

            return patients;
        }
    }
}

