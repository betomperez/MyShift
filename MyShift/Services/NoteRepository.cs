using MyShift.Models;
using SQLite;
using MyShift.Resources.Languages;

namespace MyShift.Services;

public class NoteRepository
{
    string _dbPath;

    public string StatusMessage { get; set; }

    private SQLiteConnection _conn;

    private void Init()
    {
        if (_conn != null)
        {
            return;
        }
        _conn = new SQLiteConnection(_dbPath);
        _conn.CreateTable<Note>();
    }

    public NoteRepository(string dbPath)
    {
        _dbPath = dbPath;
        StatusMessage = "";
        Init();
    }

    public void AddNewNoteOrUpdateExistingNote(Note note)
    {
        int result = 0;

        try
        {
            Init();

            if (string.IsNullOrEmpty(note.TextNote))
            {
                return;
            }

            Note existingNote = GetNoteByDate(note.Date);
            if (existingNote == null)
            {
                result = _conn.Insert(note);
                StatusMessage = $"{AppStrings.AddNote} {DateOnly.FromDateTime(note.Date)}";
            }
            else
            {
                result = _conn.Update(note);
                StatusMessage = $"{AppStrings.UpdateNote} {DateOnly.FromDateTime(note.Date)}";
            }
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Failed to add {0}. Error: {1}", note, ex.Message);
        }
    }

    public Note GetNoteByDate(DateTime date)
    {
        var note = from n in _conn.Table<Note>()
                   where n.Date == date
                   select n;
        return note.FirstOrDefault();
    }

    public void DeleteNoteByDate(DateTime date)
    {
        try
        {
            int result = 0;
            result = _conn.Delete<Note>(date);
            StatusMessage = $"{AppStrings.DeleteNote} {DateOnly.FromDateTime(date)}";
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Failed to delete note. Error: {0}", ex.Message);
        }
    }
}