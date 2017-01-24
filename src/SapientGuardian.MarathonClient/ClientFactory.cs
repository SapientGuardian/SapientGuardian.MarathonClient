using SapientGuardian.MarathonClient.Interfaces.V2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SapientGuardian.MarathonClient
{
    public static class ClientFactory
    {

        /// <summary>
        /// Creates a new V2 Marathon API client.
        /// </summary>
        /// <param name="baseAddress">The base address. Example: http://marathon.mycluster.local/v2/</param>
        /// <param name="authToken">The authentication token.</param>
        /// <returns>A new client</returns>
        /// <exception cref="ArgumentNullException">baseAddress</exception>
        public static IMarathon V2Client(string baseAddress, string authToken = null)
        {
            if (string.IsNullOrEmpty(baseAddress)) throw new ArgumentNullException(nameof(baseAddress));

            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAddress);
            if (!string.IsNullOrEmpty(authToken))
            {
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", $"token={authToken}");
            }
            return new Implementations.V2.Client(httpClient);
        }

        /// <summary>
        /// For testing, do not use.
        /// </summary>        
        public static IMarathon V2Client(HttpClient httpClient, string baseAddress, string authToken = null)
        {
            if (string.IsNullOrEmpty(baseAddress)) throw new ArgumentNullException(nameof(baseAddress));

            httpClient.BaseAddress = new Uri(baseAddress);
            if (!string.IsNullOrEmpty(authToken))
            {
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization: token", authToken);
            }
            return new Implementations.V2.Client(httpClient);
        }
    }
}
