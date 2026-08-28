using Microsoft.AspNetCore.Mvc.Testing;

namespace UnitConverter.Tests;

public class ApplicationTests
{
    [Fact]
    public async Task HomePage_ReturnsSuccessStatusCode()
    {
        await using var application = new WebApplicationFactory<Program>();

        using var client = application.CreateClient();

        var response = await client.GetAsync("/", TestContext.Current.CancellationToken);

        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task HomePage_ContainsExpectedHeading()
    {
        await using var application = new WebApplicationFactory<Program>();

        using var client = application.CreateClient();

        var response = await client.GetAsync("/", TestContext.Current.CancellationToken);
        String content = await response.Content.ReadAsStringAsync(TestContext.Current.CancellationToken);

        Assert.Contains("Unit Converter", content);
    }
}
