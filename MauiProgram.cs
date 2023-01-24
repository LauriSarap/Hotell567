namespace Hotell567;

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

		// Associate the pages with eachother
		// Create a new page every time
        builder.Services.AddTransient<MVVM.RoomsPage>();
        builder.Services.AddTransient<Models.RoomViewModel>();

        return builder.Build();
	}
}
