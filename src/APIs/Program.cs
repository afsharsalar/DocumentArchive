
using DocumentArchive.APIs.ErrorHandling;

var builder = WebApplication.CreateBuilder(args);


builder.Configuration.AddEnvironmentVariables();


builder.Services.ConfigureApplicationLayer(builder.Configuration);
builder.Services.ConfigureInfrastructureLayer(builder.Configuration);

builder.Services.ConfigureMapster();
builder.Services.ConfigureValidator();
builder.Services.ConfigureCors();

builder.Services.AddEndpoints();
builder.Services.AddJWT(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddAuthorization();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();


app.MapEndpoints();

app.Run();
