using Note.Pages;

namespace Note;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(ViewNotePage), typeof(ViewNotePage));
    }
}
