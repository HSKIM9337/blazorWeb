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
		private IConfiguration _configuration { get; }

		public Program(IConfiguration configuration)
		{
			_configuration = configuration;
		}
        
        public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddRazorPages();
			builder.Services.AddServerSideBlazor();
			builder.Services.AddSingleton<WeatherForecastService>();
			//builder.Services.AddSingleton<IDBHelper, DBHelper>();
			builder.Services.AddDbContext<ApplicationDbContext>(options =>
			   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

			var app = builder.Build();

			//InitializeDatabase(app);

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
		//private static async Task InitializeDatabase(WebApplication app)
  //      {
  //          // 데이터베이스 초기화를 위해 필요한 서비스 가져오기
  //          using (var scope = app.Services.CreateScope())
  //          {
  //              var services = scope.ServiceProvider;
  //              var dbHelper = services.GetRequiredService<IDBHelper>();
  //              await dbHelper.InitializeAsync(); // 데이터베이스 초기화 비동기 메서드 호출
				
		//	}
  //      }



		


    }
}