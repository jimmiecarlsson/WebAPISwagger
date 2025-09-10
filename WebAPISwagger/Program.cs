using WebAPISwagger;

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

app.MapGet($"/testall", () =>
{
    return ViewModelData.Items;
});

app.MapGet($"/test", (int id) =>
{
    var viewModel = ViewModelData.Items.FirstOrDefault(x => x.Id == id);
    return viewModel is not null
        ? Results.Ok($"Namn: {viewModel.Name} - Beskrivning: {viewModel.Description}")
        : Results.NotFound("Inga poster");
});

app.MapGet($"/testtext", (int id) =>
{
    var viewModel = ViewModelData.Items.FirstOrDefault(x => x.Id == id);
    return viewModel is not null
        ? Results.Text($"Namn: {viewModel.Name} - Beskrivning: {viewModel.Description}")
        : Results.NotFound("Inga poster");
});


app.MapPut($"/test", (ViewModel model) =>
{
    var existingItem = ViewModelData.Items.FirstOrDefault(x => x.Id == model.Id);
    if (existingItem != null)
    {
        existingItem.Name = model.Name;
        existingItem.Description = model.Description;
        return Results.Ok(existingItem);
    }
    return Results.NotFound();
});

//app.MapGet("/", () => {
//    return new string[] {
//        "Hello World!",
//        "This is a simple Web API with Swagger documentation."
//    };
//});

// Run the application.
app.Run();
