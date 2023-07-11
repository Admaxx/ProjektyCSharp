using AspNetCoreRateLimit;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PaperStoreApplication.Contexts;
using PaperStoreApplication.Services.OptionsForServices;
using PaperStoreModel.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var dbConnection = builder.Configuration["Connection:dbString"];
builder.Services.AddDbContext<PaperWarehouseContext>(item => item.UseSqlServer(dbConnection));

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAuthentication().AddJwtBearer();
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
builder.Services.AddMemoryCache();
builder.Services.Configure<IpRateLimitOptions>(items =>
{
    items.EnableEndpointRateLimiting = true;
    items.StackBlockedRequests = false;
    items.HttpStatusCode = 429;
    items.RealIpHeader = "X-Real-IP";
    items.ClientIdHeader = "X-Client-IP";
    items.GeneralRules = new List<RateLimitRule>
    {
        new RateLimitRule
        {
            Endpoint = builder.Configuration["RateLimitEndPoints:ActualInventory:Name"],
            Period = builder.Configuration["RateLimitEndPoints:ActualInventory:Period"],
            Limit = Convert.ToDouble(builder.Configuration["RateLimitEndPoints:ActualInventory:Limit"] ?? Convert.ToString(1))
        },
        new RateLimitRule
        {
            Endpoint = builder.Configuration["RateLimitEndPoints:Account:Name"],
            Period = builder.Configuration["RateLimitEndPoints:Account:Period"],
            Limit = Convert.ToDouble(builder.Configuration["RateLimitEndPoints:Account:Limit"] ?? Convert.ToString(1))
        },
        new RateLimitRule
        {
            Endpoint = builder.Configuration["RateLimitEndPoints:LastItem:Name"],
            Period = builder.Configuration["RateLimitEndPoints:LastItem:Period"],
            Limit = Convert.ToDouble(builder.Configuration["RateLimitEndPoints:LastItem:Limit"] ?? Convert.ToString(1))
        },
        new RateLimitRule
        {
            Endpoint = builder.Configuration["RateLimitEndPoints:Health:Name"],
            Period = builder.Configuration["RateLimitEndPoints:Health:Period"],
            Limit = Convert.ToDouble(builder.Configuration["RateLimitEndPoints:Health:Limit"] ?? Convert.ToString(1))
        }
    };
});

builder.Services.AddScoped<Container>();
builder.Services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
builder.Services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
builder.Services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();
builder.Services.AddInMemoryRateLimiting();
builder.Services.AddOutputCache(items => items.AddPolicy
    ("ItemsCachePolicy", builder => builder.Tag("Qty").Tag("ProductName").Tag("AddtionalInfoId"))); //First attempt to cache policy

builder.Services.AddControllersWithViews()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddAutoMapper(typeof(DTOProfiles));

//Api health checking only for now
builder.Services.AddHealthChecks();//.AddRedis(builder.Configuration["Connection:dbString"].ToString(), "Redis", HealthStatus.Unhealthy);

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

app.UseIpRateLimiting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseOutputCache();

app.MapControllers();

app.Run();
