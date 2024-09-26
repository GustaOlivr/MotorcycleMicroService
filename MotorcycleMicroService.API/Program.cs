using MotorcycleMicroService.CrossCutting.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Configura��es de Kestrel para escutar na porta 8082
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(8082); // Define a porta 8082 para o servi�o de motocicletas
});

// Registro de servi�os na IoC
builder.Services.RegisterServices(builder.Configuration.GetConnectionString("DefaultConnection"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura��o do CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure o pipeline de requisi��es HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
