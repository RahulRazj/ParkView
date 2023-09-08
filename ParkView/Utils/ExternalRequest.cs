using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Microsoft.Extensions.Options;
using RestSharp;
using RestSharp.Authenticators;
using System.Drawing.Printing;
using System.Text.Json;
using System.Text.Json.Nodes;
using Method = RestSharp.Method;

namespace ParkView.Utils
{
    public class ExternalRequest
    {


        public static async Task SendBookingWhatsappMessage(string whatsappNumber, string checkinDate, string checkoutDate, string hotelName, string hotelAddress, string username)
        {
            string whatsappAccessToken = Utils.WhatsappAccessToken;
            string whatasppApiUrl = Utils.WhatasppApiUrl;
            string requestBody = Utils.GetWhatsappBookingPayload(whatsappNumber, checkinDate, checkoutDate, hotelName, hotelAddress, username);

            var options = new RestClientOptions(whatasppApiUrl)
            {
                Authenticator = new JwtAuthenticator(whatsappAccessToken)
            };

            Console.WriteLine("requestBody: " + requestBody);

            var client = new RestClient(options);
            var request = new RestRequest("",Method.Post).AddJsonBody(requestBody).AddHeader("Content-Type", "application/json");

            var data = await client.ExecutePostAsync(request);
            var response = JsonSerializer.Deserialize<JsonNode>(data.Content);
        }

        public static async Task SendContactWhatsappMessage(string whatsappNumber, string username)
        {
            string whatsappAccessToken = Utils.WhatsappAccessToken;
            string whatasppApiUrl = Utils.WhatasppApiUrl;
            string requestBody = Utils.GetWhatsappContactPayload(whatsappNumber, username);

            var options = new RestClientOptions(whatasppApiUrl)
            {
                Authenticator = new JwtAuthenticator(whatsappAccessToken)
            };


            var client = new RestClient(options);
            var request = new RestRequest("", Method.Post).AddJsonBody(requestBody).AddHeader("Content-Type", "application/json");

            var data = await client.ExecutePostAsync(request);
            var response = JsonSerializer.Deserialize<JsonNode>(data.Content);

        }
    }
}
