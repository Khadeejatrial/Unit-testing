using Unit_testing.trial.Contracts;
using Unit_testing.trial.Application;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddScoped<IEligibilityServices, Eligibility>();
builder.Services.AddScoped<IQualification, Qualification>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
