using Blazored.Modal;
using Blazored.Toast;
using BlazorSite.Components;
using BlazorSite.Services;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IHttpClient, HttpClientFactory>();
builder.Services.AddScoped<IEmployeeInterface, EmployeeService>();
builder.Services.AddScoped<IDepertmentInterface, DepartmentService>();

builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddSignalR();
builder.Services.AddServerSideBlazor().AddCircuitOptions(x => { x.DetailedErrors = true; });
builder.Services.AddControllers();
builder.Services.AddBlazoredModal();
builder.Services.AddBlazoredToast();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.MapControllers();

app.Run();
