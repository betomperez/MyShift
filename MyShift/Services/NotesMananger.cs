using System.IO.Enumeration;
using System.Text.Json;

namespace MyShift.Services;

class NotesMananger
{
    public Dictionary<DateTime, String> notes = new Dictionary<DateTime, string>();

    public bool upToDateDictionary = false;

    private string _fileName = "mynotes.json";

    public void SaveNotes()
    {
        string path = Path.Combine(FileSystem.AppDataDirectory, _fileName);
        string json = JsonSerializer.Serialize(notes);
        File.WriteAllText(path, json);
    }

    public void LoadNotes()
    {
        string path = Path.Combine(FileSystem.AppDataDirectory, _fileName);
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            notes = JsonSerializer.Deserialize<Dictionary<DateTime, string>>(json)!;
            upToDateDictionary = false;
        }
    }
}
