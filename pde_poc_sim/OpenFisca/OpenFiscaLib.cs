using Microsoft.Extensions.Options;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace pde_poc_sim.OpenFisca
{
    public class OpenFiscaLib : IOpenFisca
    {
        private readonly RestClient _client;

        public OpenFiscaLib(IOptions<OpenFiscaOptions> optionsAccessor) {
            string apiUrl = optionsAccessor.Value.Url;
            _client = new RestClient(apiUrl);
            _client.UseNewtonsoftJson();
        }


        public OpenFiscaResponse Calculate(OpenFiscaRequest request) {
            var restRequest = new RestRequest($"calculate", DataFormat.Json);
            restRequest.AddJsonBody(request);
            var result = _client.Post<OpenFiscaResponse>(restRequest);
            return result.Data;
        }
    }
}