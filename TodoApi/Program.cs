using Database;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.CookiePolicy;
using Repositories.Interfaces;
using Repositories.Repositories;
using Services.Interfaces;
using Services.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddLogging();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => 
{
    options.AddPolicy("Allow8080", // port of the frontend app
        builder => 
        {
            builder.WithOrigins("http://localhost:8080")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

builder.Services.Configure<SmtpValuesModel>(options => builder.Configuration.GetSection("SmtpValues").Bind(options));

builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddScoped<IHeaderContextService, HeaderContextService>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<UnitOfWork>();

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddHostedService<NotificationWorker>();
builder.Services.AddHttpContextAccessor();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
options =>
{
    options.Events.OnRedirectToLogin = context =>
    {
        context.Response.Headers["Location"] =
        context.RedirectUri;
        context.Response.StatusCode = 401;
        return Task.CompletedTask;
    };
}) ;
builder.Services.AddAuthorization();

builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
}

app.UseCors(options => options
        .WithOrigins(new[] {"http://localhost:8080"})
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials()
    );

app.UseHttpsRedirection();

var cookiePolicyOptions = new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.None,
    HttpOnly = HttpOnlyPolicy.Always,
    Secure = CookieSecurePolicy.Always,
};
app.UseCookiePolicy(cookiePolicyOptions);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
