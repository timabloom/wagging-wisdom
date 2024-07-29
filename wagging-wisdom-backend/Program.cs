var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:5173");
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.MapGet("/quote", () =>
{
    Random random = new Random();
    int number = random.Next(1, 16);
    var wiseDogQuotes = new string[]
        {
            "“The best things in life are simple: a warm sunbeam, a loyal friend, and a good belly rub.”",
            "“In every wag of my tail lies the secret to happiness: live in the moment and cherish those you love.”",
            "“Sometimes, the greatest lessons come from watching the world go by. Patience is a virtue, especially when waiting for treats.”",
            "“True wisdom is knowing that the best things come to those who wait—especially if it's a tasty snack!”",
            "“Life is like a game of fetch: sometimes you chase, sometimes you wait, but it's always more fun with a friend by your side.”",
            "“When the world feels overwhelming, remember: a little playtime and a good nap can solve almost anything.”",
            "“The heart knows no bounds; love is as simple as a wagging tail and a gentle nuzzle.”",
            "“Every day is a new adventure, and every moment is a chance to learn something new—especially about treats!”",
            "“A wagging tail is the best way to show the world that happiness is a choice, not a destination.”",
            "“In the grand adventure of life, remember: every moment is a chance to chase joy, even if it's just a butterfly.”",
            "“The path to true happiness is paved with love, loyalty, and the occasional treat.”",
            "“Sometimes, the best way to solve a problem is to take a nap and let your dreams do the thinking.”",
            "“Every bark carries a story; listen closely, and you'll learn the language of love.”",
            "“True companionship is not measured by the time spent together, but by the love shared in each moment.”",
            "“Life is short, so fill it with joy, run freely, and never underestimate the power of a good scratch behind the ears.”",
            "“When life gets ruff, remember that a little playtime can turn any day around.”"
        };
    return Results.Json(wiseDogQuotes[number]);
});

app.Run();
