var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UsePathBase("/api1");

app.Use(async (context, next) =>
{
    var remoteIpAddress = context.Request?.HttpContext?.Connection?.RemoteIpAddress;
    Console.WriteLine($"{remoteIpAddress} - {context?.Request?.Path.Value?.ToString()}");
    await next();
});

app.UseSwagger();
app.UseSwaggerUI();

// app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

Console.WriteLine("STARTING");


app.Run();
