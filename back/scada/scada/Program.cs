using Microsoft.EntityFrameworkCore;
using scada.Data;
using scada.Interfaces;
using scada.Models;
using scada.Repository;
using System.Net;
using Microsoft.Extensions.Options;
using scada.Services;
using scada;
using System.Text.Json.Serialization;
using scada.Hubs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyDatabase"));
}, ServiceLifetime.Singleton);
builder.Services.AddRazorPages();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAlarmRepository, AlarmRepositroy>();
builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddScoped<IReportRepository, ReportRepository>();
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped<ITagService, TagService>();
builder.Services.AddScoped<IAlarmService, AlarmService>();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
}); // Add the controllers services
//            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;

builder.Services.AddTransient<Seed>();

builder.Services.AddAuthorization(); // Add the authorization services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSignalR();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("AllowOrigins",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowCredentials().AllowAnyHeader();
        });
});

var app = builder.Build();
//AddUserToDatabase(app.Services.CreateScope().ServiceProvider);


if (args.Length == 1 && args[0].ToLower() == "seeddata")
    SeedData(app);

void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<Seed>();
        service.SeedDataContext();
    }
}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");

    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
   
}


app.UseCors("AllowOrigins");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();



app.MapControllers();

app.MapHub<InputTagsHub>("/hubs/inputTags");
app.MapHub<AlarmsHub>("/hubs/alarms");


app.Run(

);

