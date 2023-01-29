using Hotell567.Logic;

namespace Hotell567;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		
		builder.UseMauiApp<App>().ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        AppManager.isInitialized = true;
        
		
        builder.Services.AddTransient<MVVM.RoomsPage>();
        builder.Services.AddTransient<Data.RoomsViewModel>();

        return builder.Build();
	}
}
