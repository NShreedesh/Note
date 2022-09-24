using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Note.Data;
using Note.Models;
using Note.Pages;

namespace Note.ViewModels
{
    public partial class CreateNoteViewModel : ObservableObject
    {
        [ObservableProperty]
        private string title;
        [ObservableProperty]
        private string note;

        private readonly IDatabaseContext databaseContext;

        public CreateNoteViewModel(IDatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        [RelayCommand]
        public async void SaveButtonClick()
        {
            if (string.IsNullOrWhiteSpace(Title))
            {
                await Shell.Current.DisplayAlert("Note", "Please Insert title...", "Ok");
                return;
            }

            NoteTable note = new NoteTable()
            {
                Title = this.Title,
                NoteList = this.Note
            };
            await databaseContext.AddNewNote(note);
            await Shell.Current.GoToAsync($"{nameof(ViewNotePage)}", true);
           
        }

        [RelayCommand]
        public async void ViewNoteButtonClick()
        {
            await Shell.Current.GoToAsync($"{nameof(ViewNotePage)}", true);
        }
    }
}
