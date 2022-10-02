using Note.ViewModels;

namespace Note.Pages;

public partial class ViewNotePage : ContentPage
{
	private readonly ViewNoteViewModel viewModel;
	public ViewNotePage(ViewNoteViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
		this.viewModel = viewModel;
	}

	protected override void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);
		viewModel.RetriveAllNotes();
    }

	protected override bool OnBackButtonPressed()
    {
        Shell.Current.GoToAsync("..?id=0");
		return base.OnBackButtonPressed();
	}
}