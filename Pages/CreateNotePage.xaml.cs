using Note.Data;
using Note.ViewModels;

namespace Note.Pages;

public partial class CreateNotePage : ContentPage
{
	private readonly CreateNoteViewModel viewModel;

	public CreateNotePage(CreateNoteViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
		this.viewModel = viewModel;
	}

	protected override void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);
		viewModel.ChangeButtonName();
	}
}