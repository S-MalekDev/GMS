

using APILayer.Middleware;
using CoreLayer.Configurations;
using Microsoft.Extensions.FileProviders;
using APILayer.Extentions;


var builder = WebApplication.CreateBuilder(args);


var generalSettings = builder.Configuration.GetSection("GeneralSettings").Get<GeneralSettings>();
var personImageDirectory = generalSettings?.PersonImageUploadDirectory;
if (!Directory.Exists(personImageDirectory))
    Directory.CreateDirectory(personImageDirectory!);

builder.Services.RegisterApplicationServices(builder.Configuration);


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
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(personImageDirectory!),
    RequestPath = "/images"
});

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
