﻿using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using eCommerce.ComputerParts.Shop.Core.Constants;
using eCommerce.ComputerParts.Shop.Core.Extensions;
using eCommerce.ComputerParts.Shop.Service.AuthEndpoints;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PublicApiIntegrationTests.AuthEndpoints;

[TestClass]
public class AuthenticateEndpoint
{
    [TestMethod]
    [DataRow("demouser@computerparts.com", AuthorizationConstants.DEFAULT_PASSWORD, true)]
    [DataRow("demouser@computerparts.com", "badpassword", false)]
    [DataRow("baduser@microsoft.com", "badpassword", false)]
    public async Task ReturnsExpectedResultGivenCredentials(string testUsername, string testPassword, bool expectedResult)
    {
        var request = new AuthenticateRequest()
        {
            Username = testUsername,
            Password = testPassword
        };
        var jsonContent = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
        var response = await ProgramTest.NewClient.PostAsync("api/authenticate", jsonContent);
        response.EnsureSuccessStatusCode();
        var stringResponse = await response.Content.ReadAsStringAsync();
        var model = stringResponse.FromJson<AuthenticateResponse>();

        Assert.AreEqual(expectedResult, model!.Result);
    }
}
