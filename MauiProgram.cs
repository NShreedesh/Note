using Note.Data;
using Note.Pages;
using Note.ViewModels;

namespace Note;

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

		builder.Services.AddScoped<CreateNotePage, CreateNotePage>();
		builder.Services.AddScoped<ViewNotePage, ViewNotePage>();
		builder.Services.AddScoped<CreateNoteViewModel, CreateNoteViewModel>();
		builder.Services.AddScoped<ViewNoteViewModel, ViewNoteViewModel>();
		builder.Services.AddSingleton<IDatabaseContext, DatabaseContext>();

		return builder.Build();
	}
}
