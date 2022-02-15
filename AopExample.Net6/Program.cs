using AOPExample.Core.Extensions;
using AspectCore.Extensions.DependencyInjection;
using CoreProfiler.Web;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseServiceProviderFactory(new DynamicProxyServiceProviderFactory());

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddServices();
builder.Services.AddRepositories();
builder.Services.AddFactories();
builder.Services.AddHealthChecks();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCoreProfiler(true);

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapHealthChecks("/health");
});
app.MapControllers();

app.Run();