using MyShift.Models;
using MyShift.Services;
using MyShift.Resources.Languages;

namespace MyShift.Pages;

public partial class TeamViewPage : ContentPage
{
    private ShiftMananger _shiftManager;
    private int offset = 4;

    public TeamViewPage()
    {
        InitializeComponent();
        _shiftManager = new ShiftMananger();
        BindingContext = _shiftManager;
        _shiftManager.RefreshShifts(DateOnly.FromDateTime(DateView.Date), offset);
        UpdateLabelAndEditor();
    }

    private void UpdateLabelAndEditor()
    {
        _shiftManager.RefreshShifts(DateOnly.FromDateTime(DateView.Date), offset);
        EditorNotes.Text = App.NoteRepo.GetNoteByDate(DateView.Date)?.TextNote;
    }

    private void OnYesterdayButtonClicked(object sender, EventArgs e)
    {
        DateView.Date = DateView.Date.AddDays(-1);
        UpdateLabelAndEditor();
    }

    private void OnHomeButtonClicked(object sender, EventArgs e)
    {
        DateView.Date = DateTime.Today;
        UpdateLabelAndEditor();
    }

    private void OnTomorrowButtonClicked(object sender, EventArgs e)
    {
        DateView.Date = DateView.Date.AddDays(1);
        UpdateLabelAndEditor();
    }

    private void OnDateViewDateSelected(object sender, DateChangedEventArgs e)
    {

        _shiftManager.RefreshShifts(DateOnly.FromDateTime(DateView.Date), offset);
        DateTime selectedDateTime = e.NewDate;
        Note selectedNote = App.NoteRepo.GetNoteByDate(selectedDateTime);
        EditorNotes.Text = selectedNote?.TextNote;
    }

    private void OnSaveButtonClicked(object sender, EventArgs e)
    {
        DateTime selectedDate = DateView.Date;
        Note newNote = new Note
        {
            Date = selectedDate,
            TextNote = EditorNotes.Text
        };
        App.NoteRepo.AddNewNoteOrUpdateExistingNote(newNote);
        DisplayAlert(AppStrings.Save, App.NoteRepo.StatusMessage, AppStrings.Ok);
    }

    private void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        DateTime selectedDate = DateView.Date;
        Note existingNote = App.NoteRepo.GetNoteByDate(selectedDate);
        if (existingNote != null)
        {
            App.NoteRepo.DeleteNoteByDate(existingNote.Date);
            EditorNotes.Text = string.Empty;
            DisplayAlert(AppStrings.Delete, App.NoteRepo.StatusMessage, AppStrings.Ok);
        }
        else
            DisplayAlert(AppStrings.Error, AppStrings.NullNote, AppStrings.Ok);
    }
}