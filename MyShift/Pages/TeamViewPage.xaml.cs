using MyShift.Services;

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
    }
}