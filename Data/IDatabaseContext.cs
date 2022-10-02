using Note.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note.Data;

public interface IDatabaseContext
{
    public Task AddNewNote(NoteTable note);
    public Task<List<NoteTable>> GetAllNotes();
    public Task<NoteTable> GetOneNote(int id);
    public Task DeleteOneNote(NoteTable noteTable);
    public Task DeleteAllNotes();
    public Task UpdateNote(NoteTable noteTable);
}
