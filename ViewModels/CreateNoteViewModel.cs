using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Note.Data;
using Note.Models;
using Note.Pages;

namespace Note.ViewModels
{
    [QueryProperty("Id", "id")]
    public partial class CreateNoteViewModel : ObservableObject
    {
        public int Id { get; set; }
        [ObservableProperty]
        private string title;
        [ObservableProperty]
        private string note;
        [ObservableProperty]
        private string saveButtonName;

        private readonly IDatabaseContext databaseContext;

        public CreateNoteViewModel(IDatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        [RelayCommand]
        public async void SaveOrUpdateButtonClick()
        {
            if (string.IsNullOrWhiteSpace(Title))
            {
                await Shell.Current.DisplayAlert("Note", "Please Insert title...", "Ok");
                return;
            }

            if(Id <= 0)
            {
                NoteTable note = new NoteTable()
                {
                    Title = this.Title,
                    NoteList = this.Note
                };
                await databaseContext.AddNewNote(note);
            }
            else
            {
                NoteTable noteTable = new NoteTable()
                {
                    Id = this.Id,
                    Title = this.Title,
                    NoteList = this.Note
                };
                await databaseContext.UpdateNote(noteTable);
            }

            Title = "";
            Note = "";
            Id = 0;

            await Shell.Current.GoToAsync($"{nameof(ViewNotePage)}", true);
        }

        [RelayCommand]
        public async void ViewNoteButtonClick()
        {
            await Shell.Current.GoToAsync($"{nameof(ViewNotePage)}", true);
        }

        public async void ChangeButtonName()
        {
            Console.WriteLine(Id);
            if(Id <= 0)
            {
                SaveButtonName = "Save";
            }
            else
            {
                SaveButtonName = "Update";
                var noteTable = await databaseContext.GetOneNote(Id);
                Title = noteTable.Title;
                Note = noteTable.NoteList;
            }
        }
    }
}
