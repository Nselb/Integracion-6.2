

using Coso1;
using Newtonsoft.Json;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
HttpClient client = new();

HttpResponseMessage response = await client.GetAsync("https://jsonplaceholder.typicode.com/users");

if (response.IsSuccessStatusCode)
{
    string json = await response.Content.ReadAsStringAsync();

    var users = JsonConvert.DeserializeObject<List<User>>(json);

    if (users != null)
    {
        foreach (var user in users)
        {
            Debug.WriteLine($"ID: {user.id}");
            Debug.WriteLine($"Nombre: {user.name}");
            Debug.WriteLine($"Email: {user.company}");
            Debug.WriteLine($"Direccion: {user.address}" );
            Debug.WriteLine($"Correo: {user.email}" );
        }
    }
}
// Add services to the container.

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


