using IScore.Data;
using IScore.Services;
using IScore.ViewModels;
using IScore.Views;
using Microsoft.Extensions.Logging;
namespace IScore
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddTransient<DatabaseContext>();


            builder.Services.AddTransient<TournamentPage>();
            builder.Services.AddTransient<TournamentViewModel>();
            builder.Services.AddSingleton<TournamentService>();



#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
