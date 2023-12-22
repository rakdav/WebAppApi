using Microsoft.EntityFrameworkCore;
using WebAppApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DataContext>(opts => {
    opts.UseSqlServer(builder.Configuration[
    "ConnectionStrings:DefaultConnection"]);
    opts.EnableSensitiveDataLogging(true);
});
builder.Services.AddControllers();
var app = builder.Build();
app.MapControllers();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers(); // ���������� ������������� �� �����������
});
app.Run();