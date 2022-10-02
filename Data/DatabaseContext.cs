using SQLite;
using Note.Models;

namespace Note.Data;

public class DatabaseContext : IDatabaseContext
{
    string fileName = "MyNotes.db3";
    SQLiteAsyncConnection connection;

    public async Task Init()
    {
        if (connection != null)
            return;

        var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        connection = new SQLiteAsyncConnection(Path.Combine(path, fileName));

        await connection.CreateTableAsync<NoteTable>();
    }

    public async Task<List<NoteTable>> GetAllNotes()
    {
        await Init();
        var users = await connection.Table<NoteTable>().ToListAsync();
        return users;
    }

    public async Task<NoteTable> GetOneNote(int id)
    {
        await Init();
        var user = await connection.GetAsync<NoteTable>(id);
        return user;
    }

    public async Task AddNewNote(NoteTable note)
    {
        await Init();
        await connection.InsertAsync(note);
    }

    public async Task DeleteOneNote(NoteTable noteTable)
    {
        await Init();
        await connection.DeleteAsync(noteTable);
    }

    public async Task DeleteAllNotes()
    {
        await Init();
        await connection.DeleteAllAsync<NoteTable>();
    }

    public async Task UpdateNote(NoteTable noteTable)
    {
        await Init();
        await connection.UpdateAsync(noteTable);
    }
}
