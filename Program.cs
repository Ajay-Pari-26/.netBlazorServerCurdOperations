using HospitalManagementServer.Components;
using HospitalManagementServer.Data;
using HospitalManagementServer.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Configure PostgreSQL Database Context
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Services for Dependency Injection
builder.Services.AddScoped<IDoctorService, DoctorService>();

builder.Services.AddScoped<IPatientService, PatientService>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts(); // Enforce HTTPS in production
}

app.UseHttpsRedirection();
app.UseWebSockets(); // Enable WebSockets for real-time communication
app.UseStaticFiles(); // Serve static files
app.UseAntiforgery(); // Protect against CSRF attacks

// Map Razor Components to the application
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
