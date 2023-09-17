using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.MapGet("/", async (HttpContext context) =>
{
    await Result(context);
});

app.Run();

async Task Result(HttpContext context)
{
    Company company = new Company();
    company.Name = "Microsoft";
    company.Address = "Redmond, Washington, USA";
    company.Income = "+198.3 billion USD";

    Random random = new Random();
    int randomNumber = random.Next(0, 101);

    await context.Response.WriteAsync($"Company:\n{company.Name}\n{company.Address} {company.Income}\n");
    await context.Response.WriteAsync($"Random number: {randomNumber}");
}

public class Company
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string Income { get; set; }
}
