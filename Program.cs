using Microsoft.EntityFrameworkCore;
using Leaderboard.Data;
using Leaderboard.Mappers;
using Leaderboard.Repositories.Implementations;
using Leaderboard.Repositories.Interfaces;
using Leaderboard.Services.Implementations;
using Leaderboard.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    b => b.MigrationsAssembly("Leaderboard")));

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<ILeaderboardService, LeaderBoardService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IGameRecordService, GameRecordService>();

builder.Services.AddAutoMapper(typeof(UserMapper));
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
