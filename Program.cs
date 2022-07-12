using Model;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

// I used docker to create the database, but the process is similar for other dbs
// docker run --name some-postgres -e POSTGRES_PASSWORD=mysecretpassword -d postgres
builder.Services.AddDbContext<ZooContext>(options =>
    {
        options.UseNpgsql("User ID=postgres;host=localhost;Port=5432;Database=ZooDB;Pooling=true;Password=aa12345678;");
    });

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

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
app.MapControllers();


app.MapRazorPages();

app.Run();

// initial set up, see README.md