using Microsoft.AspNetCore.Mvc.Testing;

namespace UnitConverter.Tests;

public class ApplicationTests
{
    [Fact]
    public async Task HomePage_ReturnsSuccessStatusCode()
    {
        await using var application = new WebApplicationFactory<Program>();

        using var client = application.CreateClient();

        var response = await client.GetAsync("/");

        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task HomePage_ContainsExpectedHeading()
    {
        await using var application = new WebApplicationFactory<Program>();

        using var client = application.CreateClient();

        var response = await client.GetAsync("/");
        String content = await response.Content.ReadAsStringAsync();

        Assert.Contains("Unit Converter", content);
    }
}
