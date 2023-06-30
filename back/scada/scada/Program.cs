using Microsoft.EntityFrameworkCore;
using scada.Data;
using scada.Models;
using System.Net;

var builder = WebApplication.CreateBuilder(args);






builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyDatabase"));
});

var app = builder.Build();
AddUserToDatabase(app.Services.CreateScope().ServiceProvider);

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

app.Run();

void AddUserToDatabase(IServiceProvider serviceProvider)
{
    using var scope = serviceProvider.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<DataContext>();

    // Create a new User object
    var user = new User
    {
        // Set user properties as needed
        Name = "John Doe",
        Id = 1
    };

    // Add the user to the database
    context.Users.Add(user);
    context.SaveChanges();
}