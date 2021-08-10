using Models.DTO;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BusniessLayer.Utility
{
    public class ValidateEmailUsingAPI
    {
        public static async Task<bool> EmailValidationUsingAPI(string inputEmial)
        {
            var url = "https://api.bouncify.io/v1/verify?apikey=9dw0my4hyt0q1unn10bffcmeezvzu6nt&email=" + inputEmial;
            HttpClient client = new HttpClient
            {
            };
            // Add an Accept header for JSON format.    
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // List all Names.    
            HttpResponseMessage response = client.GetAsync(url).Result;  // Blocking call!    
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                EmailValidationApiResponseModel emailValidationApiResponseModel = JsonConvert.DeserializeObject<EmailValidationApiResponseModel>(responseBody);
                if (emailValidationApiResponseModel.result.Equals("deliverable"))
                {
                    return true;
                }
            }
            return false;

        }
    }
}
