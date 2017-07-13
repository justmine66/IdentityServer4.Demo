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
                //await ClientService.RequestClientCredentialsAsync();
                await ClientService.RequestResourceOwnerPasswordAsync();
            });
        }
    }
}