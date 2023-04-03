using System.Text.Json;
using System.Text.Json.Serialization;
using CrossMintChallenge.Clients;
using CrossMintChallenge.Core.Interfaces;
using CrossMintChallenge.Core.Options;
using CrossMintChallenge.Services.CrossMint;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Refit;

var builder = WebApplication.CreateBuilder(args);


// Add Swagger documentation
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

// Settings
CrossMintOptions crossMintOptions = new CrossMintOptions();
builder.Configuration.GetSection(CrossMintOptions.Section).Bind(crossMintOptions);

// Services
builder.Services.AddScoped<IMegaverseService, MegaverseService>();
builder.Services.AddScoped<ICrossMintChallengeService, CrossMintChallengeService>();
builder.Services.AddScoped<ICrossMintCandidateService, CrossMintCandidateService>();


builder.Services
    .AddRefitClient<IMegaverseClient>( new RefitSettings(new NewtonsoftJsonContentSerializer(new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() })))
    .ConfigureHttpClient(c => c.BaseAddress = new Uri(crossMintOptions.BaseAddress));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
