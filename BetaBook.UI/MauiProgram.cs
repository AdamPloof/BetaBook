using Microsoft.Extensions.Logging;

using BetaBook.Core;
using BetaBook.Core.Data;
using BetaBook.UI.Services;

namespace BetaBook.UI;

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
		builder.Services.AddSingleton<IDbConfigProvider, MauiDbConfigProvider>();
		builder.Services.AddEntityManagement();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
