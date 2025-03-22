namespace MyShift.Pages;

public partial class TeamViewPage : ContentPage
{
	public TeamViewPage()
	{
		InitializeComponent();
	}

    private void OnYesterdayButtonClicked(object sender, EventArgs e)
    {
        DateView.Date = DateView.Date.AddDays(-1);
    }

    private void OnHomeButtonClicked(object sender, EventArgs e)
    {
        DateView.Date = DateTime.Today;
    }

    private void OnTomorrowButtonClicked(object sender, EventArgs e)
    {
        DateView.Date = DateView.Date.AddDays(1);
    }
}