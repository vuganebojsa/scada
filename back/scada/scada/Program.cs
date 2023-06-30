using Microsoft.EntityFrameworkCore;
using scada.Data;
using scada.Interfaces;
using scada.Models;
using scada.Repository;
using System.Net;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyDatabase"));
});
builder.Services.AddRazorPages();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddControllers(); // Add the controllers services
builder.Services.AddAuthorization(); // Add the authorization services
var app = builder.Build();
//AddUserToDatabase(app.Services.CreateScope().ServiceProvider);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



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
        Name = "Johndd Doe",
        
    };

    // Add the user to the database
    context.Users.Add(user);
    context.SaveChanges();
}*/