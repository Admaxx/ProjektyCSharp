using AspNetCoreRateLimit;
using worldWideApplication.Services.OptionsForServices;
using worldWideModels.AutoMapperModels;
using worldWideService.GlobalOptions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllHeaders",
        builder =>
        {
            builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
        });
});
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
            Endpoint = builder.Configuration["CityInfoOperations:GetOneCity:Name"],
            Period = builder.Configuration["CityInfoOperations:GetOneCity:Period"],
            Limit = Convert.ToDouble(builder.Configuration["CityInfoOperations:GetOneCity:Limit"] ?? Convert.ToString(1))
        },
        new RateLimitRule
        {
            Endpoint = builder.Configuration["CityInfoOperations:AddOneCity:Name"],
            Period = builder.Configuration["CityInfoOperations:AddOneCity:Period"],
            Limit = Convert.ToDouble(builder.Configuration["CityInfoOperations:AddOneCity:Limit"] ?? Convert.ToString(1))
        },
        new RateLimitRule
        {
            Endpoint = builder.Configuration["CityInfoOperations:GetRandomCity:Name"],
            Period = builder.Configuration["CityInfoOperations:GetRandomCity:Period"],
            Limit = Convert.ToDouble(builder.Configuration["CityInfoOperations:GetRandomCity:Limit"] ?? Convert.ToString(1))
        },
        new RateLimitRule
        {
            Endpoint = builder.Configuration["CityInfoOperations:GetAllCitiesByRegion:Name"],
            Period = builder.Configuration["CityInfoOperations:GetAllCitiesByRegion:Period"],
            Limit = Convert.ToDouble(builder.Configuration["CityInfoOperations:GetAllCitiesByRegion:Limit"] ?? Convert.ToString(1))
        }
    };
});
builder.Services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
builder.Services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
builder.Services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddInMemoryRateLimiting();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddAutoMapper(typeof(DTOProfiles));
builder.Services.AddScoped<MainContainer>();
builder.Services.AddHealthChecks();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Services.GetService<ILoggerFactory>();

app.UseIpRateLimiting();

app.UseMiddleware(typeof(GlobalErrorHandlingMiddleware));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
