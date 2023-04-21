using CachePoc.Extensions;
using CachePoc.Models;
using CachePoc.Repository;
using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.AddControllers();
builder.Services.ConfigureSqlServerContext(builder.Configuration);
builder.Services.AddScoped<IDataRepository<Employee>, EmployeeManager>();
builder.Services.AddMemoryCache();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
    app.UseHsts();

app.UseHttpsRedirection();

//enables using static files for the requests
//app.UseStaticFiles();

//forward proxy headers to the current request
//app.UseForwardedHeaders(new ForwardedHeadersOptions
//{
//    ForwardedHeaders = ForwardedHeaders.All
//});

//app.UseCors("CorsPolicy");
app.UseAuthorization();

app.MapControllers();

app.Run();
