using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using server.Data;
using server.DB;
using server.DB.SQL;
using Microsoft.Extensions.DependencyInjection;
using static System.Net.Mime.MediaTypeNames;


namespace server
{
	public class Program
	{
        
        public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddRazorPages();
			builder.Services.AddServerSideBlazor();
			builder.Services.AddSingleton<WeatherForecastService>();
			builder.Services.AddSingleton<IDBHelper, DBHelper>();

			var app = builder.Build();

			InitializeDatabase(app);

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();

			app.UseStaticFiles();

			app.UseRouting();

			app.MapBlazorHub();
			app.MapFallbackToPage("/_Host");

			app.Run();
		}

        private static async Task InitializeDatabase(WebApplication app)
        {
            // �����ͺ��̽� �ʱ�ȭ�� ���� �ʿ��� ���� ��������
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var dbHelper = services.GetRequiredService<IDBHelper>();
                await dbHelper.InitializeAsync(); // �����ͺ��̽� �ʱ�ȭ �񵿱� �޼��� ȣ��
				
			}
        }

		


    }
}