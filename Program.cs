
using MyApp.Services.ApiClient;
using MyApp.Services.DictionaryService;
using MyApp.Services.JokesService;
using MyApp.Services.WordsService;

namespace MyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddHttpClient();
            builder.Services.AddCors();
            builder.Services
                .AddSingleton<IApiClient,ApiClient>()               // ����� ������� � ��� ������ ��� �����䳿 �� HttpClient, �� �������������, �� ������ ������ ����������, ���� ��� ������ �� ������ ��'����� ������ ��������������� AddSingleton
                .AddSingleton<IWordsService, WordsService>()        // ����� ������� � ��� ��������� ������� ������ ��� �� ������ �����䳿 �� ���. ��� ������ �� ������ ��'����� ������ ��������������� AddSingleton
                .AddSingleton<IJokesService, JokesService>()        // ����� ������� � ��� ��������� ������� ������ ����� �� ������ �����䳿 �� ���. ��� ������ �� ������ ��'����� ������ ��������������� AddSingleton
                .AddScoped<IDictionaryService, DictionaryService>();// ����� ����������� ��� ������ ������, ���� ���� �������� ��� ����. ��� ��������� ��� ��� ��������������� AddScoped
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
        }
    }
}
