using Note.Data;
using Note.ViewModels;

namespace Note.Pages;

public partial class CreateNotePage : ContentPage
{
	public CreateNotePage(CreateNoteViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}