using Lvmendes.Adm.Repositorio;
using Lvmendes.Adms.Entidade;
using Lvmendes.Adms.Repositorio;
using Lvmendes.Adms.Repositorio.Interfaces;
using Lvmendes.Adms.Servico;
using Lvmendes.Adms.Servico.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IEmpresaServico, EmpresaServico>();
builder.Services.AddScoped<IEmpresaRepositorio, EmpresaRepositorio>();

builder.Services.AddScoped<IPerfilServico, PerfilServico>();
builder.Services.AddScoped<IPerfilRepositorio, PerfilRepositorio>();


builder.Services.AddScoped<ICardapioServico, CardapioServico>();
builder.Services.AddScoped<ICardapioRepositorio, CardapioRepositorio>();


builder.Services.AddScoped<IMesaServico, MesaServico>();
builder.Services.AddScoped<IMesaRepositorio, MesaRepositorio>();

builder.Services.AddScoped<IUsuarioServico, UsuarioServico>();
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

builder.Services.AddScoped<IPedidoServico, PedidoServico>();
builder.Services.AddScoped<IPedidoRepositorio, PedidoRepositorio>();

builder.Services.AddScoped<IClienteServico, ClienteServico>();
builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();

builder.Services.AddCors();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AdmContext>(options => {
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});



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

app.UseCors(options =>
{
    options.WithOrigins("http://localhost:61824");
    //options.WithOrigins("https://usuarios3.s3.amazonaws.com", "http://localhost:4200");


    options.AllowAnyMethod();
    options.AllowAnyHeader();
});
app.Run();
