var builder = WebApplication.CreateBuilder(args);

// Register services to the container.

//builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => {
    return new string[] {
        "Hello World!",
        "This is a simple Web API with Swagger documentation."
    };
});

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

// Run the application.
app.Run();
