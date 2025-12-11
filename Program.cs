using MediFlow.Web.Infra.Context;    
using MediFlow.Web.Infra.Repositories; 
using MediFlow.Web.Domain.Interfaces;  
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// --- CONFIGURAÇÃO DE SERVIÇOS ---

builder.Services.AddRazorPages();
builder.Services.AddControllers();

// 1. Configura o Banco de Dados
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("MediFlowDb"));

// 2. Injeta os Repositórios e UnitOfWork
builder.Services.AddScoped<ICirurgiaRepository, CirurgiaRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// --------------------------------

var app = builder.Build();

// Garante que o banco seja criado e populado com o Seed
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated(); // Isso roda o Seed que definimos no Context
}

// Configurações de Pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
else
{
    // Opcional: Swagger se quiser testar API visualmente
    // app.UseSwagger(); 
    // app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.Run();