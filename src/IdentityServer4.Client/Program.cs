using IdentityModel.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace IdentityServer4.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            // discover endpoints from metadata
            MainAsync(args);

            Console.Read();
        }

        static Task MainAsync(string[] args)
        {
            return Task.Run(async () =>
            {
                var disco = await DiscoveryClient.GetAsync("http://localhost:5000");
                // request token
                var tokenClient = new TokenClient(disco.TokenEndpoint, "client", "secret");
                var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");

                if (tokenResponse.IsError)
                {
                    Console.WriteLine(tokenResponse.Error);
                    return;
                }

                Console.WriteLine(tokenResponse.Json);

                await CallApi(tokenResponse);
            });
        }

        static async Task CallApi(TokenResponse tokenResponse)
        {
            var client = new HttpClient();
            client.SetBearerToken(tokenResponse.AccessToken);

            var response = await client.GetAsync("http://localhost:5001/api/identity");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(JArray.Parse(content));
            }
        }
    }
}