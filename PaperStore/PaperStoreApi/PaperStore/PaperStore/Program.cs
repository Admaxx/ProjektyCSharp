using Microsoft.OpenApi.Models;
using PaperStoreApplication.Services.OptionsForServices;
using PaperStoreModel.Models;
using Serilog;
using Swashbuckle.AspNetCore.Filters;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Autorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();

});

builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddScoped<Container>();
builder.Services.AddOutputCache(items => items.AddPolicy
    ("ItemsCachePolicy", builder => builder.Tag("Qty").Tag("ProductName").Tag("AddtionalInfoId"))); //First attempt to cache policy

builder.Services.AddControllersWithViews()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddAutoMapper(typeof(DTOProfiles));

var app = builder.Build();

app.UseExceptionHandler(builder => builder.Use(async (context, next) =>
{
    try
    {
        await next.Invoke(context);
    }
    catch (Exception){}
}));
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var loggerFactory = app.Services.GetService<ILoggerFactory>();
loggerFactory.AddFile(builder.Configuration["Logging:LogFilePath"].ToString());//Only for log in to file (Serilog extension)

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseOutputCache();

app.MapControllers();

app.Run();
