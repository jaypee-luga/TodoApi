using TodoApi;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

app.MapGet("/todoitems", async (TodoDb db) =>
 await db.Todos.ToListAsync());

app.MapGet("/todoitems/complete", async (TodoDb db) =>
 await db.Todos.Where(t => t.IsComplete).ToListAsync());



app.MapGet("/", () => "Hello World!");

app.Run();
