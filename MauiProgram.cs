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
                .RegisterDbContent()
                .RegisterServices()
                .RegisterViewModels()
                .RegisterViews()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });


            //builder.Services.AddSingleton<TournamentPage>();
            //builder.Services.AddSingleton<TournamentViewModel>();

            // builder.Services.AddTransient<AddTournamentPage>();
            //builder.Services.AddTransient<AddTournamentViewModel>();
            // builder.Services.AddTransient<TournamentDetailPage>();
            //builder.Services.AddTransient<TournamentDetailViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        public static MauiAppBuilder RegisterDbContent(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<DatabaseContext>();
            return mauiAppBuilder;
        }
        public static MauiAppBuilder RegisterServices(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<TournamentService>();
            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<TournamentViewModel>();
            mauiAppBuilder.Services.AddSingleton<AddTournamentViewModel>();
            mauiAppBuilder.Services.AddSingleton<TournamentDetailViewModel>();
            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<TournamentPage>();
            mauiAppBuilder.Services.AddSingleton<AddTournamentPage>();
            mauiAppBuilder.Services.AddSingleton<TournamentDetailPage>();
            return mauiAppBuilder;
        }
    }
}
