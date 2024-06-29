using AutoMapper;
using Fiap.Api.Residuos.Data;
using Fiap.Api.Residuos.Data.Repository;
using Fiap.Api.Residuos.Models;
using Fiap.Api.Residuos.Services;
using Fiap.Api.Residuos.ViewModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

#region INICIALIZANDO O BANCO DE DADOS
var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
builder.Services.AddDbContext<DatabaseContext>(
    opt => opt.UseOracle(connectionString).EnableSensitiveDataLogging(true)
);
#endregion


#region Auth
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("f+ujXAKHk00L5jlMXo2XhAWawsOoihNP1OiAM25lLSO57+X7uBMQgwPju6yzyePi")),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
#endregion

#region Repositorios
builder.Services.AddScoped<IMoradorRepository, MoradorRepository>();
builder.Services.AddScoped<ILixeiraRepository, LixeiraRepository>();
builder.Services.AddScoped<INotificacaoRepository, NotificacaoRepository>();
#endregion


#region Services
builder.Services.AddScoped<IMoradorService, MoradorService>();
builder.Services.AddScoped<ILixeiraService, LixeiraService>();
builder.Services.AddScoped<INotificacaoService, NotificacaoService>();
#endregion


#region AutoMapper
// Configuração do AutoMapper
var mapperConfig = new AutoMapper.MapperConfiguration(c =>

{
    // Permite que coleções nulas sejam mapeadas
    c.AllowNullCollections = true;
    // Permite que valores de destino nulos sejam mapeados
    c.AllowNullDestinationValues = true;

    c.CreateMap<MoradorModel, MoradorViewModel>();
    c.CreateMap<MoradorViewModel, MoradorModel>();
    c.CreateMap<LixeiraModel, LixeiraViewModel>();
    c.CreateMap<LixeiraViewModel, LixeiraModel>();
    c.CreateMap<NotificacaoModel, NotificacaoViewModel>();
    c.CreateMap<NotificacaoViewModel, NotificacaoModel>();
});


// Cria o mapper com base na configuração definida
IMapper mapper = mapperConfig.CreateMapper();

// Registra o IMapper como um serviço singleton no container de DI do ASP.NET Core
builder.Services.AddSingleton(mapper);

#endregion






builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
