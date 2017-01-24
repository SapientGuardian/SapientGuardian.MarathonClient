using SapientGuardian.MarathonClient.Interfaces.V2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SapientGuardian.MarathonClient.Implementations.V2
{
    internal class Client : IMarathon
    {
        private readonly HttpClient httpClient;
        private readonly Apps appsEndpoint;
        internal Client(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            this.appsEndpoint = new Apps(httpClient);
        }

        public IApps Apps => appsEndpoint;
    }
}
