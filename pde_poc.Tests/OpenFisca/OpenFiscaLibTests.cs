using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Options;

using Xunit;
using FakeItEasy;
using RestSharp;

using pde_poc_sim.OpenFisca;

namespace pde_poc.Tests
{
    // TODO
    public class OpenFiscaLibTests
    {
        
        [Fact]
        public void ShouldWorkNormally()
        {
            // Arrange 
            string personKey = "personKey";
            string propKey = "propKey";
            decimal value = 983.333m;

            var restClient = A.Fake<RestClient>();

            var openFiscaResponse = new OpenFiscaResource();
            openFiscaResponse.CreatePerson(personKey);
            openFiscaResponse.SetProp(personKey, propKey, value);

            var restResponse = new RestResponse<OpenFiscaResource> {
                Data = openFiscaResponse,
                StatusCode = System.Net.HttpStatusCode.OK
            };

            A.CallTo(() => restClient.Execute<OpenFiscaResource>(A<RestRequest>._, Method.POST))
                .Returns(restResponse);

            var options = Options.Create(new OpenFiscaOptions(){
                Url = "localhost:5000"
            });

            // Act
            var sut = new OpenFiscaLib(restClient, options);
            var request = A.Fake<OpenFiscaResource>();
            var result = sut.Calculate(request);

            // Assert
            Assert.Equal(value, result.GetProp(personKey, propKey));
        }

        [Fact]
        public void ShouldThrowOnMissingVariable()
        {
            // Arrange 
            var restClient = A.Fake<RestClient>();

            var errorResponse = new RestResponse<OpenFiscaResource>() {
                StatusCode = System.Net.HttpStatusCode.NotFound
            };

            A.CallTo(() => restClient.Execute<OpenFiscaResource>(A<RestRequest>._, Method.POST))
                .Returns(errorResponse);

            var options = Options.Create(new OpenFiscaOptions(){
                Url = "localhost:5000"
            });

            // Act
            var sut = new OpenFiscaLib(restClient, options);
            var request = A.Fake<OpenFiscaResource>();

            Assert.Throws<OpenFiscaException>(() => sut.Calculate(request));
        }
    }
}
