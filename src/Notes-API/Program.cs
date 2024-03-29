using Data;
using Data.Interfaces;
using Data.Models;
using Data.Repositories;
using Logic;
using Logic.Interfaces;
using Logic.Mappers;
using Logic.Models;
using Microsoft.AspNetCore.Mvc;
using Notes_API.Filters;
using Notes_API.Middlewares;
using Notes_API.Session;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.Filters.Add(new ValidationFilter());
});

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddScoped<INoteRepository, NoteRepository>();
builder.Services.AddScoped<INoteService, NoteService>();
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<IMapper<NoteModel, Note>, NoteModelToNoteMapper>();
builder.Services.AddSingleton<IMapper<NoteUpdateModel, Note>, NoteUpdateModelToNoteMapper>();
builder.Services.AddSingleton<IUserSession, UserSession>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (builder.Configuration.GetValue<bool>("SeedDb"))
{
    using var context = new NotesContext();
    context.Database.EnsureCreated();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseMiddleware<BasicAuthMiddleware>();

app.MapControllers();

app.Run();