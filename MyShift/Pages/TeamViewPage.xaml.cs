using MyShift.Services;

namespace MyShift.Pages;

public partial class TeamViewPage : ContentPage
{
    private ShiftMananger _shiftManager;
    private int offset = 4;

    private NotesMananger _notesManager;
    public TeamViewPage()
	{
		InitializeComponent();
        _shiftManager = new ShiftMananger();
        _notesManager = new NotesMananger();
        BindingContext = _shiftManager;
        _shiftManager.RefreshShifts(DateOnly.FromDateTime(DateView.Date), offset);
    }

    private void OnYesterdayButtonClicked(object sender, EventArgs e)
    {
        DateView.Date = DateView.Date.AddDays(-1);
        _shiftManager.RefreshShifts(DateOnly.FromDateTime(DateView.Date), offset);
    }

    private void OnHomeButtonClicked(object sender, EventArgs e)
    {
        DateView.Date = DateTime.Today;
        _shiftManager.RefreshShifts(DateOnly.FromDateTime(DateView.Date), offset);
    }

    private void OnTomorrowButtonClicked(object sender, EventArgs e)
    {
        DateView.Date = DateView.Date.AddDays(1);
        _shiftManager.RefreshShifts(DateOnly.FromDateTime(DateView.Date), offset);
    }

    private void OnDateViewDateSelected(object sender, DateChangedEventArgs e)
    {
        _shiftManager.RefreshShifts(DateOnly.FromDateTime(DateView.Date), offset);
        DateTime selectedDateTime = e.NewDate;
        if (!_notesManager.upToDateDictionary) 
        {
            _notesManager.LoadNotes();
            _notesManager.upToDateDictionary = true;
        }
        if (_notesManager.notes.ContainsKey(selectedDateTime))
        {
            EditorNotes.Text = _notesManager.notes[selectedDateTime];
        }
        else
        {
            EditorNotes.Text = "";
        }
    }

    private void OnEditorNotesTextChanged(object sender, TextChangedEventArgs e)
    {
        DateTime selectedDate = DateView.Date;
        _notesManager.notes[selectedDate] = EditorNotes.Text;
        _notesManager.SaveNotes();
    }
}