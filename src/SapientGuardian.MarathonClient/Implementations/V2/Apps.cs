using Newtonsoft.Json.Linq;
using SapientGuardian.MarathonClient.Interfaces.V2;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SapientGuardian.MarathonClient.Implementations.V2
{
    internal class Apps : IApps
    {
        private readonly HttpClient httpClient;
        internal Apps(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<App>> GetAll()
        {
            var appsJson = await httpClient.GetAsync("apps?embed=apps.counts");
            appsJson.EnsureSuccessStatusCode();
            var responseObj = await appsJson.Content.ReadAsStringAsync();
            var jResponse = JObject.Parse(responseObj);
            return jResponse["apps"].Values<JObject>().Select(jApp => new App(jApp));
        }

        public async Task<App> Get(string id)
        {
            var appsJson = await httpClient.GetAsync($"apps{id}?embed=apps.counts");
            appsJson.EnsureSuccessStatusCode();
            var responseObj = await appsJson.Content.ReadAsStringAsync();
            var jResponse = JObject.Parse(responseObj);
            return new App(jResponse.Value<JObject>("app"));
        }

        public async Task Update(App app)
        {
            // Workaround for Marathon behavior that gives you items in the GET that cannot be send back in the PUT
            var payload = (JObject)app.appJobj.DeepClone();
            payload.Remove("uris");
            payload.Remove("version");
            var response = await httpClient.PutAsync($"apps{app.Id}", new StringContent(payload.ToString(), System.Text.Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
        }
    }
}
