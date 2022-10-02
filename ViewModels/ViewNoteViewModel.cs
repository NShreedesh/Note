using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Note.Data;
using Note.Models;
using Note.Pages;
using System.Collections.ObjectModel;

namespace Note.ViewModels;

public partial class ViewNoteViewModel : ObservableObject
{
    public IDatabaseContext databaseContext;

    public ObservableCollection<NoteTable> NoteCollection { get; } = new ObservableCollection<NoteTable>();

    [ObservableProperty]
    private int counter;

    public ViewNoteViewModel(IDatabaseContext databaseContext)
    {
        this.databaseContext = databaseContext;
    }

    public async void RetriveAllNotes()
    {
        var notes = await databaseContext.GetAllNotes();
        await Task.Run(() =>
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                NoteCollection.Clear();
                foreach (var note in notes)
                {
                    NoteCollection.Add(note);
                }
            });
        });
    }

    [RelayCommand]
    public async void DeleteNote(object noteTable)
    {
        var note = noteTable as NoteTable;
        await databaseContext.DeleteOneNote(note);
        NoteCollection.Remove(note);
    }

    [RelayCommand]
    public async void NoteItemTapped(object noteId)
    {
        await Shell.Current.GoToAsync($"..?id={(int)noteId}", true);
    }
}
