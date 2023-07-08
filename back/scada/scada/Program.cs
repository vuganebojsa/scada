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

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyDatabase"));
});
builder.Services.AddRazorPages();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAlarmRepository, AlarmRepositroy>();
builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddScoped<IReportRepository, ReportRepository>();
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped<ITagService, TagService>();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
}); // Add the controllers services
//            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;

builder.Services.AddTransient<Seed>();

builder.Services.AddAuthorization(); // Add the authorization services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers(); // Map the controllers endpoints
});

app.Run();

/*void AddUserToDatabase(IServiceProvider serviceProvider)
{
    using var scope = serviceProvider.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<DataContext>();

    // Create a new User object
    var user = new User
    {
        // Set user properties as needed
        Username = "admin",
        Password = "admin",
        Role = "admin"
        
    };
    var user1 = new User
    {
        Username = "user",
        Password = "user",
        Role = "user"
    };

    // Add the user to the database
    context.Users.Add(user);
    context.Users.Add(user1);
    context.SaveChanges();
}*/