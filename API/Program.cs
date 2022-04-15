using API.Extension;

DotNetEnv.Env.Load();
var builder = WebApplication.CreateBuilder(args);

builder.Services.InstallSwagger();
builder.Services.InstallDatabase(builder.Configuration);
builder.Services.InstallJwt(builder.Configuration);
builder.Services.InstallApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.ConfigureSwagger();
}

app.ConfigureApi();

app.Run();
