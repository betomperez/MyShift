namespace MyShift.Services;

class ShiftMananger
{
    private Dictionary<string, List<string>> _shifts = new Dictionary<string, List<string>>
    {
        {"morning", new List<string>    { "A", "A", "A", "A", "B", "B", "B", "B", "C", "C" } },
        {"afternoon", new List<string>  { "C", "C", "D", "D", "D", "D", "E", "E", "E", "E" } },
        {"night", new List<string>      { "E", "E", "C", "C", "A", "A", "D", "D", "B", "B" } },
        {"dayoffA", new List<string>    { "B", "D", "E", "B", "C", "E", "A", "C", "D", "A" } },
        {"dayoffB", new List<string>    { "D", "B", "B", "E", "E", "C", "C", "A", "A", "D" } },
    };

    public string? MorningShift { get; set; }
    public string? AfternoonShift { get; set; }
    public string? NightShift { get; set; }
    public string? DayOffA { get; set; }
    public string? DayOffB { get; set; }

    public void RefreshShifts(DateOnly date, int offset)
    {
        int index = (date.DayNumber + offset) % 10;
        MorningShift = _shifts["morning"][index];
        AfternoonShift = _shifts["afternoon"][index];
        NightShift = _shifts["night"][index];
        DayOffA = _shifts["dayoffA"][index];
        DayOffB = _shifts["dayoffB"][index];
    }
}
